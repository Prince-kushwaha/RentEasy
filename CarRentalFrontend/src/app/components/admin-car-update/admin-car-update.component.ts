import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from 'src/app/core/Models/car';
import { CarinventoryService } from 'src/app/core/services/carinventory.service';

@Component({
  selector: 'app-admin-car-update',
  templateUrl: './admin-car-update.component.html',
  styleUrls: ['./admin-car-update.component.css']
})
export class AdminCarUpdateComponent implements OnInit {
  car!: Car;
  form: FormGroup = new FormGroup({
    Maker: new FormControl(null, [Validators.required]),
    Model: new FormControl(null, [Validators.required]),
    RentalPrice: new FormControl(null, [Validators.required])
  })

  constructor(private router: Router, private carInventoryService: CarinventoryService, private activatedRouter: ActivatedRoute) {

  }
  

  ngOnInit(): void {
    let id = this.activatedRouter.snapshot.paramMap.get('id');
    this.carInventoryService.GetCarById(id!).subscribe({ next: this.setValue.bind(this), error: this.error.bind(this) })
  }

  setValue(car: Car) {
    this.car = car;
    this.form.setValue({ Maker: this.car.maker, Model: this.car.model, RentalPrice: this.car.rentalPrice })
  }

  error() {

  }

  next() {
   this.router.navigateByUrl(`admin/car/${this.car.vehicleId}`);   
  }

  onSubmit() {
    let maker = this.form.value.Maker;
    let model = this.form.value.Model;
    let rentalPrice = this.form.value.RentalPrice;
    let car: Car = { ...this.car, maker, model, rentalPrice };
    this.carInventoryService.UpdateCar(car).subscribe({ next: this.next.bind(this), error: this.error.bind(this) });
  }
}
