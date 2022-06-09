import { Component, OnInit } from '@angular/core';
import { FriendshipModel } from 'src/app/models/friendship-model';
import { UserDetails } from 'src/app/models/user-details';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-friends-page',
    templateUrl: './friends-page.component.html',
    styleUrls: ['./friends-page.component.scss']
})
export class FriendsPageComponent implements OnInit {
    friends: FriendshipModel[] = [];
    users: UserDetails[] = [];
    constructor(
        private licentaservice: LicentaService
    ) { }

    ngOnInit(): void {
        this.initializeFriendPage();
    }

    private initializeFriendPage(): void {

        this.licentaservice.getFriendshipRequestByIdReceiver().subscribe((response: FriendshipModel[]) => {
            this.friends = response;
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
