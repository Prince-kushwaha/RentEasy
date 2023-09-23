import { NgModule } from '@angular/core';
import { CarInventoryRoutingModule } from './car-inventory-routing.module';
import { AddCarComponent } from './components/add-car/add-car.component';
import { SharedModule } from '../shared/shared.module';
import { CarDetailsComponent } from './components/car-details/car-details.component';

@NgModule({
  declarations: [
    AddCarComponent,
    CarDetailsComponent
  ],
  imports: [
    SharedModule,
    CarInventoryRoutingModule
  ]
})
export class CarInventoryModule { }
