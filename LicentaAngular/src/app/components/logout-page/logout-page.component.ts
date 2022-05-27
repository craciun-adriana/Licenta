import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-logout-page',
    templateUrl: './logout-page.component.html',
    styleUrls: ['./logout-page.component.scss']
})
export class LogoutPageComponent implements OnInit {

    constructor(
        private licentaService: LicentaService,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.licentaService.logoutUser().subscribe(_ => {
            this.router.navigate(['login']);
        })
    }
}
