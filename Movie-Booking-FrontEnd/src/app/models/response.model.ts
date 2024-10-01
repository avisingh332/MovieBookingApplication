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
    startTime:Time, 
    endTime:Time,
}
export interface LoginResponse{
    userId:string, 
    name:string, 
    email:string, 
    jwtToken:string, 
    expiresIn:Date, 
    roles:string[],
}