import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Car } from 'src/app/core/Models/car';
import { CarinventoryService } from 'src/app/core/services/carinventory.service';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css']
})
export class CarDetailsComponent implements OnInit, AfterViewInit {
  car!: Car;
  @ViewChild('endDateInput') endDate!: ElementRef;
  @ViewChild('startDateInput') startDate!: ElementRef;
  totalAmount: number = 0;
  errorMsg?: string = undefined;
  form:FormGroup=new FormGroup({
    startDate:new FormControl(null,[Validators.required]),
    endDate:new FormControl(null,[Validators.required])
  });

  constructor(private carInventoryService: CarinventoryService, private router: Router, private activatedRouter: ActivatedRoute) {

  }

  ngOnInit(): void {
    let id = this.activatedRouter.snapshot.paramMap.get('id');
    this.carInventoryService.GetCarById(id!).subscribe({ next: this.next.bind(this), error: this.error.bind(this) });
  }


  ngAfterViewInit(): void {
    this.startDate.nativeElement.min = this.findCurrentDate();
    this.endDate.nativeElement.min = this.findCurrentNextDate();
  }


  next(car: Car) {
    this.car = car;
  }

  bookCar() {
    let endDate = this.endDate.nativeElement.value;
    let startDate = this.startDate.nativeElement.value;
    if (this.numberOfDay() <= 0) {
      this.errorMsg = "EtarDate is  greater Day than StartDate"
      return;
    }

    this.carInventoryService.IsPossibleToBookCar(this.car.vehicleId!,startDate,endDate).subscribe((result)=>{
      if(result) {
        let totalCost = this.numberOfDay() * this.car.rentalPrice;
        this.carInventoryService.OrderDetails.next({ totalCost, maker: this.car.maker, model: this.car.model, rentalPrice: this.car.rentalPrice, startDate, endDate, vehicleId: this.car.vehicleId });
        this.router.navigate(['/createagreement']);    
      } else {
        this.errorMsg="Car is not Avaible";
      }
    });
  }

  error() {

  }

  numberOfDay() {
    let dayMilliSeconds = 1000 * 60 * 60 * 24;
    const startDate = new Date(this.startDate.nativeElement.value);
    const endDate = new Date(this.endDate.nativeElement.value);
    const timeDifference = endDate.getTime() - startDate.getTime();
    const days = Math.floor(timeDifference / dayMilliSeconds);
    return days;
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

  
  findCurrentNextDate() {
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
    this.endDate.nativeElement.min=date;
  }

}
