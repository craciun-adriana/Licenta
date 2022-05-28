import { Status } from './status';
import { Genre } from './genre';
import { Rating } from './rating';

export interface ReviewFilmModele {
    idReview: string;
    idUser: string;
    idFilm: string;
    grade: number;
    review: string;
    status: Status;
    title: string;
    director: string;
    description: string;
    relaseDate: Date;
    prequeslId: string;
    sequelId: string;
    genre: Genre;
    rating: Rating;
    nEp: number;
    picture: string;
}
