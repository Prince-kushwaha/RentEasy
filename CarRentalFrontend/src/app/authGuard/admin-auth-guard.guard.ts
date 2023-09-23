import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../core/services/auth-service.service';

export const adminAuthGuardGuard: CanActivateFn = (route, state) => {
  let authService=inject(AuthService);
  let router=inject(Router);
  if(!authService.isLoggedIn.value) {
    router.navigate(['/login']);
    return false;
  } else  if(authService.user.value.role=='User') {
    router.navigate(['/']);
    return false;
  } else {
    return true;
  }
};
