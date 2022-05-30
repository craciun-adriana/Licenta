import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of } from 'rxjs';
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
                catchError(err => {
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
                catchError(err => {
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
                catchError(err => {
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
                catchError(err => {
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
                catchError(err => {
                    return of([]);
                })
            );
    }

    getAllFilms(): Observable<any> {
        return this.http.get('/licenta/film/get-all')
            .pipe(
                catchError(err => {
                    return of([]);
                })
            );
    }

    getAllSeries(): Observable<any> {
        return this.http.get('/licenta/series/get-all')
            .pipe(
                catchError(err => {
                    return of([]);
                })
            );
    }

    getAllAppointmensForUser(): Observable<any> {
        return this.http.get('/licenta/appointment/get-appointment-for-user')
            .pipe(
                catchError(err => {
                    return of([]);
                })
            );
    }

    getReviewBookByStatus(status: Status): Observable<any> {
        return this.http.get('/licenta/review-books/get-by-status/' + status)
            .pipe(
                catchError(err => {
                    return of([]);
                })
            );
    }

    getReviewFilmByStatus(status: Status): Observable<any> {
        return this.http.get('/licenta/review-films/get-by-status/' + status)
            .pipe(
                catchError(err => {
                    return of([]);
                })
            );
    }

    getReviewSeriesByStatus(status: Status): Observable<any> {
        return this.http.get('/licenta/review-series/get-by-status/' + status)
            .pipe(
                catchError(err => {
                    return of([]);
                })
            );
    }

    getLastConversationFosUser(): Observable<any> {
        return this.http.get('/licenta/message/conversation/5')
            .pipe(
                catchError(err => {
                    return of([]);
                })
            );
    }

    findUsersByUsername(userName: string): Observable<any> {
        return this.http.get('/licenta/user/find/' + userName)
            .pipe(
                catchError(err => {
                    return of([]);
                })
            );
    }

    findFriendsByUsername(userName: string): Observable<any> {
        return this.http.get('/licenta/user/find-friends/' + userName)
            .pipe(
                catchError(err => {
                    return of([]);
                })
            );
    }

    getAllMessagesBetweenUsers(otherId: string): Observable<any> {
        return this.http.get('/licenta/message/conversation/user/' + otherId)
            .pipe(
                catchError(err => {
                    return of([]);
                })
            );

    }

    getUserById(idUser: string): Observable<any> {
        return this.http.get('/licenta/user/get/' + idUser)
            .pipe(
                catchError(err => {
                    return of(null);
                })
            );
    }

    sendMessage(message: CreateMessageModel): Observable<any> {
        return this.http.post('/licenta/message/create', message)
            .pipe(
                catchError(err => {
                    return of(null);
                })
            )
    }

}
