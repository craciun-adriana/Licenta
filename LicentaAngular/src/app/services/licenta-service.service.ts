import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, EMPTY, map, Observable, of, pipe } from 'rxjs';
import { BookModel } from '../models/book-model';
import { LoginRequest } from '../models/login-request';

@Injectable({
    providedIn: 'root'
})
export class LicentaService {

    constructor(
        private http: HttpClient
    ) { }

    isUserLoggedIn(): Observable<boolean> {
        return this.http.get('licenta/auth/is-logged-in')
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

    loginUser(loginDetails: LoginRequest): Observable<boolean> {
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

    getAllAppointmens(): Observable<any> {
        return this.http.get('/licenta/appointment/get-appointment-for-user')
            .pipe(
                catchError(err => {
                    return of([]);
                })
            );
    }
}
