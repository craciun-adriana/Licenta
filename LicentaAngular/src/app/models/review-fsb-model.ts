import { Status } from "./status";

export interface ReviewFsbModel {
    idReview: string;
    idUser: string;
    username: string;
    idBook: string;
    idFilm: string;
    idSeries: string;
    grade: string;
    review: string;
    status: Status;

}
