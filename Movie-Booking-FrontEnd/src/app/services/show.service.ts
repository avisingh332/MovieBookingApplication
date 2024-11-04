import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environment/environment';
import { ApiResponse, GetShowResponseType } from '../models/response.model';
import { catchError, forkJoin, map, Observable, throwError } from 'rxjs';
import { ShowCreateRequest } from '../models/request.model';

@Injectable({
  providedIn: 'root'
})
export class ShowService {

  constructor(private http: HttpClient) { }
  baseApiUrl = environment.API_URL;

  addShows(shows: ShowCreateRequest[]): Observable<any> {
    // console.log("Shows to Add are: ");
    // console.log(shows);
    const request = shows.map(show =>
      this.http.post<ApiResponse>(`${this.baseApiUrl}/api/Show`, show)
    );
    return forkJoin(request).pipe(
      map(responses => {
        // Assuming responses is an array of responses from your requests
        const results = responses.map(response => {
          if (response.isSuccess) {
            return response.result;
          } else {
            throw new Error(response.message); // This will trigger the catchError
          }
        });
    
        return results; // Return the array of results
      }),
      catchError(error => {
        // Here, we catch errors from any request
        console.error('Error Adding Movie:', error); // Log the error
        return throwError(() => new Error('Error Adding Movie')); // Rethrow with a custom message
      })
    )

  }

  // getAllShows(movieId:string, showDate:Date):Observable<any>{
  //   this.http.get<ApiResponse>(`${this.baseApiUrl}/api/Show?movieId=${movieId}&showDate=${showDate}`).subscribe({
  //     next:(resp)=>{
  //       if(resp.isSuccess){
  //         return resp.result;
  //       }
  //       else {
  //         throw new Error(resp.message);
  //       }
  //     },
  //     error: (err)=>{
  //       console.log(err);
  //     }
  //   })
  // }

  getAllShows(movieId: string):Observable<GetShowResponseType[]> {
    return this.http.get<ApiResponse>(`${this.baseApiUrl}/api/Show?movieId=${movieId}`).pipe(
      map((resp) => {
        if (resp.isSuccess) {
          return resp.result as GetShowResponseType[];
        } else {
          throw new Error(resp.message);
        }
      }),
      catchError((error) => {
        console.error(error);
        return throwError(() => new Error('Error Fetching Shows'));
      })
    );
  }
  // getShowById(movieId: string):Observable<GetShowResponseType> {
  //   return this.http.get<ApiResponse>(`${this.baseApiUrl}/api/Show?movieId=${movieId}`).pipe(
  //     map((resp) => {
  //       if (resp.isSuccess) {
  //         return resp.result as GetShowResponseType[];
  //       } else {
  //         throw new Error(resp.message);
  //       }
  //     }),
  //     catchError((error) => {
  //       console.error(error);
  //       return throwError(() => new Error('Error Fetching Shows'));
  //     })
  //   );
  // }
  
}
