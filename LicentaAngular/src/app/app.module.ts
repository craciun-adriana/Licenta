import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatNativeDateModule } from '@angular/material/core';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';

import {
    NgxMatDatetimePickerModule,
    NgxMatNativeDateModule,
    NgxMatTimepickerModule
} from '@angular-material-components/datetime-picker';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToolbarComponent } from './components/toolbar/toolbar.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { CommonModule } from '@angular/common';
import { HomePageComponent } from './components/home-page/home-page.component';
import { LicentaService } from './services/licenta-service.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LogoutPageComponent } from './components/logout-page/logout-page.component';
import { ChatPageComponent } from './components/chat-page/chat-page.component';
import { RegisterPageComponent } from './components/register-page/register-page.component';
import { ProfilePageComponent } from './components/profile-page/profile-page.component';
import { FriendsPageComponent } from './components/friends-page/friends-page.component';
import { BooksPageComponent } from './components/books-page/books-page.component';
import { FilmsPageComponent } from './components/films-page/films-page.component';
import { SeriesPageComponent } from './components/series-page/series-page.component';
import { StringToDatePipe } from './pipes/string-to-date.pipe';
import { FsbDetailsPageComponent } from './components/fsb-details-page/fsb-details-page.component';
import { AddBookComponent } from './components/add-book/add-book.component';
import { AddFilmComponent } from './components/add-film/add-film.component';
import { AddSeriesComponent } from './components/add-series/add-series.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
    declarations: [
        AppComponent,
        ToolbarComponent,
        LoginPageComponent,
        HomePageComponent,
        LogoutPageComponent,
        ChatPageComponent,
        RegisterPageComponent,
        ProfilePageComponent,
        FriendsPageComponent,
        BooksPageComponent,
        FilmsPageComponent,
        SeriesPageComponent,
        StringToDatePipe,
        FsbDetailsPageComponent,
        AddBookComponent,
        AddFilmComponent,
        AddSeriesComponent
    ],
    imports: [
        BrowserModule,
        CommonModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        BrowserAnimationsModule,
        MatAutocompleteModule,
        MatButtonModule,
        MatDatepickerModule,
        MatInputModule,
        NgxMatDatetimePickerModule,
        NgxMatNativeDateModule,
        NgxMatTimepickerModule,
        MatTooltipModule,
        MatNativeDateModule,
        MatSelectModule,
        MatCheckboxModule
    ],
    providers: [
        LicentaService
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
    bootstrap: [AppComponent]
})
export class AppModule { }
