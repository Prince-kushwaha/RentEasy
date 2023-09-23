import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Agreement } from '../Models/Agreement';

@Injectable({
  providedIn: 'root'
})
export class RentalAgreementService {
  baseUrl!: string;
  constructor(private http: HttpClient) {
    this.baseUrl = environment.api + 'rentalagreement'
  }

  CreateRentalAgreement(agreement: Agreement) {
    let url = this.baseUrl + '/CreateRentalAgreement';
    return this.http.post(url, agreement);
  }

  GetMyRentalAgreement() {
    let url = this.baseUrl + '/GetMyRentalAgreement';
    return this.http.get<[Agreement]>(url);
  }

  GetRentalAgreementByid(id: string) {
    let url = this.baseUrl + `/GetMyRentalAgreement/${id}`
    return this.http.get(url);
  }

  RequestForReturn(id: string) {
    let url = this.baseUrl + `/RequestForReturn/${id}`;
    return this.http.get(url);
  }

  GetAllRentalAgreement() {
    let url = this.baseUrl + '/GetAllRentalAgreement';
    return this.http.get(url);
  }

  RentalAgreementDetails(agreementId: string) {
    let url = this.baseUrl + `/RentalAgreementDetails/${agreementId}`;
    return this.http.get(url);
  }

  DeleteRentalAgreement(agreementId: string) {
    let url = this.baseUrl + `/DeleteRentalAgreement/${agreementId}`;
    return this.http.delete(url);
  }

  UpdateRentalAgreementStatus(agreementId: string, status: string) {
    let url = this.baseUrl + `/updaterentalagreementstatus/${agreementId}`;
    return this.http.put(url, { Status: status });
  }
}
