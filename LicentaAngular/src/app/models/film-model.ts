import { Genre } from "./genre";
import { Rating } from "./rating";

export interface FilmModel {
    id: string;
    title: string;
    director: string;
    description: string;
    relaseDate: Date;
    prequelId?: string;
    sequelId?: string;
    genre: Genre;
    rating: Rating;
    length: number;
    picture: string;
    prequelTitle?: string;
    sequelTitle?: string;
}

export interface CreateFilmModel {
    title: string;
    director: string;
    description: string;
    relaseDate: Date;
    prequelId?: string;
    sequelId?: string;
    genre: Genre;
    rating: Rating;
    length: number;
    picture: string;
}

