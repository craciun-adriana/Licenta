import { Genre } from "./genre";
import { Rating } from "./rating";

export interface FilmModel {
    id: string;
    title: string;
    director: string;
    description: string;
    releaseDate: Date;
    prequelId: string;
    sequelId: string;
    genre: Genre;
    rating: Rating;
    length: number;
    picture: string;
}
