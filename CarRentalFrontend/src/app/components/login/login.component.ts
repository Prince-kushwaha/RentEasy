import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms'
import { Router } from '@angular/router';
import { User } from 'src/app/core/Models/User';
import { AuthService } from 'src/app/core/services/auth-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  errorMsg?: string;
  loginForm: FormGroup = new FormGroup({
    email: new FormControl(null, [Validators.required]),
    password: new FormControl(null, [Validators.required])
  })

  constructor(private authService: AuthService, private router: Router) {

  }

  next(user: User) {
    this.authService.isLoggedIn.next(true);
    this.authService.user.next(user);
    if (user.role == 'User') {
      this.router.navigateByUrl('/');
    } else {
      this.router.navigateByUrl('admin/home');
    }
  }

  error(error: HttpErrorResponse) {
    this.errorMsg=error.error;
  }

  Submit() {
    let formValues = {
      email: this.loginForm.value.email,
      password: this.loginForm.value.password
    }
    
    this.authService.Login(formValues).subscribe({ next: this.next.bind(this), error: this.error.bind(this) });
  }
}
