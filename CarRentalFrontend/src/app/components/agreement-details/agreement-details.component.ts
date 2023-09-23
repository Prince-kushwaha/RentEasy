import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Agreement } from 'src/app/core/Models/Agreement';
import { RentalAgreementService } from 'src/app/core/services/rental-agreement.service';

@Component({
  selector: 'app-agreement-details',
  templateUrl: './agreement-details.component.html',
  styleUrls: ['./agreement-details.component.css']
})
export class AgreementDetailsComponent implements OnInit {
  agreement!:Agreement;
  constructor (private agreementService:RentalAgreementService,private activateRouter:ActivatedRoute,private router:Router) {

  }

  next(resp:any) {
    this.agreement=resp;
  }

  error() {

  }

  requestForReturn() {
   this.agreementService.RequestForReturn(this.agreement.id!).subscribe({next:this.nextRequest.bind(this),error:this.error.bind(this)}) 
  }


  nextRequest() {
    this.router.navigateByUrl('/myagreements');
  }

  ngOnInit(): void {
    let agreementId=this.activateRouter.snapshot.paramMap.get('id');
    this.agreementService.GetRentalAgreementByid(agreementId!).subscribe({next:this.next.bind(this),error:this.error.bind(this)})
  }
}
