import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CreateSeriesModel } from 'src/app/models/series-model';
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
        relaseDate: new FormControl('', Validators.required),
        prequelId: new FormControl('',),
        sequelId: new FormControl('',),
        genre: new FormControl('', Validators.required),
        rating: new FormControl('', Validators.required),
        nrEps: new FormControl('', Validators.required),
        picture: new FormControl('', Validators.required),
    })

    errorMessage: string = '';

    constructor(
        private licentaService: LicentaService
    ) { }

    ngOnInit(): void {
    }

    addSeries(): void {
        const seriesDetails: CreateSeriesModel = {
            title: this.addSeriesForm.get('title')?.value,
            director: this.addSeriesForm.get('director')?.value,
            description: this.addSeriesForm.get('description')?.value,
            relaseDate: this.addSeriesForm.get('relaseDate')?.value,
            prequelId: this.addSeriesForm.get('prequelId')?.value,
            sequelId: this.addSeriesForm.get('seguelId')?.value,
            genre: this.addSeriesForm.get('genre')?.value,
            rating: this.addSeriesForm.get('rating')?.value,
            nrEps: this.addSeriesForm.get('nrEps')?.value,
            picture: this.addSeriesForm.get('picture')?.value,

        }
        this.licentaService.createSeries(seriesDetails).subscribe(response => {
            if (response !== null)
                this.errorMessage = "Series was created.";
            else this.errorMessage = 'Series can not be created.';
        })
    }
}
