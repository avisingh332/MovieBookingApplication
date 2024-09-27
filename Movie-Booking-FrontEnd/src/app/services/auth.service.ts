import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject, tap } from 'rxjs';
import {environment} from '../environment/environment'
import { HttpClient } from '@angular/common/http';
import { UserDetailsType } from '../models/generic.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  private loginStatus = new BehaviorSubject<boolean>(this.initialLoginStatus());
  loginStatus$ = this.loginStatus.asObservable();
  
  private loginStatusChange = new Subject<void>();
  loginStatusChange$ = this.loginStatusChange.asObservable();

  private userDetails = new BehaviorSubject<UserDetailsType|null>(this.initialUserDetails());
  userDetails$ = this.userDetails.asObservable();

  baseApiUrl = environment.API_URL;
  constructor(private http:HttpClient) {
    // this.setUserDetailsAndToken();
  }
  private initialLoginStatus(): boolean {
    const token = localStorage.getItem('token');
    return !!token;
  }


  private initialUserDetails(): UserDetailsType | null {
    const user = localStorage.getItem('user');
    return user ? JSON.parse(user) : null;
  }

  private emitUserDetailsAndToken(){
    const token = localStorage.getItem('token');
    const user = localStorage.getItem('user');
    if (token && user) {
      this.loginStatus.next(true);
      this.userDetails.next(JSON.parse(user));
    }
    else{
      this.loginStatus.next(false);
      this.userDetails.next(null);
    }
    // console.log("user and token are ", user, token);
  }
 
  login(loginDetail: any): Observable<object>{
    return this.http.post<object>(`${this.baseApiUrl}/api/Auth/Login`, loginDetail).pipe(
      tap((response: any) => {
        if (response && response.result) {
          console.log("Login  response", response);
          localStorage.setItem('token', response.result.jwtToken);
          let user:UserDetailsType = {
            id:response.result.userId, 
            name: response.result.name, 
            email: response.result.email,
          }
          localStorage.setItem('user', JSON.stringify(user));
          this.loginStatusChange.next();
          this.emitUserDetailsAndToken();
        }
      })
    );
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.emitUserDetailsAndToken();
    this.loginStatusChange.next();
  }
}
