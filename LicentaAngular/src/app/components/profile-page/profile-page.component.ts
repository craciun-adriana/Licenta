import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CreateFriendshipModel } from 'src/app/models/friendship-model';
import { ReviewBookModel } from 'src/app/models/review-book-model';
import { ReviewFilmModel } from 'src/app/models/review-film-model';
import { ReviewSeriesModel } from 'src/app/models/review-series-model';
import { UserDetails } from 'src/app/models/user-details';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-profile-page',
    templateUrl: './profile-page.component.html',
    styleUrls: ['./profile-page.component.scss']
})
export class ProfilePageComponent implements OnInit {
    private userId: string = "";
    user: UserDetails | null = null;
    reviewBooks: ReviewBookModel[] = [];
    reviewFilms: ReviewFilmModel[] = [];
    reviewSeries: ReviewSeriesModel[] = [];

    constructor(
        private licentaService: LicentaService,
        private router: Router,
        ///ne ofera informatii despre ruta(url-ul) pe care suntem
        private activatedRoute: ActivatedRoute
    ) { }

    ngOnInit(): void {

        this.initializeProfile();
    }

    private initializeProfile(): void {

        this.userId = this.activatedRoute.snapshot.paramMap.get('id') ?? '';

        if (this.userId !== '') {

            this.licentaService.getUserById(this.userId).subscribe((response: UserDetails) => {
                if (response !== null) {

                    this.user = response;

                    this.licentaService.getReviewBookCompletedByIdUser(this.userId).subscribe((response: ReviewBookModel[]) => {
                        this.reviewBooks = response;
                    })

                    this.licentaService.getReviewFilmCompletedByIdUser(this.userId).subscribe((response: ReviewFilmModel[]) => {
                        this.reviewFilms = response;
                    })

                    this.licentaService.getReviewSeriesCompletedByIdUser(this.userId).subscribe((response: ReviewSeriesModel[]) => {
                        this.reviewSeries = response;
                    })

                } else {
                    this.router.navigate(['home']);
                }
            });
        }
        else {
            this.licentaService.isUserLoggedIn().subscribe((response: string) => {
                if (response !== "") {
                    this.licentaService.getUserById(response).subscribe((response: UserDetails) => {
                        if (response !== null) {
                            this.user = response;
                        }
                    });
                }
                else {
                    this.router.navigate(['login']);
                }
            })
        }
    }

    sendFriendshipRequest(idUser: string): void {

        const friendship: CreateFriendshipModel = {
            idReceiver: idUser
        }
        this.licentaService.sendFriendshipRequest(friendship);
    }

}
