import { AfterViewInit, Component, ElementRef, HostListener, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LeafletControlLayersConfig, LeafletDirective } from '@asymmetrik/ngx-leaflet';
import * as L from 'leaflet';
import { delay } from 'rxjs';
import { GetFleetsRequest } from 'src/api/models';
import { FleetsService, VehiclesService } from 'src/api/services';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

    @ViewChild('searchFilterField') searchInput!: ElementRef<HTMLInputElement>;
    @ViewChild(LeafletDirective, { static: true }) leafletDirective!: LeafletDirective;

    options: L.MapOptions = {
        layers: [
            L.tileLayer(
                'https://tiles.stadiamaps.com/tiles/alidade_smooth/{z}/{x}/{y}{r}.png', {
                maxZoom: 20, attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
            })
        ],
        zoom: 14,
        zoomControl: false,
        center: L.latLng(14.594777, 121.054463)
    };

    layersControl: LeafletControlLayersConfig = {
        baseLayers: {
            'Default': L.tileLayer('https://tiles.stadiamaps.com/tiles/alidade_smooth/{z}/{x}/{y}{r}.png', { maxZoom: 20 }),
            'CH Swisstopo LBM Dark': L.tileLayer('https://api.maptiler.com/maps/ch-swisstopo-lbm-dark/{z}/{x}/{y}.png?key=dKFpUJ6juOZ4bJH0Cl6y', { maxZoom: 18 }),
            'Basic': L.tileLayer('https://api.maptiler.com/maps/bright/{z}/{x}/{y}.png?key=dKFpUJ6juOZ4bJH0Cl6y', { maxZoom: 18 })
        },
        overlays: {

        }
    }

    fleets: any = [];
    activeFleet: number | undefined = undefined;
    layers: L.Layer[] = [];
    searchFilter!: string;

    vehiclesLoading: boolean = false;
    fleetsLoading: boolean = false;

    constructor(private vehiclesService: VehiclesService,
        private fleetsService: FleetsService,
        private activatedRoute: ActivatedRoute) { }

    ngOnInit(): void {
        this.activatedRoute.queryParams.subscribe(params => {
            let fleetId = params['fleet'];
            if (fleetId == undefined) this.activeFleet = undefined;
            else this.activeFleet = parseInt(fleetId);

            this.loadVehicles();
        });

        let request: GetFleetsRequest = {};
        this.fleetsLoading = true;
        this.fleetsService.apiFleetsGet$Json({ request: request })
            .pipe(delay(1000))
            .subscribe({
                next: (response) => {
                    if (response.fleets == null) return;

                    this.fleets = response.fleets;
                },
                error: (response) => {
                    this.fleetsLoading = false;
                },
                complete: () => {
                    this.fleetsLoading = false;
                }
            });
    }

    loadVehicles() {
        this.layers = this.layers.filter(l => false);
        this.vehiclesLoading = true;
        this.vehiclesService.apiVehiclesGet$Json({ FleetId: this.activeFleet })
            .pipe(delay(1000))
            .subscribe({
                next: (response) => {
                    if (response.vehicles == null) return;

                    let vehicles = response.vehicles.filter(v => v.lastKnownLocation != null);
                    let markers = vehicles.map(v => {
                        let latLng = L.latLng(v.lastKnownLocation!!.latitude!!, v.lastKnownLocation!!.longitude!!);
                        let marker = L.marker(latLng, {
                            icon: L.icon({
                                iconUrl: 'assets/truck.png',
                                iconSize: [48, 48],
                            }),
                            title: v.name!!
                        });

                        marker.bindPopup(`<strong>${v.name}</strong>`);

                        marker.on('mouseover', (e) => {
                            e.target.openPopup();
                        });

                        return marker;
                    });

                    markers.forEach(m => this.layers.push(m));
                },
                error: (response) => {
                    this.vehiclesLoading = false;
                },
                complete: () => {
                    this.vehiclesLoading = false;
                }
            });
    }

    get filteredLayers(): L.Layer[] {
        if (this.searchFilter == null) return this.layers;

        return this.layers.filter(l => {
            if (l instanceof L.Marker) {
                let marker: L.Marker = l;
                return marker.options.title?.toLowerCase().includes(this.searchFilter.toLowerCase());
            }

            return false;
        });
    }

    @HostListener('window:keydown', ['$event'])
    onKeyDown($event: KeyboardEvent): void {
        if ($event.getModifierState && $event.getModifierState('Control') && $event.keyCode === 70) {
            $event.preventDefault();
            this.searchInput.nativeElement.focus();
        }
    }
}
