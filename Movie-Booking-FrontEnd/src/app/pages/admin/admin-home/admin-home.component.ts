import { Component, OnInit } from '@angular/core';
import { forkJoin, map, switchMap } from 'rxjs';
import { MovieWithShows } from 'src/app/models/generic.model';
import { GetMoviesResponseType, GetShowResponseType } from 'src/app/models/response.model';
import { MovieService } from 'src/app/services/movie.service';
import { ShowService } from 'src/app/services/show.service';
import 'date-carousel/date-carousel.js'

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})


export class AdminHomeComponent implements OnInit {

  onDayPick($event:any) {
    this.selectedDate = $event.target.datePicked;
    this.getMovieByDate();
  }


  movieWithShows: MovieWithShows[] = [];

  // selectedDate: Date = new Date();
  selectedDate: string;
  constructor(private movieService: MovieService, private showService: ShowService) {
    this.selectedDate =new Date().toISOString().split('T')[0];
  }
  ngOnInit(): void {
    this.getMovieByDate();
  }

  getMovieByDate() {
    // let formattedDate = this.selectedDate.toISOString().split('T')[0];
    let formattedDate = this.selectedDate;
    // this.movieService.getAllMovie(formattedDate).subscribe({
    //   next:(resp)=>{
    //     this.movies=resp;
    //     this.fetchShowsForMovies();
    //   },
    //   error:(err)=>{console.log(err)}
    // })

    const movieRequest = this.movieService.getAllMovie(formattedDate).pipe(
      switchMap((movies: GetMoviesResponseType[]) => {
        const showRequest = movies.map(m => {
          return this.showService.getAllShows(m.id).pipe(
            map(shows => ({ movie: { ...m }, shows: shows }))
          )
        });
        return forkJoin(showRequest);
      })
    )

    movieRequest.subscribe({
      next: (movieWithShows: MovieWithShows[]) => {
        this.movieWithShows = movieWithShows;
        console.log(this.movieWithShows)
      }
    })
  }

}




