import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NavigationStart, Router, RouterEvent } from '@angular/router';
import { tap, first } from 'rxjs';

import { GroupModel } from 'src/app/models/group-model';
import { UserDetails } from 'src/app/models/user-details';

export interface UsersGroupsSearchDialogData {
    users: UserDetails[];
    groups: GroupModel[];
    canRedirect: boolean;
}

@Component({
    selector: 'app-users-groups-search',
    templateUrl: './users-groups-search.component.html',
    styleUrls: ['./users-groups-search.component.scss']
})
export class UsersGroupsSearchDialog {
    users: UserDetails[];
    groups: GroupModel[];
    canRedirect = false;

    constructor(
        private dialogRef: MatDialogRef<UsersGroupsSearchDialog>,
        private router: Router,
        @Inject(MAT_DIALOG_DATA) data: UsersGroupsSearchDialogData
    ) {
        this.users = data.users;
        this.groups = data.groups;
        this.canRedirect = data.canRedirect;
    }

    redirectToUser(id: string): void {
        if (this.canRedirect) {
            this.dialogRef.afterClosed().pipe(
                tap(() => this.router.navigate([`/profile/${id}`])),
                first()
            ).subscribe();
            this.dialogRef.close();
        }
    }

    isValidUrl(urlToCheck?: string): boolean {
        let url;

        if (!urlToCheck) {
            return false;
        }

        try {
            url = new URL(urlToCheck);
        } catch (_) {
            return false;
        }

        return url.protocol === "http:" || url.protocol === "https:";
    }
}
