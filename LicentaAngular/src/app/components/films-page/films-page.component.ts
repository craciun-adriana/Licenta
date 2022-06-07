import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
        private router: Router
    ) { }

    ngOnInit(): void {
        this.initializeFilmPage();
    }

    private initializeFilmPage(): void {
        this.licentaService.getAllFilms().subscribe((response) => {
            this.films = response;
        })
    }

    getFilmByTitle(title: string): void {
        if (title != '') {
            this.licentaService.findFilmsByTitle(title).subscribe((response) => {
                this.films = response;
            });
        }
        else {
            this.initializeFilmPage();
        }
    }

    getFilmByGenre(event: any): void {
        const genre = event.target.value;
        if (genre !== '') {
            this.licentaService.findFilmsByGenre(genre).subscribe((response) => {
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
}
