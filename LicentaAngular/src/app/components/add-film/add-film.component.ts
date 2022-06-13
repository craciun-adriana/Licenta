import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CreateBookModel } from 'src/app/models/book-model';
import { CreateFilmModel } from 'src/app/models/film-model';
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
        relaseDate: new FormControl('', Validators.required),
        prequelId: new FormControl('',),
        sequelId: new FormControl('',),
        genre: new FormControl('', Validators.required),
        rating: new FormControl('', Validators.required),
        lenght: new FormControl('', Validators.required),
        picture: new FormControl('', Validators.required),
    })

    errorMessage: string = '';
    constructor(
        private licentaService: LicentaService
    ) { }

    ngOnInit(): void {

    }

    addFilm(): void {
        const filmDetails: CreateFilmModel = {
            title: this.addFilmForm.get('title')?.value,
            director: this.addFilmForm.get('director')?.value,
            description: this.addFilmForm.get('description')?.value,
            relaseDate: this.addFilmForm.get('relaseDate')?.value,
            prequelId: this.addFilmForm.get('prequelId')?.value,
            sequelId: this.addFilmForm.get('seguelId')?.value,
            genre: this.addFilmForm.get('genre')?.value,
            rating: this.addFilmForm.get('rating')?.value,
            length: this.addFilmForm.get('length')?.value,
            picture: this.addFilmForm.get('picture')?.value,

        }
        this.licentaService.createFilm(filmDetails).subscribe(response => {
            if (response !== null)
                this.errorMessage = "Film was created.";
            else this.errorMessage = 'Series can not be created.';
        })
    }
}
