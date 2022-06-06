import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookModel } from 'src/app/models/book-model';
import { FilmModel } from 'src/app/models/film-model';
import { SeriesModel } from 'src/app/models/series-model';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-fsb-details-page',
    templateUrl: './fsb-details-page.component.html',
    styleUrls: ['./fsb-details-page.component.scss']
})
export class FsbDetailsPageComponent implements OnInit {
    book?: BookModel;
    film?: FilmModel;
    series?: SeriesModel;
    type: string = '';
    id: string = '';

    constructor(
        private licentaService: LicentaService,
        private activatedRoute: ActivatedRoute
    ) { }

    ngOnInit(): void {
        this.type = this.activatedRoute.snapshot.paramMap.get('type') ?? '';
        this.id = this.activatedRoute.snapshot.paramMap.get('id') ?? '';
    }

    private initializeDetailsPage(): void {
        if (this.type === "book") {
            this.licentaService.getDetailsAboutABook(this.id).subscribe((response: BookModel) => {
                this.book = response;
            })
        }
        else if (this.type === "film") {
            this.licentaService.getDetailsAboutAFilm(this.id).subscribe((response: FilmModel) => {
                this.film = response;
            })
        }
        else if (this.type === "series") {
            this.licentaService.getDetailsAboutASeries(this.id).subscribe((response: SeriesModel) => {
                this.series = response;
            })
        }
        //this.licentaService.
    }
}
