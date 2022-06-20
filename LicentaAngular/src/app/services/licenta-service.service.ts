import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ok } from 'assert';
import { catchError, map, Observable, of } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';
import { CreateAppointmentModel } from '../models/appointment-model';
import { CreateBookModel } from '../models/book-model';
import { CreateFilmModel } from '../models/film-model';
import { CreateFriendshipModel } from '../models/friendship-model';
import { FsbDetailsModel } from '../models/fsb-details-model';
import { Genre } from '../models/genre';
import { CreateGroupMemberModel } from '../models/group-member-model';
import { CreateGroupModel } from '../models/group-model';
import { LoginDetails } from '../models/login-details';
import { CreateMessageModel } from '../models/messages-model';
import { RegisterDetails } from '../models/register-details';
import { CreateSeriesModel } from '../models/series-model';
import { Status } from '../models/status';
import { UserDetails } from '../models/user-details';

@Injectable({
    providedIn: 'root'
})
export class LicentaService {

    constructor(
        private http: HttpClient
    ) { }

    isUserLoggedIn(): Observable<any> {
        return this.http.get('/licenta/auth/is-logged-in')
            .pipe(
                catchError(error => {
                    return of(null);
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

    deleteUser(): Observable<any> {
        return this.http.delete('/licenta/user/delete')
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }

    createBook(book: CreateBookModel): Observable<any> {
        return this.http.post('/licenta/book/create', book)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            );
    }

    createFilm(film: CreateFilmModel): Observable<any> {
        return this.http.post('/licenta/film/create', film)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            );
    }

    createSeries(series: CreateSeriesModel): Observable<any> {
        return this.http.post('/licenta/series/create', series)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            );
    }

    deleteBook(idBook: string): Observable<any> {
        return this.http.delete('licenta/book/delete/' + idBook)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }

    deleteFilm(idFilm: string): Observable<any> {
        return this.http.delete('licenta/film/delete/' + idFilm)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }

    deleteSeries(idSeries: string): Observable<any> {
        return this.http.delete('licenta/series/delete/' + idSeries)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }

    updateBook(updateDetails: FsbDetailsModel): Observable<any> {
        return this.http.post('licenta/book/update', updateDetails)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            );
    }

