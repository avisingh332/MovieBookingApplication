import { Time } from "@angular/common";

export interface ApiResponse{
    isSuccess: boolean, 
    message:string, 
    result: object
}

export interface GetMoviesResponseType{
    id:string;
    name: string;
    description: string;
    director:string;
    genre:string;
}
export interface GetShowResponseType{
    id:string,
    movieId:string, 
    startDate:Date, 
    endDate:Date, 
    screenNo:number, 
    noOfSeats:number,
    startTime:string, 
    endTime:string,
    price:number,
}
export interface LoginResponse{
    userId:string, 
    name:string, 
    email:string, 
    jwtToken:string, 
    expiresIn:Date, 
    roles:string[],
}

export interface GetBookingResponse{
    id:string, 
    movieDetails:GetMoviesResponseType, 
    showDetails: GetShowResponseType|null, 
    seatsBooked:number
}