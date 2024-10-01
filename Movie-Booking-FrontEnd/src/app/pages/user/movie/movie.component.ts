import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent implements OnInit {
  movieId:string|null =null;
  constructor(private route:ActivatedRoute) {

  }
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
       this.movieId = params.get('id');
       console.log("Movie Id is ",this.movieId);
      },
    });

  }

}
