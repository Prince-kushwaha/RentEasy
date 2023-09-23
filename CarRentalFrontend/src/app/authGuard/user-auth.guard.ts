import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../core/services/auth-service.service';

export const userAuthGuard: CanActivateFn = (route, state) => {
  let authService = inject(AuthService);
  let router = inject(Router);
  let role: any = authService.user.getValue()?.role;

  if (!authService.isLoggedIn.value) {
    router.navigateByUrl('/login');
    return false;
  } else if (role == 'Admin') {
    router.navigate(['/admin/home']);
    return false;
  } else {
    return true;
  }
};
