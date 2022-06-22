import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatPageComponent } from './components/chat-page/chat-page.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { LogoutPageComponent } from './components/logout-page/logout-page.component';
import { RegisterPageComponent } from './components/register-page/register-page.component';
import { BooksPageComponent } from './components/books-page/books-page.component';
import { FilmsPageComponent } from './components/films-page/films-page.component';
import { SeriesPageComponent } from './components/series-page/series-page.component';
import { FriendsPageComponent } from './components/friends-page/friends-page.component';
import { ProfilePageComponent } from './components/profile-page/profile-page.component';
import { FsbDetailsPageComponent } from './components/fsb-details-page/fsb-details-page.component';
import { AddBookComponent } from './components/add-book/add-book.component';
import { AddFilmComponent } from './components/add-film/add-film.component';
import { AddSeriesComponent } from './components/add-series/add-series.component';
import { UsersComponent } from './components/users/users.component';


const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomePageComponent },
    { path: 'register', component: RegisterPageComponent },
    { path: 'login', component: LoginPageComponent },
    { path: 'logout', component: LogoutPageComponent },
    { path: 'chat', component: ChatPageComponent },
    { path: 'books', component: BooksPageComponent },
    { path: 'add-book', component: AddBookComponent },
    { path: 'films', component: FilmsPageComponent },
    { path: 'add-film', component: AddFilmComponent },
    { path: 'series', component: SeriesPageComponent },
    { path: 'add-series', component: AddSeriesComponent },
    { path: 'friends', component: FriendsPageComponent },
    { path: 'profile', component: ProfilePageComponent },
    { path: 'profile/:id', component: ProfilePageComponent },
    { path: 'details/:type/:id', component: FsbDetailsPageComponent },
    { path: 'users', component: UsersComponent },
    { path: '**', redirectTo: '/home' },

]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
