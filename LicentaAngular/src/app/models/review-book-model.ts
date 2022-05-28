import { Status } from './status';
import { Genre } from './genre';

export interface ReviewBookModele {
    idReview: string;
    idUser: string;
    idBook: string;
    grade: number;
    review: string;
    status: Status;
    title: string;
    author: string;
    description: string;
    prequeslId: string;
    sequelId: string;
    genre: Genre;
    picture: string;
}
