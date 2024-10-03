import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BookingCreateRequest } from '../models/request.model';
import { environment } from '../environment/environment';
import { catchError, map, Observable, throwError } from 'rxjs';
import { ApiResponse, GetBookingResponse, GetShowResponseType } from '../models/response.model';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  constructor(private http:HttpClient) { }
  baseApiUrl = environment.API_URL;

  AddBooking(requestObj:BookingCreateRequest){
    return this.http.post<ApiResponse>(`${this.baseApiUrl}/api/Booking`, requestObj).pipe(
      map((resp) => {
        if (resp.isSuccess) {
          return resp.result as GetShowResponseType[];
        } else {
          throw new Error(resp.message);
        }
      }),
      catchError((error) => {
        console.error(error);
        return throwError(() => new Error('Error Booking'));
      })
    );
  }

  GetAllUserBooking():Observable<GetBookingResponse[]>{
    return this.http.get<ApiResponse>(`${this.baseApiUrl}/api/Booking`).pipe(
      map((resp) => {
        if (resp.isSuccess) {
          return resp.result as GetBookingResponse[];
        } else {
          throw new Error(resp.message);
        }
      }),
      catchError((error) => {
        console.error(error);
        return throwError(() => new Error('Error Fetching Bookings'));
      })
    );
  }

  // GetAllBooking(){
    
  // }
}
