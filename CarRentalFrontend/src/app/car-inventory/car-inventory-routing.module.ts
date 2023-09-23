import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCarComponent } from './components/add-car/add-car.component';
import { CarDetailsComponent } from './components/car-details/car-details.component';
import { adminAuthGuardGuard } from '../authGuard/admin-auth-guard.guard';

const routes: Routes = [
  { path: 'admin/addcar', canActivate:[adminAuthGuardGuard], component: AddCarComponent },
  { path: 'car/:id', component: CarDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CarInventoryRoutingModule { }
