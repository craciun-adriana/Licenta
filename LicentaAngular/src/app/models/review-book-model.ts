import { Status } from './status';
import { Genre } from './genre';

export interface ReviewBookModel {
    idReview: string;
    idUser: string;
    username: string;
    idBook: string;
    grade: number;
    review: string;
    status: Status;
    book: {
        title: string;
        author: string;
        description: string;
        relaseDate: string
        prequeslId: string;
        sequelId: string;
        genre: Genre;
        picture: string;
    }
}
