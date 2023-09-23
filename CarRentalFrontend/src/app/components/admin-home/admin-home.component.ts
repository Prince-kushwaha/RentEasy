import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Car } from 'src/app/core/Models/car';
import { CarinventoryService } from 'src/app/core/services/carinventory.service';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})
export class AdminHomeComponent {

  cars: Array<Car> = [];

  constructor(private router: Router, private carinventoryService: CarinventoryService) {

  }

  next(resp: Array<Car>) {
    this.cars = resp;
  }

  error() {

  }


  handleClick(id: string) {
    this.router.navigate([`admin/car/${id}`]);
  }

  ngOnInit(): void {
    this.carinventoryService.GetAllCars().subscribe({ next: this.next.bind(this), error: this.error.bind(this) });
  }
}
