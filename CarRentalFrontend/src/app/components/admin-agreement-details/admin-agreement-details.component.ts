import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Agreement } from 'src/app/core/Models/Agreement';
import { RentalAgreementService } from 'src/app/core/services/rental-agreement.service';
import { reverseString } from 'src/app/core/utils';

@Component({
  selector: 'app-admin-agreement-details',
  templateUrl: './admin-agreement-details.component.html',
  styleUrls: ['./admin-agreement-details.component.css']
})
export class AdminAgreementDetailsComponent implements OnInit {
  agreement!: Agreement;
  constructor(private agreementService: RentalAgreementService, private activateRouter: ActivatedRoute, private router: Router) {

  }


  ngOnInit(): void {
    let agreementId = this.activateRouter.snapshot.paramMap.get('id');
    this.agreementService.RentalAgreementDetails(agreementId!).subscribe({ next: this.next.bind(this), error: this.error.bind(this) })
  }

  delete() {
    this.agreementService.DeleteRentalAgreement(this.agreement.id!).subscribe({ next: this.nextDelete.bind(this), error: this.error.bind(this) });
  }


  error() {

  }

  next(resp: any) {
    this.agreement = resp;
  }

  nextDelete() {
    this.router.navigateByUrl('admin/agreements');
  }

  update() {
    this.router.navigateByUrl(`admin/agreement/update/${this.agreement.id!}`);
  }
}
