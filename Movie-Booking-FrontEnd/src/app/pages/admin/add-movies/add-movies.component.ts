import { Component, OnInit, ɵsetAlternateWeakRefImpl } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
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
  minDate: string|undefined;

  constructor(private fb: FormBuilder, private showService: ShowService,
    private movieService: MovieService) {
    console.log("into constructor of add movies")
    this.moviesForm = fb.group({
      name: ['', Validators.required],
      director: ['', Validators.required],
      genre: ['', Validators.required],
      description: ['', Validators.required],
      shows: this.fb.array([])
    });
    this.addShow();
    
  }

  setMinDate() {
    const today = new Date();
    const year = today.getFullYear();
    const month = (today.getMonth() + 1).toString().padStart(2, '0'); // Ensure 2 digits for month
    const day = today.getDate().toString().padStart(2, '0'); // Ensure 2 digits for day
    this.minDate = `${year}-${month}-${day}`; // Set the date in yyyy-MM-dd format
  }

  ngOnInit(): void {
    this.setMinDate();
  }

  get shows(): FormArray {
    return this.moviesForm.get('shows') as FormArray;
  }
  // Custom Validator for Date
  dateGreaterThanToday(control: AbstractControl): ValidationErrors | null {
    const currentDate = new Date();
    const selectedDate = new Date(control.value);
    return selectedDate > currentDate ? null : { dateInvalid: true };
  }
  endDateValidator(control: any) {
    const startDate = control.parent?.get('startDate')?.value;
    const endDate = control.value;
    return( endDate && startDate && new Date(endDate) < new Date(startDate))||(startDate && !endDate) ? { endDateInvalid: true } : null;
  }

  dateValidator() {
    return (control: any) => {
      const today = new Date();
      const selectedDate = new Date(control.value);
      return selectedDate < today ? { dateInvalid: true } : null;
    };
  }

  endTimeValidator(control: any) {
    const startTime = control.parent?.get('startTime')?.value;
    const endTime = control.value;
    return endTime && startTime && endTime <= startTime ? { endTimeInvalid: true } : null;
  }
  addShow() {
    const showGroup = this.fb.group({
      startDate: ['', [Validators.required, this.dateValidator()]],
      endDate: ['', [Validators.required, this.endDateValidator.bind(this)]],
      startTime: ['', Validators.required],
      endTime: ['', [Validators.required, this.endTimeValidator.bind(this)]],
      screenNo: [1, [Validators.required, Validators.min(1)]],
      noOfSeats: [100, [Validators.required, Validators.min(1)]],
      price: ['', [Validators.required, Validators.min(1)]]
    });
    this.shows.push(showGroup);
  }

  removeShow(index: number) {
    this.shows.removeAt(index);
  }


  handleSubmit() {
    if (this.moviesForm.invalid) {
      this.moviesForm.markAllAsTouched(); // Mark all fields as touched to trigger validation messages
      return;
    }
    let { shows, ...movie } = this.moviesForm.value;

    this.movieService.addMovie(movie).subscribe({
      next: (resp) => {
        console.log(resp, " Movie Added Successfully!!!");

        shows = shows.map((show: ShowCreateRequest) => {
          return { ...show, movieId: resp.id };
        });

        this.showService.addShows(shows).subscribe({
          next: (resp) => {
            console.log(resp);
            alert("Movie and Shows Added Successfully!!!!");
          },
          error: (err) => {
            console.log(err);
          }
        })
      },
      error: (err) => {
        console.log(err);
      }
    });

  }

}
