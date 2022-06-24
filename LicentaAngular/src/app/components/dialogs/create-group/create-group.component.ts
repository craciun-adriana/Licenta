import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { CreateGroupMemberModel } from 'src/app/models/group-member-model';
import { CreateGroupModel, GroupModel } from 'src/app/models/group-model';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-create-group',
    templateUrl: './create-group.component.html',
    styleUrls: ['./create-group.component.scss']
})
export class CreateGroupDialog implements OnInit {

    createGroupForm = new FormGroup({
        name: new FormControl('', Validators.required),
        picture: new FormControl('',),
        description: new FormControl('',),
    })

    constructor(
        private dialogRef: MatDialogRef<CreateGroupDialog>,
        private licentaService: LicentaService
    ) { }

    ngOnInit(): void {
    }

    createGroup(): void {
        const createGroup: CreateGroupModel = {
            name: this.createGroupForm.get('name')?.value,
            picture: this.createGroupForm.get('picture')?.value,
            description: this.createGroupForm.get('description')?.value,
        }
        this.licentaService.createGroup(createGroup).subscribe((response: GroupModel) => {
            const createGroupAdmin: CreateGroupMemberModel = {
                idGroup: response.id,
                isAdmin: true,
            }
            this.licentaService.createGroupMember(createGroupAdmin).subscribe(_ => {
                this.close();
            });
        });
    }

    close(): void {
        this.dialogRef.close();
    }
}
