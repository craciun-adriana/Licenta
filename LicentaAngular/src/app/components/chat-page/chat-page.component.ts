import { Component, OnInit } from '@angular/core';
import { MessagesModel } from 'src/app/models/messages-model';
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
    chatUser: string = '';
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
            this.chatUser = response.userName;
        })
    }

    private initializeChat(): void {
        this.licentaService.isUserLoggedIn().subscribe((response: string) => {
            this.userId = response;
        })
        this.licentaService.getLastConversationFosUser().subscribe((response: UserDetails[]) => {
            this.lastConversation = response;
        });
    }

    findFriendsByUsername(userName: string): void {
        this.licentaService.findFriendsByUsername(userName).subscribe((response: UserDetails[]) => {
            this.foundUsers = response;
        })
    }

}
