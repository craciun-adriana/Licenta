import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppointmentModel } from 'src/app/models/appointment-model';
import { BookModel } from 'src/app/models/book-model';
import { FilmModel } from 'src/app/models/film-model';
import { ReviewBookModel } from 'src/app/models/review-book-model';
import { ReviewFilmModel } from 'src/app/models/review-film-model';
import { ReviewSeriesModel } from 'src/app/models/review-series-model';
import { SeriesModel } from 'src/app/models/series-model';
import { Status } from 'src/app/models/status';
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
    reviewBooks: ReviewBookModel[] = [];
    reviewFilms: ReviewFilmModel[] = [];
    reviewSeries: ReviewSeriesModel[] = [];
    reviewBooksO: ReviewBookModel[] = [];
    reviewFilmsO: ReviewFilmModel[] = [];
    reviewSeriesO: ReviewSeriesModel[] = [];


    constructor(
        private licentaService: LicentaService,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.licentaService.isUserLoggedIn().subscribe(loggedIn => {
            if (loggedIn === null) {
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
        this.licentaService.getReviewBookByStatus(Status.Planning).subscribe((response: ReviewBookModel[]) => {
            this.reviewBooks = response;
        });
        this.licentaService.getReviewFilmByStatus(Status.Planning).subscribe((response: ReviewFilmModel[]) => {
            this.reviewFilms = response;
        });
        this.licentaService.getReviewSeriesByStatus(Status.Planning).subscribe((response: ReviewSeriesModel[]) => {
            this.reviewSeries = response;
        });
        this.licentaService.getReviewBookByStatus(Status.Ongoing).subscribe((response: ReviewBookModel[]) => {
            this.reviewBooksO = response;
        });
        this.licentaService.getReviewFilmByStatus(Status.Ongoing).subscribe((response: ReviewFilmModel[]) => {
            this.reviewFilmsO = response;
        });
        this.licentaService.getReviewSeriesByStatus(Status.Ongoing).subscribe((response: ReviewSeriesModel[]) => {
            this.reviewSeriesO = response;
        });
    }
}
