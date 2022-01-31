using System;

namespace Fleet.Vehicles.Models
{
    public class VehicleLogFile
    {
        public int? VehicleId { get; set; }
        public string Name { get; set; }
        public VehicleType? Type { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
