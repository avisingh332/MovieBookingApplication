import { Component, OnInit } from '@angular/core';
import { forkJoin, map, switchMap } from 'rxjs';
import { MovieWithShows } from 'src/app/models/generic.model';
import { GetMoviesResponseType, GetShowResponseType } from 'src/app/models/response.model';
import { MovieService } from 'src/app/services/movie.service';
import { ShowService } from 'src/app/services/show.service';


@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})


export class AdminHomeComponent implements OnInit {
  // movies = [
  //   {
  //       "id": "1",
  //       "name": "Inception",
  //       "description": "A skilled thief, the absolute best in the dangerous art of extraction, is offered a chance to have his criminal history erased.",
  //       "director": "Christopher Nolan",
  //       "genre": "Science Fiction", 
  //       showTimings:[
  //         "10:00 AM", "1:00 PM", "4:00 PM", "7:00 PM"
  //       ]
  //   },
  //   {
  //       "id": "2",
  //       "name": "The Shawshank Redemption",
  //       "description": "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
  //       "director": "Frank Darabont",
  //       "genre": "Drama",
  //       showTimings:[
  //         "10:00 AM", "1:00 PM", "4:00 PM", "7:00 PM"
  //       ]
  //   },
  //   {
  //       "id": "3",
  //       "name": "The Godfather",
  //       "description": "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.",
  //       "director": "Francis Ford Coppola",
  //       "genre": "Crime",
  //       showTimings:[
  //         "10:00 AM", "1:00 PM", "4:00 PM", "7:00 PM"
  //       ]
  //   },
  //   {
  //       "id": "4",
  //       "name": "The Dark Knight",
  //       "description": "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.",
  //       "director": "Christopher Nolan",
  //       "genre": "Action",
  //       showTimings:[
  //         "10:00 AM", "1:00 PM", "4:00 PM", "7:00 PM"
  //       ]
  //   },
  //   {
  //       "id": "5",
  //       "name": "Pulp Fiction",
  //       "description": "The lives of two mob hitmen, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
  //       "director": "Quentin Tarantino",
  //       "genre": "Crime",
  //       showTimings:[
  //         "10:00 AM", "1:00 PM", "4:00 PM", "7:00 PM"
  //       ]
  //   }
  // ];
  // movies:GetMoviesResponseType[]=[];
  movieWithShows:MovieWithShows[] =[];
  // shows: { [movieId: string]: GetShowResponseType[] } = {};
  selectedDate:Date = new Date();
  constructor(private movieService:MovieService, private showService:ShowService) {

  }
  ngOnInit(): void {
    this.getMovieByDate();
  }

  getMovieByDate(){
    let formattedDate = this.selectedDate.toISOString().split('T')[0];
    // this.movieService.getAllMovie(formattedDate).subscribe({
    //   next:(resp)=>{
    //     this.movies=resp;
    //     this.fetchShowsForMovies();
    //   },
    //   error:(err)=>{console.log(err)}
    // })

    const movieRequest = this.movieService.getAllMovie(formattedDate).pipe(
      switchMap((movies:GetMoviesResponseType[])=>{
        const showRequest = movies.map(m=>{
          return this.showService.getAllShows(m.id).pipe(
            map(shows=> ({movie:{...m}, shows:shows}) )
          )
        });
        return forkJoin(showRequest);
      })
    )

    movieRequest.subscribe({
      next:(movieWithShows:MovieWithShows[])=>{
        this.movieWithShows = movieWithShows;
        console.log(this.movieWithShows)
      }
    })
  }

  // fetchShowsForMovies() {
  //   this.movies.forEach((movie) => {
  //     this.showService.getAllShows(movie.id).subscribe({
  //       next: (shows) => {
  //         shows[movie.id] = shows
  //         console.log(shows[movie.id])
  //       },
  //       error: (err) => console.error(err),
  //     });
  //   });
  // }
}




// fetchMoviesWithShows(): Observable<any[]> {
//   return this.fetchMovies().pipe(
//     map(movies => {
//       const showRequests = movies.map(movie => 
//         this.fetchShows(movie.id).pipe(
//           map(shows => ({ ...movie, shows }))
//         )
//       );
//       return forkJoin(showRequests);
//     })
//   );
// }
