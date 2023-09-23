import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RentalAgreementService } from 'src/app/core/services/rental-agreement.service';

@Component({
  selector: 'app-admin-agreement-update',
  templateUrl: './admin-agreement-update.component.html',
  styleUrls: ['./admin-agreement-update.component.css']
})
export class AdminAgreementUpdateComponent  implements OnInit {
  agreementId!:string;
  updateForm:FormGroup =new FormGroup({
    status:new FormControl(null,[Validators.required])
  })

  constructor(private router: Router, private rentalAgreementsService: RentalAgreementService,private activatedRouter:ActivatedRoute) {

  }

  ngOnInit(): void {
    this.agreementId=this.activatedRouter.snapshot.paramMap.get('id')!;
  }


  next() {
    this.router.navigateByUrl(`admin/agreement/${this.agreementId}`);
  }


  onSubmit() {
    let status=this.updateForm.get('status')?.value;
    this.rentalAgreementsService.UpdateRentalAgreementStatus(this.agreementId,status).subscribe({next:this.next.bind(this)});
  }
}
