import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
        private router: Router
    ) { }

    ngOnInit(): void {
        this.initializeSeriesPage();
    }

    private initializeSeriesPage(): void {
        this.licentaService.getAllSeries().subscribe((response) => {
            this.series = response;
        });
        
    }

    getSeriesByTitle(title: string): void {
        if (title != '') {
            this.licentaService.findSeriesByTitle(title).subscribe((response) => {
                this.series = response;
            });
        }
        else {
            this.initializeSeriesPage();
        }
    }

    getSeriesByGenre(event: any): void {
        const genre = event.target.value;
        if (genre !== '') {
            this.licentaService.findSeriesByGenre(genre).subscribe((response) => {
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
}
