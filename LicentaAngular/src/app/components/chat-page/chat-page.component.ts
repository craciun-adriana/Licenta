import { Component, OnInit } from '@angular/core';
import { CreateMessageModel, MessagesModel } from 'src/app/models/messages-model';
import { UserDetails } from 'src/app/models/user-details';
import { LicentaService } from 'src/app/services/licenta-service.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CreateGroupModel, GroupModel } from 'src/app/models/group-model';
import { CreateGroupMemberModel, GroupMemberModel } from 'src/app/models/group-member-model';

@Component({
    selector: 'app-chat-page',
    templateUrl: './chat-page.component.html',
    styleUrls: ['./chat-page.component.scss']
})
export class ChatPageComponent implements OnInit {
    messages: MessagesModel[] = [];
    lastConversation: UserDetails[] = [];
    lastConversationG: GroupModel[] = [];
    userId: string = '';
    chatUser: UserDetails | null = null;
    chatGroup: GroupModel | null = null;
    foundUsers: UserDetails[] = [];
    foundGroups: GroupModel[] = [];

    isGroup: boolean = false;
    isCreatingGroup: boolean = false;
    groupMembers: UserDetails[] = [];
    userFriends: UserDetails[] = [];
    isOpenGroupDetails: boolean = false;
    addMember: boolean = false;

    createGroupForm = new FormGroup({
        name: new FormControl('', Validators.required),
        picture: new FormControl('',),
        description: new FormControl('',),
    })

    addGroupMemberForm = new FormGroup({
        idUser: new FormControl('', Validators.required)
    })

    constructor(
        private licentaService: LicentaService
    ) { }

    ngOnInit(): void {

        this.initializeChat();
    }

    private initializeChat(): void {
        this.licentaService.isUserLoggedIn().subscribe((response: any) => {
            this.userId = response?.userId ?? '';
        })
        this.licentaService.getLastUserConversationsForUser().subscribe((response: UserDetails[]) => {
            this.lastConversation = response;
        });
        this.licentaService.getLastGroupConversationsForUser().subscribe((response: GroupModel[]) => {
            this.lastConversationG = response;
        })
    }

    findFriendsByUsername(userName: string): void {
        this.licentaService.findFriendsByUsername(userName).subscribe((response: UserDetails[]) => {
            this.foundUsers = response;
        })
    }

    findUserGroupsByName(name: string): void {
        this.licentaService.findUserGroupsByName(name).subscribe((response: GroupModel[]) => {

            this.foundGroups = response;
        })
    }

    openChatWithUser(userId: string): void {
        this.isGroup = false;
        this.licentaService.getAllMessagesBetweenUsers(userId).subscribe((response: MessagesModel[]) => {
            this.messages = response;
        });
        this.licentaService.getUserById(userId).subscribe((response: UserDetails) => {
            this.chatUser = response;
        })
    }

    sendMessageToUser(messageText: string): void {
        if (this.chatUser === null) {
            return;
        }
        const message: CreateMessageModel = {
            idReceiver: this.chatUser.id,
            text: messageText
        }
        this.licentaService.sendMessage(message).subscribe(response => {
            this.openChatWithUser(message.idReceiver!);
        });
    }

    sendMessageToGroup(messageText: string): void {
        if (this.chatGroup === null) {
            return;
        }
        const message: CreateMessageModel = {
            idGroup: this.chatGroup.id,
            text: messageText
        }
        this.licentaService.sendMessage(message).subscribe(response => {
            this.openChatWithGroup(message.idGroup!);
        });
    }

    openChatWithGroup(groupId: string): void {
        this.isGroup = true;
        this.licentaService.getAllMessagesInGroup(groupId).subscribe((response: MessagesModel[]) => {
            this.messages = response;
        });

        this.licentaService.getGroupById(groupId).subscribe((response: GroupModel) => {
            this.chatGroup = response;
        })
    }

    startCreateGroup(): void {
        this.isCreatingGroup = true;
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
                idUser: 'da',
                isAdmin: true,
            }
            this.licentaService.createGroupMember(createGroupAdmin).subscribe();
        });
    }

    addGroupMember(): void {

        const groupMember: CreateGroupMemberModel = {
            idGroup: this.chatGroup!.id,
            idUser: this.addGroupMemberForm.get('idUser')?.value,
            isAdmin: false,
        }

        this.licentaService.createGroupMember(groupMember).subscribe();
    }

    openGroupDetails(): void {
        this.isOpenGroupDetails = true;
    }

    openAddGroupMember(): void {
        this.getUserFriends();
        this.addMember = true;
    }

    getGroupMembers(idGroup: string): void {
        this.licentaService.getGroupMembersByIdGroup(idGroup).subscribe((response: UserDetails[]) => {
            this.groupMembers = response;
        })
    }

    getUserFriends(): void {
        this.licentaService.getFriendsForUser().subscribe((response: UserDetails[]) => {
            this.userFriends = response;
        })
    }

    friendDisplayFunction(friend: UserDetails): string {
        return friend.userName;
    }



}
