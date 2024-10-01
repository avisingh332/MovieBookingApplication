import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { AdminHomeComponent } from './pages/admin/admin-home/admin-home.component';
import { HttpClientModule } from '@angular/common/http';
import { AddMoviesComponent } from './pages/admin/add-movies/add-movies.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserHomeComponent } from './pages/user/user-home/user-home.component';
import { LoginComponent } from './pages/global/login/login.component';
import { MovieComponent } from './pages/user/movie/movie.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    AdminHomeComponent,
    AddMoviesComponent,
    UserHomeComponent,
    LoginComponent,
    MovieComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
