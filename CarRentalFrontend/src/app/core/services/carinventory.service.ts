import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Car } from '../Models/car';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarinventoryService {
  OrderDetails = new BehaviorSubject({});
  constructor(private http: HttpClient) {

  }

  AddCar(car: Car) {
    let url = environment.api + 'carinventory/addcar';
    return this.http.post(url, car);
  }

  DeleteCar(vehicleId: string) {
    let url = environment.api + `carinventory/deletecar/${vehicleId}`;
    return this.http.delete(url);
  }

  UpdateCar(car: Car) {
    let url = environment.api + 'carinventory/updatecar';
    return this.http.put(url, car);
  }

  GetCarById(id: string) {
    let url = environment.api + `carinventory/GetCarDetail/${id}`;
    return this.http.get<Car>(url);
  }

  GetAllCar(maker: string, model: string, minPrice: string, maxPrice: string,startDate:string,endDate:string) {
    let url = environment.api + 'carinventory/getallavailablecar?';

    if (minPrice) {
      url = url + `minprice=${minPrice}&`;
    } else {
      url = url + `minprice=${0}&`;
    }

    if (maxPrice) {
      url = url + `maxprice=${maxPrice}&`;
    } else {
      url = url + `maxprice=${10000000}&`;
    }

    url=url+`startDate=${startDate}&`;
    url=url+`endDate=${endDate}&`;
    
    if (maker) {
      url = url + `maker=${maker}&`;
    }


    if (model) {
      url = url + `model=${model}&`;
    }

    url = url.substring(0, (url.length - 1));
    return this.http.get<[Car]>(url);
  }

  GetAllCars() {
    let url=environment.api+'carinventory/allcars';
    return this.http.get<[Car]>(url);

  }


  IsPossibleToBookCar (vehicleId:string,startDate:string,endDate:string) {
    let url=environment.api+`carinventory/IsPossibleToBookCar?vehicleId=${vehicleId}&startDate=${startDate}&endDate=${endDate}`;
    return this.http.get(url);
  }
}