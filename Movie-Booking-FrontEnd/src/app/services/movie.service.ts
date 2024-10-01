import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiResponse } from '../models/response.model';
import { environment } from '../environment/environment';
import { MovieCreateRequest } from '../models/request.model';
import { catchError, map, Observable, switchMap, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http:HttpClient) { }
  baseApiUrl = environment.API_URL;

  addMovie(movie:MovieCreateRequest):Observable<any> {
    return this.http.post<ApiResponse>(`${this.baseApiUrl}/api/Movie`, movie).pipe(
      map(response => {
        if (response.isSuccess) {
          return response.result;
        }
        else {
          throw new Error(response.message);
        }
      }),
      catchError(error => {
        return throwError(() => new Error('Error Adding Movie'))
      })
    );
  }
  getAllMovie(showDate: string): Observable<any> {
    return this.http.get<ApiResponse>(`${this.baseApiUrl}/api/Movie?showDate=${showDate}`).pipe(
      map((resp) => {
        if (resp.isSuccess) {
          return resp.result;  // Pass the result to the component
        } else {
          throw new Error(resp.message);  // Handle errors
        }
      }),
      catchError((error) => {
        console.error(error);  // Log error in case of failure
        return throwError(() => new Error('Error Fetching Movie'));  // Return an error observable
      })
    );
  }
  
}
