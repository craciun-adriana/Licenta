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
import { SettingsPageComponent } from './components/settings-page/settings-page.component';
import { FsbDetailsPageComponent } from './components/fsb-details-page/fsb-details-page.component';


const routes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomePageComponent },
    { path: 'register', component: RegisterPageComponent },
    { path: 'login', component: LoginPageComponent },
    { path: 'logout', component: LogoutPageComponent },
    { path: 'chat', component: ChatPageComponent },
    { path: 'books', component: BooksPageComponent },
    { path: 'films', component: FilmsPageComponent },
    { path: 'series', component: SeriesPageComponent },
    { path: 'friends', component: FriendsPageComponent },
    { path: 'profile', component: ProfilePageComponent },
    { path: 'profile/:id', component: ProfilePageComponent },
    { path: 'details/:type/:id', component: FsbDetailsPageComponent }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
