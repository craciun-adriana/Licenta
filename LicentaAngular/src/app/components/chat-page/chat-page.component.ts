import { Component, OnInit } from '@angular/core';
import { MessagesModel } from 'src/app/models/messages-model';
import { UserDetails } from 'src/app/models/user-details';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-chat-page',
    templateUrl: './chat-page.component.html',
    styleUrls: ['./chat-page.component.scss']
})
export class ChatPageComponent implements OnInit {
    messages: MessagesModel[] = [];
    lastConversation: UserDetails[] = [];
    userId: string = '';

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
    }

    private initializeChat(): void {
        this.licentaService.isUserLoggedIn().subscribe((response: string) => {
            this.userId = response;
        })
        this.licentaService.getLastConversationFosUser().subscribe((response: UserDetails[]) => {
            this.lastConversation = response;
        });
    }

}
