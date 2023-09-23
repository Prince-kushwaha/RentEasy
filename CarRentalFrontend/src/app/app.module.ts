import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { HeaderComponent } from './components/header/header.component';
import { LoginComponent } from './components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HeaderInterceptorInterceptor } from './core/interceptors/header-interceptor.interceptor';
import { appInitialzer } from './core/interceptors/appInitializer';
import { AuthService } from './core/services/auth-service.service';
import { CarInventoryModule } from './car-inventory/car-inventory.module';
import { CreateRentalAgreementComponent } from './components/create-rental-agreement/create-rental-agreement.component';
import { MyAgreementComponent } from './components/my-agreement/my-agreement.component';
import { AgreementDetailsComponent } from './components/agreement-details/agreement-details.component';
import { AdminRentalAgreementsComponent } from './components/admin-rental-agreements/admin-rental-agreements.component';
import { AdminAgreementDetailsComponent } from './components/admin-agreement-details/admin-agreement-details.component';
import { AdminHomeComponent } from './components/admin-home/admin-home.component';
import { AdminCarDetailsComponent } from './components/admin-car-details/admin-car-details.component';
import { AdminCarUpdateComponent } from './components/admin-car-update/admin-car-update.component';
import { AdminAgreementUpdateComponent } from './components/admin-agreement-update/admin-agreement-update.component';
import { ReviseDatePipe } from './pipes/revise-date.pipe';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    LoginComponent,
    CreateRentalAgreementComponent,
    MyAgreementComponent,
    AgreementDetailsComponent,
    AdminRentalAgreementsComponent,
    AdminAgreementDetailsComponent,
    AdminHomeComponent,
    AdminCarDetailsComponent,
    AdminCarUpdateComponent,
    AdminAgreementUpdateComponent,
    ReviseDatePipe,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CarInventoryModule,
    AppRoutingModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: HeaderInterceptorInterceptor, multi: true },
    { provide: APP_INITIALIZER, useFactory: appInitialzer,deps:[AuthService], multi: true }
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
