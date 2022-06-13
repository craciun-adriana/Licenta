import { Genre } from "./genre";

export interface BookModel {
    id: string;
    title: string;
    author: string;
    description: string;
    relaseDate: Date;
    prequelId?: string;
    sequelId?: string;
    genre: Genre;
    picture: string;
    prequelTitle?: string;
    sequelTitle?: string;
}

export interface CreateBookModel {
    title: string;
    author: string;
    description: string;
    relaseDate: Date;
    prequelId?: string;
    sequelId?: string;
    genre: Genre;
    picture: string;
}
