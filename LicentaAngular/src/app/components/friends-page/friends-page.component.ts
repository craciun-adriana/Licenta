import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { FriendshipModel } from 'src/app/models/friendship-model';
import { GroupModel } from 'src/app/models/group-model';
import { UserDetails } from 'src/app/models/user-details';
import { LicentaService } from 'src/app/services/licenta-service.service';
import { UsersGroupsSearchDialog } from '../dialogs/users-groups-search/users-groups-search.component';

@Component({
    selector: 'app-friends-page',
    templateUrl: './friends-page.component.html',
    styleUrls: ['./friends-page.component.scss']
})
export class FriendsPageComponent implements OnInit {
    friendshipReq: FriendshipModel[] = [];
    friends: UserDetails[] = [];
    groups: GroupModel[] = [];

    constructor(
        private licentaservice: LicentaService,
        private dialog: MatDialog
    ) { }

    ngOnInit(): void {
        this.initializeFriendPage();
    }

    private initializeFriendPage(): void {

        this.licentaservice.getFriendshipRequestByIdReceiver().subscribe((response: FriendshipModel[]) => {
            this.friendshipReq = response;
        });

        this.licentaservice.getFriendsForUser().subscribe((response: UserDetails[]) => {
            this.friends = response;
        });

        this.licentaservice.findUserGroups().subscribe((response: GroupModel[]) => {
            this.groups = response;
        });

    }

    acceptFriendship(idFriendship: string) {
        this.licentaservice.acceptFriendship(idFriendship).subscribe(_ => {
            this.initializeFriendPage();
        });
    }

    findUserByUsername(username: string) {
        this.licentaservice.findUsersByUsername(username).subscribe((response: UserDetails[]) => {
            if (response.length > 0) {
                this.dialog.open(UsersGroupsSearchDialog, {
                    data: {
                        users: response,
                        canRedirect: true
                    }
                });
            }
        });
    }

    isValidUrl(urlToCheck: string): boolean {
        let url;

        try {
            url = new URL(urlToCheck);
        } catch (_) {
            return false;
        }

        return url.protocol === "http:" || url.protocol === "https:";
    }
}
