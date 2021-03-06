import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BookModel } from 'src/app/models/book-model';
import { FilmModel } from 'src/app/models/film-model';
import { FsbDetailsModel } from 'src/app/models/fsb-details-model';
import { ReviewFsbModel } from 'src/app/models/review-fsb-model';
import { SeriesModel } from 'src/app/models/series-model';
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
    entity: FsbDetailsModel[] = [];

    reviews: ReviewFsbModel[] = [];
    userReview?: ReviewFsbModel;
    displayedColumns: string[] = ['username', 'grade', 'review'];

    isAdmin: boolean = false;
    errormessage: string = '';

    book: BookModel[] = [];
    film: FilmModel[] = [];
    series: SeriesModel[] = [];

    updateForm = new FormGroup({
        title: new FormControl('', Validators.required),
        author: new FormControl('', Validators.required),
        director: new FormControl('', Validators.required),
        description: new FormControl('', Validators.required),
        releaseDate: new FormControl('', Validators.required),
        prequelId: new FormControl('',),
        sequelId: new FormControl('',),
        picture: new FormControl('', Validators.required),
        genre: new FormControl('', Validators.required),
        rating: new FormControl('', Validators.required),
        length: new FormControl('', Validators.required),
        nrEps: new FormControl('', Validators.required),
    })

    userReviewForm = new FormGroup({
        grade: new FormControl('', Validators.required),
        review: new FormControl('', Validators.required),
        status: new FormControl('', Validators.required)
    })

    //pt a apela functiile pt add review, fac swich nu if else
    constructor(
        private licentaService: LicentaService,
        private activatedRoute: ActivatedRoute,
        private router: Router,
        private datePipe: DatePipe
    ) {
        this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    }

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
            if (this.isAdmin) {
                this.displayedColumns.push('delete');
            }
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
                this.updateFormValues();
            });
            this.licentaService.getReviewBookByIdBook(this.id).subscribe((response: ReviewFsbModel[]) => {
                this.reviews = response;
            });
            this.licentaService.getReviewBookByIdBookAndUser(this.id).subscribe((response: ReviewFsbModel) => {
                this.userReview = response;
                this.updateUserReviewForm();
            });
            this.licentaService.getAllBooks().subscribe((response: FsbDetailsModel[]) => {
                this.entity = response;
            })
        }
        else if (this.type === "film") {
            this.licentaService.getDetailsAboutAFilm(this.id).subscribe((response: FsbDetailsModel) => {
                if (response === null) {
                    this.router.navigate(['films']);
                }
                this.fsbDetails = response;
                this.updateFormValues();
            });
            this.licentaService.getReviewFilmByIdFilm(this.id).subscribe((response: ReviewFsbModel[]) => {
                this.reviews = response;
            });
            this.licentaService.getReviewFilmByIdFilmAndUser(this.id).subscribe((response: ReviewFsbModel) => {
                this.userReview = response;
                this.updateUserReviewForm();
            });
            this.licentaService.getAllFilms().subscribe((response: FsbDetailsModel[]) => {
                this.entity = response;
            })
        }
        else if (this.type === "series") {
            this.licentaService.getDetailsAboutASeries(this.id).subscribe((response: FsbDetailsModel) => {
                if (response === null) {
                    this.router.navigate(['series']);
                }
                this.fsbDetails = response;
                this.updateFormValues();
            });
            this.licentaService.getReviewSeriesByIdSeries(this.id).subscribe((response: ReviewFsbModel[]) => {
                this.reviews = response;
            });
            this.licentaService.getReviewSeriesByIdSeriesAndUser(this.id).subscribe((response: ReviewFsbModel) => {
                this.userReview = response;
                this.updateUserReviewForm();
            });
            this.licentaService.getAllSeries().subscribe((response: FsbDetailsModel[]) => {
                this.entity = response;
            })
        }
    }

    private updateFormValues() {
        this.updateForm.patchValue({
            title: this.fsbDetails?.title,
            author: this.fsbDetails?.author,
            director: this.fsbDetails?.director,
            description: this.fsbDetails?.description,
            releaseDate: this.datePipe.transform(this.fsbDetails?.relaseDate, 'yyyy-MM-dd'),
            prequelId: {
                id: this.fsbDetails?.prequelID,
                title: this.fsbDetails?.prequelTitle
            },
            sequelId: {
                id: this.fsbDetails?.sequelID,
                title: this.fsbDetails?.sequelTitle
            },
            picture: this.fsbDetails?.picture,
            genre: this.fsbDetails?.genre,
            rating: this.fsbDetails?.rating,
            length: this.fsbDetails?.length,
            nrEps: this.fsbDetails?.nrEps,
        });
    }

    private updateUserReviewForm() {
        this.userReviewForm.patchValue({
            grade: this.userReview?.grade ?? 0,
            review: this.userReview?.review,
            status: this.userReview?.status
        })
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

    public updateFSB() {
        const updateDetails: FsbDetailsModel = {
            id: this.fsbDetails!.id,
            title: this.updateForm.get('title')?.value,
            author: this.updateForm.get('author')?.value,
            director: this.updateForm.get('director')?.value,
            description: this.updateForm.get('description')?.value,
            relaseDate: this.updateForm.get('releaseDate')?.value,
            prequelID: this.updateForm.get('prequelId')?.value?.id,
            sequelID: this.updateForm.get('sequelId')?.value?.id,
            picture: this.updateForm.get('picture')?.value,
            genre: this.updateForm.get('genre')?.value,
            rating: this.updateForm.get('rating')?.value,
            length: this.updateForm.get('length')?.value,
            nrEps: this.updateForm.get('nrEps')?.value,
        }
        switch (this.type) {
            case 'book':
                this.licentaService.updateBook(updateDetails).subscribe(_ => {
                    window.location.reload();
                })
                break;
            case 'film':
                this.licentaService.updateFilm(updateDetails).subscribe(_ => {
                    window.location.reload();
                })
                break;
            case 'series':
                this.licentaService.updateSeries(updateDetails).subscribe(_ => {
                    window.location.reload();
                })
                break;
        }
    }

    fsbDisplayFunction(fsb: any): string {
        return fsb?.title;
    }

    saveReview(): void {
        const userReviewDetails = {
            idResource: this.fsbDetails?.id,
            grade: this.userReviewForm.get('grade')?.value,
            review: this.userReviewForm.get('review')?.value,
            status: this.userReviewForm.get('status')?.value,
        };

        const type = this.isBook ? "books" : this.isFilm ? "films" : "series";

        this.licentaService.createOrUpdateReview(userReviewDetails, type).subscribe(_ => {
            this.initializeDetailsPage();
        })
    }

    deleteReview(idReview: string) {
        const type = this.isBook ? "books" : this.isFilm ? "films" : "series";
        this.licentaService.deleteReview(idReview, type).subscribe(_ => {
            this.initializeDetailsPage();
        });
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
