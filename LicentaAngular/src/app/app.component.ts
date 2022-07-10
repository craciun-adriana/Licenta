import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, NavigationEnd, Router, RouterState } from '@angular/router';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent {

    constructor(
        router: Router,
        titleService: Title
    ) {
        router.events.subscribe(event => {
            if (event instanceof NavigationEnd) {
                let title = this.getTitle(router.routerState, router.routerState.root).join('-');
                title = title ? 'To REWatch - ' + title : 'To REWatch';
                titleService.setTitle(title);
            }
        });
    }

    private getTitle(state: any, parent: ActivatedRoute): string[] {
        var data = [];
        if (parent && parent.snapshot.data && parent.snapshot.data.title) {
            data.push(parent.snapshot.data.title);
        }

        if (state && parent) {
            data.push(... this.getTitle(state, state.firstChild(parent)));
        }
        return data;
    }
}
