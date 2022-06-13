import { Component, OnInit } from '@angular/core';
import { CreateMessageModel, MessagesModel } from 'src/app/models/messages-model';
import { UserDetails } from 'src/app/models/user-details';
import { LicentaService } from 'src/app/services/licenta-service.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'app-chat-page',
    templateUrl: './chat-page.component.html',
    styleUrls: ['./chat-page.component.scss']
})
export class ChatPageComponent implements OnInit {
    messages: MessagesModel[] = [];
    lastConversation: UserDetails[] = [];
    userId: string = '';
    chatUser: UserDetails | null = null;
    foundUsers: UserDetails[] = [];

    constructor(
        private licentaService: LicentaService
    ) { }

    ngOnInit(): void {

        this.initializeChat();
    }

    openChatWithUser(userId: string): void {
        this.licentaService.getAllMessagesBetweenUsers(userId).subscribe((response: MessagesModel[]) => {
            this.messages = response;
        });
        this.licentaService.getUserById(userId).subscribe((response: UserDetails) => {
            this.chatUser = response;
        })
    }

    private initializeChat(): void {
        this.licentaService.isUserLoggedIn().subscribe((response: any) => {
            this.userId = response?.userId ?? '';
        })
        this.licentaService.getLastConversationsFosUser().subscribe((response: UserDetails[]) => {
            this.lastConversation = response;
        });
    }

    findFriendsByUsername(userName: string): void {
        this.licentaService.findFriendsByUsername(userName).subscribe((response: UserDetails[]) => {
            this.foundUsers = response;
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
        if (this.chatUser === null) {
            return;
        }
        const message: CreateMessageModel = {
            idGroup: this.chatUser.id,
            text: messageText
        }
        this.licentaService.sendMessage(message).subscribe(response => {
            //openChatWithGroup dupa ce creez functia
            this.openChatWithUser(message.idGroup!);
        });
    }

}
