import { Component, OnInit } from '@angular/core';
import { GetMoviesResponseType } from 'src/app/models/response.model';
import { MovieService } from 'src/app/services/movie.service';
import { ShowService } from 'src/app/services/show.service';


@Component({
  selector: 'app-user-home',
  templateUrl: './user-home.component.html',
  styleUrls: ['./user-home.component.css']
})

export class UserHomeComponent implements OnInit {

  movies:GetMoviesResponseType[]= [];
  isLogin: boolean = true;
  selectedDate:string;
  constructor(private movieService:MovieService, private showService:ShowService ){
    this.selectedDate = this.selectedDate =new Date().toISOString().split('T')[0];
  }
  ngOnInit(): void {
    this.loadMovies();
  }
  loadMovies(){
    
    this.movieService.getAllMovie(this.selectedDate).subscribe({
      next:(movies:GetMoviesResponseType[])=>{
        movies.forEach(m=>{
          m.description = this.trimString(m.description);
        })
        this.movies= movies;
      }
    })
  }

  onDayPick($event:any) {
    this.selectedDate = $event.target.datePicked;
    const today = new Date();
    const selectedDateTocmp = new Date(this.selectedDate);
    today.setHours(0, 0, 0, 0);
    selectedDateTocmp.setHours(0, 0, 0, 0);
    if(selectedDateTocmp < today){
      alert("Select Date Starting from Today!!!");
      location.reload();
      return;
    }
    this.loadMovies();
  }
  trimString(str:string){
    const words = str.split(' ');
    const trimmedString = words.slice(0, 8).join(' ') + "....";
    return trimmedString;
  }
}
