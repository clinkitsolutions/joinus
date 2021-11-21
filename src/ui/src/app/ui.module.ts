import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './pages/home/home.component';
import { LeafletModule } from '@asymmetrik/ngx-leaflet';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { SpinnerComponent } from './shared/spinner/spinner.component';

const components = [
    HomeComponent,
    SpinnerComponent
];

@NgModule({
    imports: [
        AppRoutingModule,
        CommonModule,
        FormsModule,

        LeafletModule
    ],
    declarations: components,
    exports: components
})
export class UiModule { }
