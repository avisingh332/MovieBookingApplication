import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  isLogin:boolean = true;
  userDetails:any|null;
  searchForm:FormGroup;

  constructor(private authService: AuthService, private router:Router, private fb:FormBuilder) {
    console.log("Into navbar component !!!!!");
    this.searchForm = fb.group({
      searchQuery:['']
    });
  }

  ngOnInit(): void {
    // console.log("Ng Onit of home page Runs");
    this.authService.userDetails$.subscribe(details=>{
      if(details ==null) this.isLogin=false;
      else {
        this.isLogin = true;
        this.userDetails= details;
      }
    })
  }

  logout(){
    this.authService.logout();
    console.log("Token Removed");
    this.router.navigate(['/user','home'])
  }

}
