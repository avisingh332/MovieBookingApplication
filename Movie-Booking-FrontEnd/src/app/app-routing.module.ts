import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminHomeComponent } from './pages/admin/admin-home/admin-home.component';
import { AddMoviesComponent } from './pages/admin/add-movies/add-movies.component';
import { UserHomeComponent } from './pages/user/user-home/user-home.component';
import { LoginComponent } from './pages/global/login/login.component';
import { MovieComponent } from './pages/user/movie/movie.component';
import { UserBookingsComponent } from './pages/user/user-bookings/user-bookings.component';

const routes: Routes = [
  {path:'admin', children:[
    {path:'home', component:AdminHomeComponent}
  ]},
  {path:'add-movie',component:AddMoviesComponent},
  {path:'user', children:[
    {path:'home', component:UserHomeComponent}, 
    {path:'movie/:id', component:MovieComponent},
    {path:'bookings', component:UserBookingsComponent}
  ]},
  {path:'login', component:LoginComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
