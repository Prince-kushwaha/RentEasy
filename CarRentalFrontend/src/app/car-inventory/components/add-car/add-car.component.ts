import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Car } from 'src/app/core/Models/car';
import { CarinventoryService } from 'src/app/core/services/carinventory.service';

@Component({
  selector: 'app-add-car',
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css']
})
export class AddCarComponent {
  form: FormGroup = new FormGroup({
    Maker: new FormControl(null, [Validators.required]),
    Model: new FormControl(null, [Validators.required]),
    RentalPrice: new FormControl(null, [Validators.required])
  })

  constructor(private carInventoryService: CarinventoryService, private router: Router) {

  }

  next() {
    this.router.navigateByUrl('/carinventory');
  }

  error() {

  }

  onSubmit() {
    let maker = this.form.value.Maker;
    let model = this.form.value.Model;
    let rentalPrice = this.form.value.RentalPrice;
    let car: Car = { maker, model, rentalPrice };
    this.carInventoryService.AddCar(car).subscribe({ next: this.next.bind(this), error: this.error.bind(this) });
  }
}
