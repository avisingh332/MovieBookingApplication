import { Component, OnInit } from '@angular/core';
import { GetBookingResponse } from 'src/app/models/response.model';
import { BookingService } from 'src/app/services/booking.service';


@Component({
  selector: 'app-user-bookings',
  templateUrl: './user-bookings.component.html',
  styleUrls: ['./user-bookings.component.css']
})
export class UserBookingsComponent implements OnInit {

  constructor(private bookingService:BookingService) {
  }
  userBookings: GetBookingResponse[] = [];
  ngOnInit(): void {
    this.fetchBookings();
  }

  fetchBookings(){
    this.bookingService.GetAllUserBooking().subscribe({
      next:(resp)=>{
        this.userBookings =resp
        console.log(this.userBookings);
      }
    })
  }
}
