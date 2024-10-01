import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/generic.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  
  user:User|undefined;

  constructor(private authService: AuthService, private router:Router, private fb:FormBuilder) {
  
  }

  ngOnInit(): void {
    this.authService.user$().subscribe(user=>{
      this.user = user;
      console.log("user is: ", user);
    });
    this.user = this.authService.getUser();
  }

  logout(){
    this.authService.logout();
    console.log("Token Removed");
    this.router.navigate(['/user','home'])
  }

}
