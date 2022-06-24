import { Component, OnInit } from '@angular/core';

import { Genre } from 'src/app/models/genre';
import { SeriesModel } from 'src/app/models/series-model';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-series-page',
    templateUrl: './series-page.component.html',
    styleUrls: ['./series-page.component.scss']
})
export class SeriesPageComponent implements OnInit {
    series: SeriesModel[] = [];

    constructor(
        private licentaService: LicentaService,
    ) { }

    ngOnInit(): void {
        this.initializeSeriesPage();
    }

    private initializeSeriesPage(): void {
        this.licentaService.getAllSeries().subscribe((response: SeriesModel[]) => {
            this.series = response;
        });
    }

    getSeriesByTitle(title: string): void {
        if (title) {
            this.licentaService.findSeriesByTitle(title).subscribe((response: SeriesModel[]) => {
                this.series = response;
            });
        }
        else {
            this.initializeSeriesPage();
        }
    }

    getSeriesByGenre(genre: Genre): void {
        if (genre) {
            this.licentaService.findSeriesByGenre(genre).subscribe((response: SeriesModel[]) => {
                this.series = response;
            });
        }
        else {
            this.initializeSeriesPage();
        }
    }

    genre(): typeof Genre {
        return Genre;
    }

    isValidUrl(urlToCheck: string): boolean {
        let url;

        try {
            url = new URL(urlToCheck);
        } catch (_) {
            return false;
        }

        return url.protocol === "http:" || url.protocol === "https:";
    }
}
