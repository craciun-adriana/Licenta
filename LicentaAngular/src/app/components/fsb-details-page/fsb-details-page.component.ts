import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FsbDetailsModel } from 'src/app/models/fsb-details-model';
import { ReviewFsbModel } from 'src/app/models/review-fsb-model';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-fsb-details-page',
    templateUrl: './fsb-details-page.component.html',
    styleUrls: ['./fsb-details-page.component.scss']
})
export class FsbDetailsPageComponent implements OnInit {
    fsbDetails?: FsbDetailsModel;
    type: string = '';
    id: string = '';
    isBook: Boolean = false;
    isFilm: Boolean = false;
    isSeries: Boolean = false;

    reviews?: ReviewFsbModel[] = [];
    userReview?: ReviewFsbModel;

    isAdmin: boolean = false;

    //pt a apela functiile pt add review, fac swich nu if else
    constructor(
        private licentaService: LicentaService,
        private activatedRoute: ActivatedRoute,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.type = this.activatedRoute.snapshot.paramMap.get('type') ?? '';
        this.id = this.activatedRoute.snapshot.paramMap.get('id') ?? '';
        switch (this.type) {
            case 'book':
                this.isBook = true;
                break;
            case 'film':
                this.isFilm = true;
                break;
            case 'series':
                this.isSeries = true;
                break;
        };
        this.licentaService.isUserLoggedIn().subscribe(response => {
            this.isAdmin = response.isAdmin;
            this.initializeDetailsPage();
        })
    }

    private initializeDetailsPage(): void {

        if (this.type === "book") {
            this.licentaService.getDetailsAboutABook(this.id).subscribe((response: FsbDetailsModel) => {
                if (response === null) {
                    this.router.navigate(['books']);
                }
                this.fsbDetails = response;
            });
            this.licentaService.getReviewBookByIdBook(this.id).subscribe((response: ReviewFsbModel[]) => {
                this.reviews = response;
            });
            this.licentaService.getReviewBookByIdBookAndUser(this.id).subscribe((response: ReviewFsbModel) => {
                this.userReview = response;
            });
        }
        else if (this.type === "film") {
            this.licentaService.getDetailsAboutAFilm(this.id).subscribe((response: FsbDetailsModel) => {
                if (response === null) {
                    this.router.navigate(['films']);
                }
                this.fsbDetails = response;
            });
            this.licentaService.getReviewFilmByIdFilm(this.id).subscribe((response: ReviewFsbModel[]) => {
                this.reviews = response;
            });
            this.licentaService.getReviewFilmByIdFilmAndUser(this.id).subscribe((response: ReviewFsbModel) => {
                this.userReview = response;
            })
        }
        else if (this.type === "series") {
            this.licentaService.getDetailsAboutASeries(this.id).subscribe((response: FsbDetailsModel) => {
                if (response === null) {
                    this.router.navigate(['series']);
                }
                this.fsbDetails = response;
            });
            this.licentaService.getReviewSeriesByIdSeries(this.id).subscribe((response: ReviewFsbModel[]) => {
                this.reviews = response;
            });
            this.licentaService.getReviewSeriesByIdSeriesAndUser(this.id).subscribe((response: ReviewFsbModel) => {
                this.userReview = response;
            })
        }

    }

    public deleteFSB() {
        switch (this.type) {
            case 'book':
                this.licentaService.deleteBook(this.id).subscribe(_ => {
                    this.router.navigate(['books']);
                });
                break;
            case 'film':
                this.licentaService.deleteFilm(this.id).subscribe(_ => {
                    this.router.navigate(['films']);
                });
                break;
            case 'series':
                this.licentaService.deleteSeries(this.id).subscribe(_ => {
                    this.router.navigate(['series'])
                });
                break;
        }
    }
}
