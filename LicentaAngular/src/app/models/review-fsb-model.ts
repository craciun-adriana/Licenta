import { Status } from "./status";

export interface ReviewFsbModel {
    id: string;
    idUser: string;
    username: string;
    idBook: string;
    idFilm: string;
    idSeries: string;
    grade: string;
    review: string;
    status: Status;

}
