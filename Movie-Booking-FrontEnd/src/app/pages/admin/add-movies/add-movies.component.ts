import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { ShowCreateRequest } from 'src/app/models/request.model';
import { MovieService } from 'src/app/services/movie.service';
import { ShowService } from 'src/app/services/show.service';

@Component({
  selector: 'app-add-movies',
  templateUrl: './add-movies.component.html',
  styleUrls: ['./add-movies.component.css']
})
export class AddMoviesComponent implements OnInit {


  moviesForm: FormGroup;
  constructor(private fb: FormBuilder, private showService: ShowService,
    private movieService: MovieService) {
    console.log("into constructor of add movies")
    this.moviesForm = fb.group({
      name: [''],
      director: [''],
      genre: [''],
      description: [''],
      shows: this.fb.array([])
    });
    this.addShow();
  }

  ngOnInit(): void {
  }
  get shows(): FormArray {
    return this.moviesForm.get('shows') as FormArray;
  }

  addShow() {
    const showGroup = this.fb.group({
      startDate: [''],
      endDate: [''],
      startTime:[''], 
      endTime:[''], 
      screenNo:[1], 
      noOfSeats:[100],
      price:['']
    });
    this.shows.push(showGroup); // Add a new show group to the FormArray
  }

  removeShow(index: number) {
    this.shows.removeAt(index); // Remove a show group from the FormArray
  }


  handleSubmit() {
   let {shows,...movie} = this.moviesForm.value;

  //  console.log("shows: ", shows);
  //  console.log("Movie: ", movie);

   this.movieService.addMovie(movie).subscribe({
    next:(resp)=>{
      console.log(resp, " Movie Added Successfully!!!");
      

      shows = shows.map((show:ShowCreateRequest)=> {
        return { ...show, movieId: resp.id }; 
      });

      this.showService.addShows(shows).subscribe({
        next:(resp)=>{
          console.log(resp);
        },
        error:(err)=>{
          console.log(err);
        }
       })
    },
    error:(err)=>{
      console.log(err);
    }
   });
   
  }

}
