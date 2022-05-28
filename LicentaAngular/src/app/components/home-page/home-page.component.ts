import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppointmentModel } from 'src/app/models/appointment-model';
import { BookModel } from 'src/app/models/book-model';
import { FilmModel } from 'src/app/models/film-model';
import { SeriesModel } from 'src/app/models/series-model';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-home-page',
    templateUrl: './home-page.component.html',
    styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {
    books: BookModel[] = [];
    films: FilmModel[] = [];
    serieses: SeriesModel[] = [];
    appointments: AppointmentModel[] = [];

    constructor(
        private licentaService: LicentaService,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.licentaService.isUserLoggedIn().subscribe(loggedIn => {
            if (!loggedIn) {
                this.router.navigate(['login']);
            } else {
                this.initializeTables();
            }
        });
    }

    private initializeTables(): void {
        this.licentaService.getAllBooks().subscribe((response: BookModel[]) => {
            this.books = response;
        });
        this.licentaService.getAllFilms().subscribe((response: FilmModel[]) => {
            this.films = response;
        });
        this.licentaService.getAllSeries().subscribe((response: SeriesModel[]) => {
            this.serieses = response;
        });
        this.licentaService.getAllAppointmensForUser().subscribe((response: AppointmentModel[]) => {
            this.appointments = response;
        });
    }
}
