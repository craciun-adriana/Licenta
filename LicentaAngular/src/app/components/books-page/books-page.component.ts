import { Component, OnInit } from '@angular/core';

import { BookModel } from 'src/app/models/book-model';
import { Genre } from 'src/app/models/genre';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-books-page',
    templateUrl: './books-page.component.html',
    styleUrls: ['./books-page.component.scss']
})
export class BooksPageComponent implements OnInit {
    books: BookModel[] = [];

    constructor(
        private licentaService: LicentaService,
    ) { }

    ngOnInit(): void {
        this.initializeBookPage();
    }

    private initializeBookPage(): void {
        this.licentaService.getAllBooks().subscribe((response: BookModel[]) => {
            this.books = response;
        });
    }

    getBookByTitle(title: string): void {
        if (title) {
            this.licentaService.findBooksByTitle(title).subscribe((response: BookModel[]) => {
                this.books = response;
            });
        }
        else {
            this.initializeBookPage();
        }
    }

    getBookByGenre(genre: Genre | 'Select'): void {
        if (genre !== 'Select') {
            this.licentaService.findBooksByGenre(genre).subscribe((response: BookModel[]) => {
                this.books = response;
            });
        }
        else {
            this.initializeBookPage();
        }
    }

    genre(): typeof Genre {
        return Genre;
    }

    isValidUrl(urlToCheck: string): boolean {
        let url;

        try {
            url = new URL(urlToCheck);
        } catch (_) {
            return false;
        }

        return url.protocol === "http:" || url.protocol === "https:";
    }
}
