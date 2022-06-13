import { Component, OnInit } from '@angular/core';
import { interval, Subscription, timer } from 'rxjs';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-toolbar',
    templateUrl: './toolbar.component.html',
    styleUrls: ['./toolbar.component.scss']
})
export class ToolbarComponent implements OnInit {
    isLoggedIn = false;
    isAdmin = false;
    subscriptions: Subscription = new Subscription();

    constructor(
        private licentaService: LicentaService
    ) { }

    ngOnInit(): void {
        this.initToolbar();
    }

    initToolbar() {
        this.subscriptions.unsubscribe();
        this.subscriptions = new Subscription();

        var subscription = timer(0, 5000).subscribe(_ => {
            this.licentaService.isUserLoggedIn().subscribe(response => {
                if (response !== null) {
                    this.isLoggedIn = true;
                    this.isAdmin = response.isAdmin;
                }
                else {
                    this.isLoggedIn = false;
                    this.isAdmin = false;
                }
            });
        });

        this.subscriptions.add(subscription);
    }
}
