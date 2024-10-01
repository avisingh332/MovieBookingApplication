import { GetMoviesResponseType, GetShowResponseType } from "./response.model";

export interface UserDetailsType {
    name: string,
    email: string,
    id: string
};
export interface MovieWithShows{
    movie:GetMoviesResponseType, 
    shows:GetShowResponseType[],
}

export interface User{
    email: string;
    roles: string[];
    name: string;
    token:string;
}
