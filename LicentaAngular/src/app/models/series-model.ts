import { Genre } from "./genre";
import { Rating } from "./rating";

export interface SeriesModel {
    id: string;
    title: string;
    director: string;
    description: string;
    releaseDate: Date;
    prequelId?: string;
    sequelId?: string;
    genre: Genre;
    rating: Rating;
    nrEps: number;
    picture: string;
    prequelTitle?: string;
    sequelTitle?: string;
}