    updateFilm(updateDetails: FsbDetailsModel): Observable<any> {
        return this.http.post('/licenta/film/update', updateDetails)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            );
    }

    updateSeries(updateDetails: FsbDetailsModel): Observable<any> {
        return this.http.post('licenta/series/update', updateDetails)
            .pipe(
                catchError(error => {
                    return of(null);
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

    getAllBooks(): Observable<any> {
        return this.http.get('/licenta/book/get-all')
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

    createAppointment(appointment: CreateAppointmentModel): Observable<any> {
        return this.http.post('/licenta/appointment/create', appointment)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }

    getReviewBookByStatus(status: Status): Observable<any> {
        return this.http.get(`/licenta/review-books/get-by-status/${status}`)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getReviewFilmByStatus(status: Status): Observable<any> {
        return this.http.get(`/licenta/review-films/get-by-status/${status}`)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getReviewSeriesByStatus(status: Status): Observable<any> {
        return this.http.get(`/licenta/review-series/get-by-status/${status}`)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getReviewBookByStatusAndUserId(status: Status, idUser: string): Observable<any> {
        return this.http.get(`/licenta/review-books/get-by-status/${status}/${idUser}`)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getReviewFilmByStatusAndUserId(status: Status, idUser: string): Observable<any> {
        return this.http.get(`/licenta/review-films/get-by-status/${status}/${idUser}`)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getReviewSeriesByStatusAndUserId(status: Status, idUser: string): Observable<any> {
        return this.http.get(`/licenta/review-series/get-by-status/${status}/${idUser}`)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getLastUserConversationsForUser(): Observable<any> {
        return this.http.get('/licenta/message/conversation/50')
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    getLastGroupConversationsForUser(): Observable<any> {
        return this.http.get('/licenta/message/conversation/g/50')
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    sendMessage(message: CreateMessageModel): Observable<any> {
        return this.http.post('/licenta/message/create', message)
            .pipe(
                catchError(error => {
                    return of(null);
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

    getAllMessagesInGroup(idGroup: string): Observable<any> {
        return this.http.get('/licenta/message/conversation/group/' + idGroup)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            );
    }

    createGroup(group: CreateGroupModel): Observable<any> {
        return this.http.post('/licenta/group/create', group)
            .pipe(catchError(error => {
                return of(null);
            }))
    }

    createGroupMember(groupMember: CreateGroupMemberModel): Observable<any> {
        return this.http.post('/licenta/group-member/create', groupMember)
            .pipe(catchError(error => {
                return of(null);
            }))
    }

    getGroupMembersByIdGroup(idGroup: string): Observable<any> {
        return this.http.get('/licenta/group-member/get-members/' + idGroup)
            .pipe(catchError(error => {
                return of(null);
            }))
    }

    getGroupById(idGroup: string): Observable<any> {
        return this.http.get('/licenta/group/get/' + idGroup)
            .pipe(catchError(error => {
                return of(null);
            }))
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

    findUserGroups(): Observable<any> {
        return this.http.get('/licenta/group/find-by-user')
            .pipe(
                catchError(error => {
                    return of([]);
                })
            )
    }

    findUserGroupsByName(name: string): Observable<any> {
        return this.http.get('/licenta/group/find-by-name/' + name)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            )
    }

    getUserById(idUser: string): Observable<any> {
        return this.http.get('/licenta/user/get/' + idUser)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            );
    }

    getDetailsAboutABook(idBook: string): Observable<any> {
        return this.http.get('licenta/book/get/' + idBook)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            );
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

    getReviewBookByIdBookAndUser(idBook: string): Observable<any> {
        return this.http.get('licenta/review-books/get-by-id-book-and-user/' + idBook)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            )
    }

    getReviewFilmByIdFilmAndUser(idFilm: string): Observable<any> {
        return this.http.get('licenta/review-films/get-by-id-film-and-user/' + idFilm)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            )
    }

    getReviewSeriesByIdSeriesAndUser(idSeries: string): Observable<any> {
        return this.http.get('licenta/review-series/get-by-id-series-and-user/' + idSeries)
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

    getFriendshipRequestByIdReceiver(): Observable<any> {
        return this.http.get('licenta/friendship/friendship-request-for-user')
            .pipe(
                catchError(error => {
                    return of([]);
                })
            )
    }

    acceptFriendship(idFriendship: string): Observable<any> {
        return this.http.post('licenta/friendship/accept-friendship/' + idFriendship, null)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }

    deleteFriendship(idFriendship: string): Observable<any> {
        return this.http.post('licenta/friendship/delete/' + idFriendship, null)
            .pipe(
                catchError(error => {
                    return of(null);
                })
            )
    }

    getFriendsForUser(): Observable<any> {
        return this.http.get('licenta/friendship/user-friends')
            .pipe(
                catchError(error => {
                    return of([]);
                })
            )
    }

    findBooksByTitle(title: string): Observable<any> {
        return this.http.get('licenta/book/find-by-title/' + title)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            )

    }

    findBooksByGenre(genre: Genre): Observable<any> {
        return this.http.get('licenta/book/find-by-genre/' + genre)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            )

    }

    findFilmsByTitle(title: string): Observable<any> {
        return this.http.get('licenta/film/find-by-title/' + title)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            )

    }

    findFilmsByGenre(genre: Genre): Observable<any> {
        return this.http.get('licenta/film/find-by-title/' + genre)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            )

    }

    findSeriesByTitle(title: string): Observable<any> {
        return this.http.get('licenta/series/find-by-title/' + title)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            )

    }

    findSeriesByGenre(genre: Genre): Observable<any> {
        return this.http.get('licenta/series/find-by-genre/' + genre)
            .pipe(
                catchError(error => {
                    return of([]);
                })
            )

    }

}
