import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { CreateFilmModel, FilmModel } from 'src/app/models/film-model';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-add-film',
    templateUrl: './add-film.component.html',
    styleUrls: ['./add-film.component.scss']
})
export class AddFilmComponent implements OnInit {
    addFilmForm = new FormGroup({
        title: new FormControl('', Validators.required),
        director: new FormControl('', Validators.required),
        description: new FormControl('', Validators.required),
        releaseDate: new FormControl('', Validators.required),
        prequelId: new FormControl(''),
        sequelId: new FormControl(''),
        genre: new FormControl('', Validators.required),
        rating: new FormControl('', Validators.required),
        length: new FormControl('', Validators.required),
        picture: new FormControl('', Validators.required),
    });

    films: FilmModel[] = [];
    errorMessage: string = '';

    constructor(
        private licentaService: LicentaService
    ) { }

    ngOnInit(): void {
        this.initializePage();
    }

    private initializePage(): void {
        this.licentaService.getAllFilms().subscribe((response: FilmModel[]) => {
            this.films = response;
        });
    }

    addFilm(): void {
        const filmDetails: CreateFilmModel = {
            title: this.addFilmForm.get('title')?.value,
            director: this.addFilmForm.get('director')?.value,
            description: this.addFilmForm.get('description')?.value,
            relaseDate: this.addFilmForm.get('releaseDate')?.value,
            prequelId: this.addFilmForm.get('prequelId')?.value.id,
            sequelId: this.addFilmForm.get('sequelId')?.value.id,
            genre: this.addFilmForm.get('genre')?.value,
            rating: this.addFilmForm.get('rating')?.value,
            length: this.addFilmForm.get('length')?.value,
            picture: this.addFilmForm.get('picture')?.value,
        };

        this.licentaService.createFilm(filmDetails).subscribe(response => {
            if (response !== null) {
                this.errorMessage = 'Film was created.';
            }
            else {
                this.errorMessage = 'Film can not be created.';
            }
        });
    }

    filmDisplayFunction(film: FilmModel): string {
        return film.title;
    }
}
