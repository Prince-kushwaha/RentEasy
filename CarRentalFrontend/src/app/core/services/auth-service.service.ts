import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../Models/User';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn = new BehaviorSubject(false);
  user = new BehaviorSubject<any>({role:undefined});

  constructor(private http: HttpClient) {

  }

  Login(loginForm: { email: string, password: string }) {
    let url = environment.api + "account/login/";
    return this.http.post<User>(url, loginForm);
  }

  LogOut() {
    let url = environment.api + 'account/logout/';
    return this.http.get(url);
  }

  IsUserLoggedIn() {
    let url = environment.api + 'account/isuserloggedin/';
    return this.http.get<User>(url);
  }
}
