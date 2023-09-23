import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Agreement } from 'src/app/core/Models/Agreement';
import { RentalAgreementService } from 'src/app/core/services/rental-agreement.service';

@Component({
  selector: 'app-admin-rental-agreements',
  templateUrl: './admin-rental-agreements.component.html',
  styleUrls: ['./admin-rental-agreements.component.css']
})
export class AdminRentalAgreementsComponent {
  agreements: Array<Agreement> = [];
  constructor(private rentalService: RentalAgreementService, private router: Router) {

  }

  next(resp: any) {
    this.agreements = resp;
  }

  handleClick(id: string) {
    this.router.navigateByUrl(`admin/agreement/${id}`);
  }

  error() {

  }

  ngOnInit(): void {
    this.rentalService.GetAllRentalAgreement().subscribe({ next: this.next.bind(this), error: this.error.bind(this) })
  }
}
