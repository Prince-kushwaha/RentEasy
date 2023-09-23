import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Agreement } from 'src/app/core/Models/Agreement';
import { AuthService } from 'src/app/core/services/auth-service.service';
import { CarinventoryService } from 'src/app/core/services/carinventory.service';
import { RentalAgreementService } from 'src/app/core/services/rental-agreement.service';
@Component({
  selector: 'app-create-rental-agreement',
  templateUrl: './create-rental-agreement.component.html',
  styleUrls: ['./create-rental-agreement.component.css']
})
export class CreateRentalAgreementComponent implements OnInit {
  agreement: Agreement;
  errorMsg?: string;
  constructor(private carinventoryService: CarinventoryService, private authService: AuthService, private rentalAgreementService: RentalAgreementService, private router: Router) {
    let carDetails: any = carinventoryService.OrderDetails.value;
    let userDetails: any = authService.user.value;
    this.agreement = {
      maker: carDetails.maker,
      model: carDetails.model,
      email: userDetails.email,
      name: userDetails.name,
      phoneNumber: userDetails.phoneNumber,
      totalCost: carDetails.totalCost,
      startDate: carDetails.startDate,
      endDate: carDetails.endDate,
      rentalPrice: carDetails.rentalPrice,
      vehicleId: carDetails.vehicleId,
    }
  }

  ngOnInit(): void {
    if (Object.keys(this.carinventoryService.OrderDetails.value).length == 0) {
      this.router.navigate(['/']);
    }
  }

  next() {
    this.router.navigateByUrl('/myagreements');
  }

  error(error: HttpErrorResponse) {
    this.errorMsg = error.error;
  }

  bookCar() {
    this.rentalAgreementService.CreateRentalAgreement(this.agreement).subscribe({ next: this.next.bind(this), error: this.error.bind(this) });
  }
}
