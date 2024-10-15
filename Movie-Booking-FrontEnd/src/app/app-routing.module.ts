import { inject, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminHomeComponent } from './pages/admin/admin-home/admin-home.component';
import { AddMoviesComponent } from './pages/admin/add-movies/add-movies.component';
import { UserHomeComponent } from './pages/user/user-home/user-home.component';
import { LoginComponent } from './pages/global/login/login.component';
import { MovieComponent } from './pages/user/movie/movie.component';
import { UserBookingsComponent } from './pages/user/user-bookings/user-bookings.component';
import { authGuard, RoleGuard } from './guard/auth.guard';
import { AuthService } from './services/auth.service';

function redirectBasedOnRole(){
  let authService = inject(AuthService);
  let route =  (authService.getUser()?.roles.includes('Admin') ? "/admin/home" : "/user/home");
  return route;
}


const routes: Routes = [
  {
    path: 'admin', children: [
      { path: 'home', component: AdminHomeComponent, canActivate: [authGuard] },
      { path: 'add-movie', component: AddMoviesComponent, canActivate: [authGuard] },
    ]
  },

  {
    path: 'user', children: [
      { path: 'home', component: UserHomeComponent },
      { path: 'movie/:id', component: MovieComponent },
      { path: 'bookings', component: UserBookingsComponent }
    ]
  },
  { path: 'login', component: LoginComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
