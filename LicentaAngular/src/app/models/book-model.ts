import { Genre } from "./genre";

export interface BookModel {
    id: string;
    title: string;
    author: string;
    description: string;
    releaseDate: Date;
    prequelId: string;
    sequelId: string;
    genre: Genre;
    picture: string;
}
