import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';
import { CreateFriendshipModel } from '../models/friendship-model';
import { Genre } from '../models/genre';
import { LoginDetails } from '../models/login-details';
import { CreateMessageModel } from '../models/messages-model';
import { RegisterDetails } from '../models/register-details';
import { Status } from '../models/status';

@Injectable({
    providedIn: 'root'
})
export class LicentaService {

    constructor(
        private http: HttpClient
    ) { }

    isUserLoggedIn(): Observable<string> {
        return this.http.get('licenta/auth/is-logged-in')
            .pipe(
                catchError(error => {
                    return of(false);
                }),
                map((response: any) => {
                    if (response === false) {
                        return "";
                    }
                    return response.userId;
                })
            );
    }

    loginUser(loginDetails: LoginDetails): Observable<boolean> {
        return this.http.post('/licenta/auth/login', loginDetails)
            .pipe(
                catchError(error => {
                    return of(false);
                }),
                map(response => {
                    if (response === false) {
                        return false;
                    }
                    return true;
                })
            );
    }

    logoutUser(): Observable<any> {
        return this.http.post('/licenta/auth/logout', null)
            .pipe(
                catchError(error => {
                    return of(false);
                }),
                map(response => {
                    if (response === false) {
                        return false;
                    }
                    return true;
                })
            );
    }

    registerUser(registerDetails: RegisterDetails): Observable<any> {
        return this.http.post('/licenta/auth/register', registerDetails)
            .pipe(
                catchError(error => {
                    return of(false);
                }),
                map(response => {
                    if (response === false) {
                        return false;
                    }
                    return true;
                })
            );
    }

    getAllBooks(): Observable<any> {
        return this.http.get('/licenta/book/get-all')
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getAllFilms(): Observable<any> {
        return this.http.get('/licenta/film/get-all')
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getAllSeries(): Observable<any> {
        return this.http.get('/licenta/series/get-all')
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getAllAppointmensForUser(): Observable<any> {
        return this.http.get('/licenta/appointment/get-appointment-for-user')
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getReviewBookCompletedByIdUser(idUser: string): Observable<any> {
        return this.http.get('/licenta/review-book/get-completed-by-user/' + idUser)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getReviewFilmCompletedByIdUser(idUser: string): Observable<any> {
        return this.http.get('/licenta/review-film/get-completed-by-user/' + idUser)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getReviewSeriesCompletedByIdUser(idUser: string): Observable<any> {
        return this.http.get('/licenta/review-series/get-completed-by-user/' + idUser)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getReviewBookByStatus(status: Status): Observable<any> {
        return this.http.get('/licenta/review-books/get-by-status/' + status)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getReviewFilmByStatus(status: Status): Observable<any> {
        return this.http.get('/licenta/review-films/get-by-status/' + status)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getReviewSeriesByStatus(status: Status): Observable<any> {
        return this.http.get('/licenta/review-series/get-by-status/' + status)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getLastConversationsFosUser(): Observable<any> {
        return this.http.get('/licenta/message/conversation/5')
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    findUsersByUsername(userName: string): Observable<any> {
        return this.http.get('/licenta/user/find/' + userName)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    findFriendsByUsername(userName: string): Observable<any> {
        return this.http.get('/licenta/user/find-friends/' + userName)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getAllMessagesBetweenUsers(otherId: string): Observable<any> {
        return this.http.get('/licenta/message/conversation/user/' + otherId)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );

    }

    getUserById(idUser: string): Observable<any> {
        return this.http.get('/licenta/user/get/' + idUser)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            );
    }

    sendMessage(message: CreateMessageModel): Observable<any> {
        return this.http.post('/licenta/message/create', message)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }

    getDetailsAboutABook(idBook: string): Observable<any> {
        return this.http.get('licenta/book/get/' + idBook)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }

    getDetailsAboutAFilm(idFilm: string): Observable<any> {
        return this.http.get('licenta/film/get/' + idFilm)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }
    getDetailsAboutASeries(idSeries: string): Observable<any> {
        return this.http.get('licenta/series/get/' + idSeries)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }

    getReviewBookByIdBook(idBook: string): Observable<any> {
        return this.http.get('licenta/review-books/get-by-id-book/' + idBook)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            )

    }

    getReviewFilmByIdFilm(idFilm: string): Observable<any> {
        return this.http.get('licenta/review-films/get-by-id-film/' + idFilm)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            )

    }

    getReviewSeriesByIdSeries(idSeries: string): Observable<any> {
        return this.http.get('licenta/review-series/get-by-id-series/' + idSeries)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            )

    }

    getStatusByIdBookAndUser(idBook: string): Observable<any> {
        return this.http.get('licenta/review-books/get-by-id-book-and-user/' + idBook)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }

    getStatusByIdFilmAndUser(idFilm: string): Observable<any> {
        return this.http.get('licenta/review-films/get-by-id-film-and-user/' + idFilm)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }

    getStatusByIdSeriesAndUser(idSeries: string): Observable<any> {
        return this.http.get('licenta/review-series/get-by-id-series-and-user/' + idSeries)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }

    sendFriendshipRequest(friendship: CreateFriendshipModel): Observable<any> {
        return this.http.post('licenta/friendship/create', friendship)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }

    getFriendshipBetweenUsers(idUser: string): Observable<any> {
        return this.http.get('licenta/friendship/exist-friendship/' + idUser)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }

    findBooksByTitle(title: string): Observable<any> {
        return this.http.get('licenta/book/find-by-title/' + title)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )

    }

    findBooksByGenre(genre: Genre): Observable<any> {
        return this.http.get('licenta/book/find-by-genre/' + genre)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )

    }

    findFilmsByTitle(title: string): Observable<any> {
        return this.http.get('licenta/film/find-by-title/' + title)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )

    }

    findFilmsByGenre(genre: Genre): Observable<any> {
        return this.http.get('licenta/film/find-by-title/' + genre)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )

    }

    findSeriesByTitle(title: string): Observable<any> {
        return this.http.get('licenta/series/find-by-title/' + title)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )

    }

    findSeriesByGenre(genre: Genre): Observable<any> {
        return this.http.get('licenta/series/find-by-genre/' + genre)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )

    }
}
