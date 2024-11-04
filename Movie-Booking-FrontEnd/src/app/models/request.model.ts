import { Time } from "@angular/common";

export interface LoginRequest{
    
}

export interface MovieCreateRequest{
    name:string, 
    directorName:string, 
    genre:string, 
    description:string, 
    shows:[],
};

export interface ShowCreateRequest{
    movieId:string, 
    startDate:Date, 
    endDate:Date, 
    screenNo:number, 
    noOfSeats:number,
    startTime:Time, 
    endTime:Time,
    price:number,
};
export interface BookingCreateRequest{
    showId:string, 
    seatsBooked:number, 
    bookingDate:string,
}