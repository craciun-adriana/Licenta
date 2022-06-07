import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
        private router: Router
    ) { }

    ngOnInit(): void {
        this.initializeBookPage();
    }

    private initializeBookPage(): void {
        this.licentaService.getAllBooks().subscribe((response) => {
            this.books = response;
        })
    }

    getBookByTitle(title: string): void {
        if (title != '') {
            this.licentaService.findBooksByTitle(title).subscribe((response) => {
                this.books = response;
            });
        }
        else {
            this.initializeBookPage();
        }
    }

    getBookByGenre(event: any): void {
        const genre = event.target.value;
        if (genre !== '') {
            this.licentaService.findBooksByGenre(genre).subscribe((response) => {
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
}
