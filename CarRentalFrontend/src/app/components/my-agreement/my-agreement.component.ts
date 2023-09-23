import { Component, OnInit } from '@angular/core';
import {  Router } from '@angular/router';
import { Agreement } from 'src/app/core/Models/Agreement';
import { RentalAgreementService } from 'src/app/core/services/rental-agreement.service';

@Component({
  selector: 'app-my-agreement',
  templateUrl: './my-agreement.component.html',
  styleUrls: ['./my-agreement.component.css']
})
export class MyAgreementComponent implements OnInit {
  agreements: Array<Agreement> = [];
  constructor(private rentalService: RentalAgreementService, private router: Router) {
    
  }

  

  next(resp: any) {
    this.agreements = resp;
  }

  handleClick(id: string) {
    this.router.navigateByUrl(`/myagreement/${id}`);
  }

  error() {

  }

  ngOnInit(): void {
    this.rentalService.GetMyRentalAgreement().subscribe({ next: this.next.bind(this), error: this.error.bind(this) })
  }
}
