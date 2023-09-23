import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { CreateRentalAgreementComponent } from './components/create-rental-agreement/create-rental-agreement.component';
import { MyAgreementComponent } from './components/my-agreement/my-agreement.component';
import { AgreementDetailsComponent } from './components/agreement-details/agreement-details.component';
import { AdminRentalAgreementsComponent } from './components/admin-rental-agreements/admin-rental-agreements.component';
import { AdminAgreementDetailsComponent } from './components/admin-agreement-details/admin-agreement-details.component';
import { AdminHomeComponent } from './components/admin-home/admin-home.component';
import { AdminCarDetailsComponent } from './components/admin-car-details/admin-car-details.component';
import { AdminCarUpdateComponent } from './components/admin-car-update/admin-car-update.component';
import { AdminAgreementUpdateComponent } from './components/admin-agreement-update/admin-agreement-update.component';
import { userAuthGuard } from './authGuard/user-auth.guard';
import { adminAuthGuardGuard } from './authGuard/admin-auth-guard.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'createagreement', canActivate:[userAuthGuard], component: CreateRentalAgreementComponent },
  { path: 'myagreements', canActivate:[userAuthGuard], component: MyAgreementComponent },
  { path: 'myagreement/:id', canActivate:[userAuthGuard], component: AgreementDetailsComponent },
  { path: 'admin/agreements', canActivate:[adminAuthGuardGuard],component: AdminRentalAgreementsComponent },
  { path: 'admin/agreement/:id',canActivate:[adminAuthGuardGuard], component: AdminAgreementDetailsComponent },
  { path: 'admin/home', canActivate:[adminAuthGuardGuard], component: AdminHomeComponent },
  { path: 'admin/car/:id',canActivate:[adminAuthGuardGuard], component: AdminCarDetailsComponent },
  { path: 'admin/car/update/:id',canActivate:[adminAuthGuardGuard], component: AdminCarUpdateComponent },
  { path: 'admin/agreement/update/:id', canActivate:[adminAuthGuardGuard], component: AdminAgreementUpdateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
