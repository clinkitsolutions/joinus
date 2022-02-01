using CsvHelper;
using Fleet.Common;
using Fleet.Vehicles.Models;
using Fleet.Vehicles.Repositories;
using Fleet.Vehicles.Requests;
using Fleet.Vehicles.Responses;
using Fleet.Vehicles.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Fleet.Vehicles.Services
{
    public class DefaultVehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleLogItemRepository _vehicleLogItemRepository;
        private readonly FileUploadOptions _options;

        public DefaultVehicleService(
            IVehicleRepository vehicleRepository,
            IVehicleLogItemRepository vehicleLogItemRepository,
            IOptions<FileUploadOptions> options)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleLogItemRepository = vehicleLogItemRepository;
            _options = options.Value;
        }

        public async Task<GetVehiclesResponse> GetVehiclesAsync(GetVehiclesRequest request)
        {
            if (request.FleetId.HasValue)
            {
                // Get by fleet
                return await GetVehiclesByFleetId(request.FleetId);
            }

            var vehicles = await _vehicleRepository.GetAsync();
            var viewModels = vehicles.Select(v => new VehicleViewModel
            {
                Id = v.Id,
                Name = v.Name,
                Type = v.Type,
                LastKnownLocation = v.Log?.LastOrDefault()?.Location
            });

            var response = new GetVehiclesResponse
            {
                Vehicles = viewModels
            };

            return response;
        }

        public async Task<UpdateVehicleLogsResponse> UpdateVehicleLogsAsync(UpdateVehicleLogsRequest request)
        {
            await UpdateVehicleLogs(request.Updates);

            var response = new UpdateVehicleLogsResponse
            {

            };

            return response;
        }
        
        public async Task<UpdateVehicleLogsResponse> UpdateVehicleLogsFromCsvAsync(IFormFile file)
        {
            bool isAccepted = false;
            if (file.Length > 0)
            {
                if (file.FileName == $"{_options.AcceptedFileName}.csv")
                {
                    var vehicleLogs = GetCsvRecordFromFile(file);

                    if (vehicleLogs != null && vehicleLogs.Count > 0)
                    {
                        await UpdateVehicleLogs(VehicleLogFileToViewModel(vehicleLogs));
                        isAccepted = true;
                    }
                }

                var filePath = isAccepted ? _options.AcceptedFilePath : _options.RejectedFilePath;

                // save uploaded file
                using (var stream = File.Create($"{filePath}\\{file.FileName.Replace(".csv", "-" + DateTime.Now.ToString("yyyy-MM-ddTHHmmss") + ".csv")}"))
                {
                    await file.CopyToAsync(stream);
                }
            }

            if (!isAccepted)
            {
                throw new ArgumentNullException("Invalid file");
            }

            var response = new UpdateVehicleLogsResponse
            {

            };

            return response;
        }

        private async Task UpdateVehicleLogs(IEnumerable<VehicleUpdateViewModel> updates)
        {
            var vehicles = new Dictionary<int, Vehicle>();

            foreach (var update in updates)
            {
                Vehicle vehicle;
                if (update.VehicleId.HasValue)
                {
                    if (!vehicles.ContainsKey(update.VehicleId.Value))
                    {
                        vehicle = await _vehicleRepository.GetAsync(update.VehicleId.Value);
                        if (vehicle != null)
                        {
                            vehicles.Add(update.VehicleId.Value, vehicle);
                        }
                        else
                        {
                            // TODO: Add log that the vehicleId is not existing
                            continue;
                        }
                    }
                    else
                    {
                        vehicle = vehicles[update.VehicleId.Value];
                    }
                }
                else if (!string.IsNullOrEmpty(update.Name) && update.Type.HasValue)
                {
                    vehicle = new Vehicle
                    {
                        Name = update.Name,
                        Type = update.Type.Value,
                        Log = new List<VehicleLogItem>(),
                        VehicleFleets = new List<VehicleFleet>()
                    };

                    await _vehicleRepository.CreateAsync(vehicle);
                }
                else
                {
                    // No vehicle ID, and no name and type, so we just skip since we don't know what this is
                    continue;
                }

                if (vehicle != null && update.Location.Timestamp <= DateTime.Now)
                {
                    var vehicleLogItem = new VehicleLogItem
                    {
                        Vehicle = vehicle,
                        Location = update.Location
                    };
                    await _vehicleLogItemRepository.CreateAsync(vehicleLogItem);
                }
            }
        }

        private async Task<GetVehiclesResponse> GetVehiclesByFleetId(int? fleetId)
        {
            var vehicles = await _vehicleRepository.GetAsync(v => v.VehicleFleets.Any(vf => vf.FleetId == fleetId));
            var viewModels = vehicles.Select(v => new VehicleViewModel
            {
                Id = v.Id,
                Name = v.Name,
                Type = v.Type,
                LastKnownLocation = v.Log?.LastOrDefault()?.Location
            });

            var response = new GetVehiclesResponse
            {
                Vehicles = viewModels
            };

            return response;
        }

        private List<VehicleLogFile> GetCsvRecordFromFile(IFormFile file)
        {
            List<VehicleLogFile> vehicleLogs;
            using (var textReader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(textReader, CultureInfo.InvariantCulture))
            {
                vehicleLogs = csv.GetRecords<VehicleLogFile>().ToList();
            }

            return vehicleLogs;
        }

        private List<VehicleUpdateViewModel> VehicleLogFileToViewModel(List<VehicleLogFile> logFiles)
        {
            var vehicleUpdateViewModels = new List<VehicleUpdateViewModel>();

            logFiles.ForEach(logFile =>
            {
                vehicleUpdateViewModels.Add(
                    new VehicleUpdateViewModel
                    {
                        Name = logFile.Name,
                        VehicleId = logFile.VehicleId,
                        Type = logFile.Type,
                        Location = new Location
                        {
                            Latitude = logFile.Latitude,
                            Longitude = logFile.Longitude,
                            Timestamp = logFile.Timestamp,
                        }
                    });
            });

            return vehicleUpdateViewModels;
        }
    }
}
