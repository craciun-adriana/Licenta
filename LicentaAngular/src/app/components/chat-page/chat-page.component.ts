import { Component, OnInit } from '@angular/core';
import { CreateMessageModel, MessagesModel } from 'src/app/models/messages-model';
import { UserDetails } from 'src/app/models/user-details';
import { LicentaService } from 'src/app/services/licenta-service.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { GroupModel } from 'src/app/models/group-model';

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

}
