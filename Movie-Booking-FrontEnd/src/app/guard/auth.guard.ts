import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';
import { jwtDecode } from "jwt-decode";

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService)
  const router = inject(Router)
  const user = authService.getUser();
  if (user) {
    const decodedToken: any = jwtDecode(user.token);
    const expirationDate = decodedToken.exp * 1000;
    const currentTime = new Date().getTime();

    if (expirationDate < currentTime) {
      authService.logout();
      return router.navigate(['/login'])
    }
    else {
      if (user.roles.includes('Admin')) {
        return true;
      } else {
        alert('Unauthorized');
        return false;
      }
    }
  }
  else {
    //Logout 
    authService.logout();
    return router.navigate(['/login']);
  }
};


export const RoleGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService)
  const router = inject(Router)
  const user = authService.getUser();
  if(user && user.roles){
    console.log("role guard is working ", user.roles);
    if (user.roles.includes('Admin')) {
      router.navigate(['/admin','home']);
    } else if (user.roles.includes('User')) {
      router.navigate(['/user','home']);
    }
  }
  
  return false;
};
