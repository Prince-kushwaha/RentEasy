import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services/auth-service.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isLoggedIn: boolean = false;
  userRole?: string;

  constructor(private authService: AuthService,private router:Router) {
    
  }

  ngOnInit(): void {
    this.authService.isLoggedIn.subscribe((status) => this.isLoggedIn = status);
    this.authService.user.subscribe((user:any) => this.userRole = user.role);
  }

  next() {
    this.authService.isLoggedIn.next(false);
    this.authService.user.next({});
    this.router.navigate(['/']);
  }

  error() {

  }

  Logout() {
    this.authService.LogOut().subscribe({ next: this.next.bind(this), error: this.error.bind(this) });
  }
}
