import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BookModel } from 'src/app/models/book-model';
import { FilmModel } from 'src/app/models/film-model';
import { CreateFriendshipModel, FriendshipModel } from 'src/app/models/friendship-model';
import { FriendshipStatus } from 'src/app/models/friendship-status';
import { ReviewBookModel } from 'src/app/models/review-book-model';
import { ReviewFilmModel } from 'src/app/models/review-film-model';
import { ReviewSeriesModel } from 'src/app/models/review-series-model';
import { SeriesModel } from 'src/app/models/series-model';
import { Status } from 'src/app/models/status';
import { UserDetails } from 'src/app/models/user-details';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-profile-page',
    templateUrl: './profile-page.component.html',
    styleUrls: ['./profile-page.component.scss']
})
export class ProfilePageComponent implements OnInit {
    userId: string = "";
    user?: UserDetails;
    reviewBooks: ReviewBookModel[] = [];
    reviewFilms: ReviewFilmModel[] = [];
    reviewSeries: ReviewSeriesModel[] = [];
    friendshipStatus: string = '';
    idFriendship: string = "";

    statusBookForm = new FormGroup({
        status: new FormControl('', Validators.required),
    })

    userDetailsForm = new FormGroup({
        firstName: new FormControl('', Validators.required),
        lastName: new FormControl('', Validators.required),
        userName: new FormControl('', Validators.required),
        dateOfBirth: new FormControl('', Validators.required),
        sex: new FormControl('', Validators.required),
        description: new FormControl('', Validators.required),
        profilePicture: new FormControl('', Validators.required),
    })

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

                    this.licentaService.getReviewBookByStatusAndUserId(Status.Completed, this.userId).subscribe((response: ReviewBookModel[]) => {
                        this.reviewBooks = response;
                    })

                    this.licentaService.getReviewFilmByStatusAndUserId(Status.Completed, this.userId).subscribe((response: ReviewFilmModel[]) => {
                        this.reviewFilms = response;
                    })

                    this.licentaService.getReviewSeriesByStatusAndUserId(Status.Completed, this.userId).subscribe((response: ReviewSeriesModel[]) => {
                        this.reviewSeries = response;
                    })

                    this.updateFriendshipStatus();
                } else {
                    this.router.navigate(['home']);
                }
            });
        }
        else {
            this.licentaService.isUserLoggedIn().subscribe((response: any) => {
                if (response !== null) {
                    this.licentaService.getUserById(response.userId).subscribe((response: UserDetails) => {
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

    private updateFriendshipStatus(): void {
        this.licentaService.getFriendshipBetweenUsers(this.userId).subscribe((response: FriendshipModel) => {

            this.idFriendship = response?.id;
            if (response === null) {
                this.friendshipStatus = "not exist";
            }
            else if (response.status === FriendshipStatus.Accepted) {

                this.friendshipStatus = "friends";
            }
            else if (response.idSender === this.userId) {

                this.friendshipStatus = "received";
            }
            else {

                this.friendshipStatus = "sent";

            }
        })
    }

    sendFriendshipRequest(): void {

        const friendship: CreateFriendshipModel = {
            idReceiver: this.userId
        }
        this.licentaService.sendFriendshipRequest(friendship).subscribe(_ => {
            this.updateFriendshipStatus();
        });

    }

    deleteFriendship(): void {
        this.licentaService.deleteFriendship(this.idFriendship).subscribe(_ => {
            this.updateFriendshipStatus();
        });
    }

    acceptFriendship(): void {
        this.licentaService.acceptFriendship(this.idFriendship).subscribe(_ => {
            this.updateFriendshipStatus();
        });
    }

    filterReviews(status: Status): void {
        if (!this.user) {
            return;
        }

        this.licentaService.getReviewBookByStatusAndUserId(status, this.user.id).subscribe((response: ReviewBookModel[]) => {
            this.reviewBooks = response;
        })

        this.licentaService.getReviewFilmByStatusAndUserId(status, this.user.id).subscribe((response: ReviewFilmModel[]) => {
            this.reviewFilms = response;
        })

        this.licentaService.getReviewSeriesByStatusAndUserId(status, this.user.id).subscribe((response: ReviewSeriesModel[]) => {
            this.reviewSeries = response;
        })
    }

    deleteUser(): void {

        const deleteConfirmation = confirm("Are you sure you want to delete your account?");
        if (!deleteConfirmation) {
            return;
        }
        this.licentaService.deleteUser().subscribe(_ => {
            this.router.navigate(['login']);
        });
    }

    updateUser(): void {
        const updateUser: UserDetails = {
            userName: this.userDetailsForm.get('userName')?.value,
            firstName: this.userDetailsForm.get('firstName')?.value,
            lastName: this.userDetailsForm.get('lastName')?.value,
            description: this.userDetailsForm.get('description')?.value,
            dateOfBirth: this.userDetailsForm.get('dateOfBirth')?.value,
            sex: this.userDetailsForm.get('sex')?.value,
            profilePicture: this.userDetailsForm.get('profilePicture')?.value,
        }

        this.licentaService.updateUser(updateUser).subscribe(_ => {
            window.location.reload();
        })
    }
}
