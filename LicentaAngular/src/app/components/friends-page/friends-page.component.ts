import { Component, OnInit } from '@angular/core';
import { FriendshipModel } from 'src/app/models/friendship-model';
import { GroupModel } from 'src/app/models/group-model';
import { UserDetails } from 'src/app/models/user-details';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-friends-page',
    templateUrl: './friends-page.component.html',
    styleUrls: ['./friends-page.component.scss']
})
export class FriendsPageComponent implements OnInit {

    friendshipReq: FriendshipModel[] = [];
    friends: UserDetails[] = [];
    users: UserDetails[] = [];
    groups: GroupModel[] = [];

    constructor(
        private licentaservice: LicentaService
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
        })

        this.licentaservice.findUserGroups().subscribe((response: GroupModel[]) => {
            this.groups = response;
        })

    }

    acceptFriendship(idFriendship: string) {
        this.licentaservice.acceptFriendship(idFriendship).subscribe(response => {
            this.initializeFriendPage();
        })
    }

    findUserByUsername(username: string) {
        this.licentaservice.findUsersByUsername(username).subscribe((response: UserDetails[]) => {
            this.users = response;
        })
    }
}
