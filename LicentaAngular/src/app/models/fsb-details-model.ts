import { Genre } from "./genre";
import { Rating } from "./rating";

export interface FsbDetailsModel {
    id: string;
    title: string;
    author: string;
    description: string;
    releaseDate: Date;
    prequelId?: string;
    sequelId?: string;
    genre: Genre;
    picture: string;
    prequelTitle?: string;
    sequelTitle?: string;
    director: string;
    rating: Rating;
    length: number;
    nrEps: number;
}
