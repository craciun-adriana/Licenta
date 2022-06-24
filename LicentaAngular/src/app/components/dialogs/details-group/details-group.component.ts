import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CreateGroupMemberModel } from 'src/app/models/group-member-model';
import { GroupModel } from 'src/app/models/group-model';
import { UserDetails } from 'src/app/models/user-details';
import { LicentaService } from 'src/app/services/licenta-service.service';

export interface DetailsGroupDialogData {
    groupId: string;
}

@Component({
    selector: 'app-details-group',
    templateUrl: './details-group.component.html',
    styleUrls: ['./details-group.component.scss']
})
export class DetailsGroupDialog {

    chatGroup?: GroupModel;
    groupMembers: UserDetails[] = [];
    userFriends: UserDetails[] = [];

    addGroupMemberForm = new FormGroup({
        idUser: new FormControl('', Validators.required)
    })
    constructor(
        @Inject(MAT_DIALOG_DATA) private data: DetailsGroupDialogData,
        private licentaService: LicentaService
    ) {
        this.initialize();
    }

    initialize(): void {
        this.licentaService.getGroupById(this.data.groupId).subscribe((response: GroupModel) => {
            this.chatGroup = response;
        });
        this.licentaService.getGroupMembersByIdGroup(this.data.groupId).subscribe((response: UserDetails[]) => {
            this.groupMembers = response;
        });
        this.licentaService.getFriendsForUser().subscribe((response: UserDetails[]) => {
            this.userFriends = response;
        });
    }

    addGroupMember(): void {
        const groupMember: CreateGroupMemberModel = {
            idGroup: this.chatGroup!.id,
            idUser: this.addGroupMemberForm.get('idUser')?.value.id,
            isAdmin: false,
        }

        this.licentaService.createGroupMember(groupMember).subscribe(_ => {
            this.initialize();
        });
    }

    friendDisplayFunction(friend: UserDetails): string {
        return friend.userName;
    }

}
