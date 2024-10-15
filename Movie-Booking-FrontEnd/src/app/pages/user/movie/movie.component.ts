import { Component, OnInit, ɵsetAlternateWeakRefImpl } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/generic.model';
import { BookingCreateRequest } from 'src/app/models/request.model';
import { GetBookingResponse, GetMoviesResponseType, GetShowResponseType } from 'src/app/models/response.model';
import { AuthService } from 'src/app/services/auth.service';
import { BookingService } from 'src/app/services/booking.service';
import { MovieService } from 'src/app/services/movie.service';
import { ShowService } from 'src/app/services/show.service';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
  user:User|undefined;
  movieId: string | undefined;
  movie$: Observable<GetMoviesResponseType> | undefined;
  shows$: Observable<GetShowResponseType[]> | undefined;
  selectedShow: GetShowResponseType | undefined;
  hoveredNumber: number | null = null;
  numbers: number[] = Array.from({ length: 10 }, (_, i) => i + 1); // Generates an array from 1 to 10

  selectedNumber: number=1; // Variable to store the selected number

  // movie: GetMoviesResponseType|undefined;
  constructor(private route: ActivatedRoute, private movieService: MovieService,
              private router:Router,
              private bookingService:BookingService,
              private authService:AuthService,
              private showService: ShowService) {
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        let id = params.get('id');
        if (id != null) {
          this.movieId = id;
          this.movie$ = this.movieService.getMovie(id);
          this.shows$ = this.showService.getAllShows(this.movieId);
        }
      },
    });

    this.authService.user$().subscribe({
      next:(userDetails)=>{
        this.user = userDetails;
      }
    })

  }

  selectShow(show: GetShowResponseType) {
    this.selectedShow = show;
  }

  // Method to set the selected number
  selectNumber(number: number): void {
    this.selectedNumber = number;
  }

  confirmBooking() {
    if(!this.user?.roles.includes('User')){
      this.router.navigate(['/login']);
    }
    if(this.selectedShow && this.selectedNumber && this.user ){
      let payload = JSON.parse(atob(this.user.token.split('.')[1]));
      let requestObj:BookingCreateRequest={
        showId: this.selectedShow.id, 
        userId: payload.nameid,
        seatsBooked: this.selectedNumber,
      }
      this.bookingService.AddBooking(requestObj).subscribe({
        next:(resp)=>{
          alert("Movie Booked Successfully")
        }
      })
    }
  }

}
