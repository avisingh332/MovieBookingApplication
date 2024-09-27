import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-add-movies',
  templateUrl: './add-movies.component.html',
  styleUrls: ['./add-movies.component.css']
})
export class AddMoviesComponent implements OnInit {
  moviesForm:FormGroup;
  constructor(private fb: FormBuilder) {
    this.moviesForm = fb.group({
      name:[''], 
      directorName:[''],
      genre:[''],
      description:[''],
      shows: this.fb.array([])    
    });
    this.addShow();
  }

  get shows(): FormArray {
    return this.moviesForm.get('shows') as FormArray;
  }

  addShow() {
    const showGroup = this.fb.group({
      startDate: [''],
      endDate: [''],
      timing: ['']
    });
    this.shows.push(showGroup); // Add a new show group to the FormArray
  }

  removeShow(index: number) {
    this.shows.removeAt(index); // Remove a show group from the FormArray
  }
  ngOnInit(): void {
    this
  }

}
