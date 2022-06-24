import { Component, OnInit } from '@angular/core';

import { FilmModel } from 'src/app/models/film-model';
import { Genre } from 'src/app/models/genre';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-films-page',
    templateUrl: './films-page.component.html',
    styleUrls: ['./films-page.component.scss']
})
export class FilmsPageComponent implements OnInit {
    films: FilmModel[] = [];

    constructor(
        private licentaService: LicentaService,
    ) { }

    ngOnInit(): void {
        this.initializeFilmPage();
    }

    private initializeFilmPage(): void {
        this.licentaService.getAllFilms().subscribe((response: FilmModel[]) => {
            this.films = response;
        });
    }

    getFilmByTitle(title: string): void {
        if (title) {
            this.licentaService.findFilmsByTitle(title).subscribe((response: FilmModel[]) => {
                this.films = response;
            });
        }
        else {
            this.initializeFilmPage();
        }
    }

    getFilmByGenre(genre: Genre): void {
        if (genre) {
            this.licentaService.findFilmsByGenre(genre).subscribe((response: FilmModel[]) => {
                this.films = response;
            });
        }
        else {
            this.initializeFilmPage();
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
