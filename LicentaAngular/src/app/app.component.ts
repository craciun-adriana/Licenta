import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LicentaService } from './services/licenta-service.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

    constructor(
        private licentaService: LicentaService,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.licentaService.isUserLoggedIn().subscribe(loggedIn => {
            if (!loggedIn) {
                this.router.navigate(['login'])
            }
        });
    }

}
