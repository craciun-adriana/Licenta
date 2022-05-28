import { Component, OnInit } from '@angular/core';
import { interval } from 'rxjs';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-toolbar',
    templateUrl: './toolbar.component.html',
    styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {
    isLoggedIn = false;

    constructor(
        private licentaService: LicentaService
    ) { }

    ngOnInit(): void {
        interval(5000).subscribe(_ => {
            this.licentaService.isUserLoggedIn().subscribe(response => {
                this.isLoggedIn = (response !== "");
            });
        });
    }

}
