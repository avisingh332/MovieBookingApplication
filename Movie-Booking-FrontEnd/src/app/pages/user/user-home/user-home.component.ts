import { Component, OnInit } from '@angular/core';
import { GetMoviesResponseType } from 'src/app/models/request.model';

@Component({
  selector: 'app-user-home',
  templateUrl: './user-home.component.html',
  styleUrls: ['./user-home.component.css']
})

export class UserHomeComponent implements OnInit {
  movies = [
    {
        "id": "1",
        "name": "Inception",
        "description": "A skilled thief, the absolute best in the dangerous art of extraction, is offered a chance to have his criminal history erased.",
        "director": "Christopher Nolan",
        "genre": "Science Fiction", 
        showTimings:[
          "10:00 AM", "1:00 PM", "4:00 PM", "7:00 PM"
        ]
    },
    {
        "id": "2",
        "name": "The Shawshank Redemption",
        "description": "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
        "director": "Frank Darabont",
        "genre": "Drama",
        showTimings:[
          "10:00 AM", "1:00 PM", "4:00 PM", "7:00 PM"
        ]
    },
    {
        "id": "3",
        "name": "The Godfather",
        "description": "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.",
        "director": "Francis Ford Coppola",
        "genre": "Crime",
        showTimings:[
          "10:00 AM", "1:00 PM", "4:00 PM", "7:00 PM"
        ]
    },
    {
        "id": "4",
        "name": "The Dark Knight",
        "description": "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.",
        "director": "Christopher Nolan",
        "genre": "Action",
        showTimings:[
          "10:00 AM", "1:00 PM", "4:00 PM", "7:00 PM"
        ]
    },
    {
        "id": "5",
        "name": "Pulp Fiction",
        "description": "The lives of two mob hitmen, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
        "director": "Quentin Tarantino",
        "genre": "Crime",
        showTimings:[
          "10:00 AM", "1:00 PM", "4:00 PM", "7:00 PM"
        ]
    }
  ];
  isLogin: boolean = true;
  selectedDate:string = '';
  constructor(){

  }
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }
}
