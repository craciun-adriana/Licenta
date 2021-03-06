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
    { path: 'home', component: HomePageComponent, data: { title: 'Home' } },
    { path: 'register', component: RegisterPageComponent, data: { title: 'Register' } },
    { path: 'login', component: LoginPageComponent, data: { title: 'Login' } },
    { path: 'logout', component: LogoutPageComponent, data: { title: 'Logout' } },
    { path: 'chat', component: ChatPageComponent, data: { title: 'Chat' } },
    { path: 'books', component: BooksPageComponent, data: { title: 'Books' } },
    { path: 'add-book', component: AddBookComponent, data: { title: 'Add book' } },
    { path: 'films', component: FilmsPageComponent, data: { title: 'Films' } },
    { path: 'add-film', component: AddFilmComponent, data: { title: 'Add film' } },
    { path: 'series', component: SeriesPageComponent, data: { title: 'Series' } },
    { path: 'add-series', component: AddSeriesComponent, data: { title: 'Add series' } },
    { path: 'friends', component: FriendsPageComponent, data: { title: 'Friends' } },
    { path: 'profile', component: ProfilePageComponent, data: { title: 'My Profile' } },
    { path: 'profile/:id', component: ProfilePageComponent, data: { title: 'Profile' } },
    { path: 'details/:type/:id', component: FsbDetailsPageComponent, data: { title: 'Details' } },
    { path: 'users', component: UsersComponent, data: { title: 'Users' } },
    { path: '**', redirectTo: '/home' },

]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
