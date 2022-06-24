import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

import { GroupModel } from 'src/app/models/group-model';
import { UserDetails } from 'src/app/models/user-details';

export interface UsersGroupsSearchDialogData {
    users: UserDetails[];
    groups: GroupModel[];
}

@Component({
    selector: 'app-users-groups-search',
    templateUrl: './users-groups-search.component.html',
    styleUrls: ['./users-groups-search.component.scss']
})
export class UsersGroupsSearchDialog {
    users: UserDetails[];
    groups: GroupModel[];

    constructor(
        @Inject(MAT_DIALOG_DATA) data: UsersGroupsSearchDialogData
    ) {
        this.users = data.users;
        this.groups = data.groups;
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
