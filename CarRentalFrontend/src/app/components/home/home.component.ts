import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Car } from 'src/app/core/Models/car';
import { CarinventoryService } from 'src/app/core/services/carinventory.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewInit {
  cars: Array<Car> = [];
  makerQuery: string = ''
  modelQuery: string = ''
  minPriceQuery: string = ''
  maxPriceQuery: string = ''
  startDate: string = this.findCurrentDate();
  endDate: string = this.findNextCurrentDate();
  @ViewChild('endDateInput') endDateInput!: ElementRef;
  @ViewChild('startDateInput') startDateInput!: ElementRef;

  constructor(private router: Router, private carinventoryService: CarinventoryService) {

  }


  ngOnInit(): void {
    this.carinventoryService.GetAllCar(this.makerQuery, this.modelQuery, this.minPriceQuery, this.maxPriceQuery, this.startDate, this.endDate).subscribe({ next: this.next.bind(this), error: this.error.bind(this) });
  }

  ngAfterViewInit(): void {
    this.startDateInput.nativeElement.min = this.findCurrentDate();
    this.endDateInput.nativeElement.min = this.findNextCurrentDate();
  }


  next(resp: Array<Car>) {
    this.cars = resp;
  }

  error() {
    
  }



  Search() {
    this.carinventoryService.GetAllCar(this.makerQuery, this.modelQuery, this.minPriceQuery, this.maxPriceQuery, this.startDate, this.endDate).subscribe({ next: this.next.bind(this), error: this.error.bind(this) });
  }

  handleClick(id: string) {
    this.router.navigate([`/car/${id}`]);
  }

  findCurrentDate() {
    let dtToday = new Date();
    let month: string | number = dtToday.getMonth() + 1;
    let day: string | number = dtToday.getDate();
    let year = dtToday.getFullYear();
    if (month < 10)
      month = '0' + month.toString();
    if (day < 10)
      day = '0' + day.toString();

    var date = year + '-' + month + '-' + day;
    return date;
  }

  findNextCurrentDate() {
    let dtToday = new Date();
    let dtNextDay=new Date((dtToday.getTime()+(24*60*60*1000)));
    let month: string | number = dtNextDay.getMonth() + 1;
    let day: string | number = dtNextDay.getDate();
    let year = dtNextDay.getFullYear();
    if (month < 10)
      month = '0' + month.toString();
    if (day < 10)
      day = '0' + day.toString();

    var date = year + '-' + month + '-' + day;
    return date;
  }

  findNextDateOfStartDate(startDate:string) {
    let dtToday = new Date(startDate);
    console.log(dtToday);
    let dtNextDay=new Date((dtToday.getTime()+(24*60*60*1000)));
    let month: string | number = dtNextDay.getMonth() + 1;
    let day: string | number = dtNextDay.getDate();
    let year = dtNextDay.getFullYear();
    if (month < 10)
      month = '0' + month.toString();
    if (day < 10)
      day = '0' + day.toString();

    var date = year + '-' + month + '-' + day;
    this.endDateInput.nativeElement.min=date;
  }


}
