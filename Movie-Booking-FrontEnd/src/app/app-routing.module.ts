import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminHomeComponent } from './pages/admin/admin-home/admin-home.component';
import { AddMoviesComponent } from './pages/admin/add-movies/add-movies.component';
import { UserHomeComponent } from './pages/user/user-home/user-home.component';

const routes: Routes = [
  {path:'admin-home', component: AdminHomeComponent},
  {path:'add-movie',component:AddMoviesComponent},
  {path:'user-home',component:UserHomeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
