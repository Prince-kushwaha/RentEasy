import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from 'src/app/core/Models/car';
import { CarinventoryService } from 'src/app/core/services/carinventory.service';

@Component({
  selector: 'app-admin-car-details',
  templateUrl: './admin-car-details.component.html',
  styleUrls: ['./admin-car-details.component.css']
})
export class AdminCarDetailsComponent {
  car!: Car;

  constructor(private carInventoryService: CarinventoryService, private router: Router, private activatedRouter: ActivatedRoute) {

  }

  ngOnInit(): void {
    let id = this.activatedRouter.snapshot.paramMap.get('id');
    this.carInventoryService.GetCarById(id!).subscribe({ next: this.next.bind(this), error: this.error.bind(this) });
  }

  delete() {
    this.carInventoryService.DeleteCar(this.car.vehicleId!).subscribe({ next: this.nextD.bind(this), error: this.error.bind(this) });
  }

  update() {
    this.router.navigateByUrl(`admin/car/update/${this.car.vehicleId}`);
  }

  nextD() {
    this.router.navigateByUrl('admin/home');
  }

  next(car: Car) {
    this.car = car;
  }

  error() {

  }
}
