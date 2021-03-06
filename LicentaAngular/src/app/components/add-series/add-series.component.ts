import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { CreateSeriesModel, SeriesModel } from 'src/app/models/series-model';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-add-series',
    templateUrl: './add-series.component.html',
    styleUrls: ['./add-series.component.scss']
})
export class AddSeriesComponent implements OnInit {
    addSeriesForm = new FormGroup({
        title: new FormControl('', Validators.required),
        director: new FormControl('', Validators.required),
        description: new FormControl('', Validators.required),
        releaseDate: new FormControl('', Validators.required),
        prequelId: new FormControl(''),
        sequelId: new FormControl(''),
        genre: new FormControl('', Validators.required),
        rating: new FormControl('', Validators.required),
        nrEps: new FormControl('', Validators.required),
        picture: new FormControl('', Validators.required),
    });

    serieses: SeriesModel[] = [];
    errorMessage: string = '';

    constructor(
        private licentaService: LicentaService
    ) { }

    ngOnInit(): void {
        this.initializePage();
    }

    private initializePage(): void {
        this.licentaService.getAllSeries().subscribe((response: SeriesModel[]) => {
            this.serieses = response;
        });
    }

    addSeries(): void {
        const seriesDetails: CreateSeriesModel = {
            title: this.addSeriesForm.get('title')?.value,
            director: this.addSeriesForm.get('director')?.value,
            description: this.addSeriesForm.get('description')?.value,
            relaseDate: this.addSeriesForm.get('releaseDate')?.value,
            prequelId: this.addSeriesForm.get('prequelId')?.value,
            sequelId: this.addSeriesForm.get('sequelId')?.value,
            genre: this.addSeriesForm.get('genre')?.value,
            rating: this.addSeriesForm.get('rating')?.value,
            nrEps: this.addSeriesForm.get('nrEps')?.value,
            picture: this.addSeriesForm.get('picture')?.value,
        };

        this.licentaService.createSeries(seriesDetails).subscribe(response => {
            if (response !== null) {
                this.errorMessage = 'Series was created.';
            }
            else {
                this.errorMessage = 'Series can not be created.';
            }
        });
    }

    seriesDisplayFunction(series: SeriesModel): string {
        return series.title;
    }
}
