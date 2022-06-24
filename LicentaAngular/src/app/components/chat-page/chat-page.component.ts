import { AfterContentChecked, ChangeDetectorRef, Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { CreateMessageModel, MessagesModel } from 'src/app/models/messages-model';
import { UserDetails } from 'src/app/models/user-details';
import { LicentaService } from 'src/app/services/licenta-service.service';
import { CreateGroupModel, GroupModel } from 'src/app/models/group-model';
import { forkJoin, Subscription, timer } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { CreateGroupDialog } from '../dialogs/create-group/create-group.component';
import { UsersGroupsSearchDialog } from '../dialogs/users-groups-search/users-groups-search.component';
import { DetailsGroupDialog } from '../dialogs/details-group/details-group.component';

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
    chatSubscription: Subscription = new Subscription();
    firstTimeChat: boolean = false;

    isGroup: boolean = false;
    isCreatingGroup: boolean = false;
    groupMembers: UserDetails[] = [];
    userFriends: UserDetails[] = [];
    isOpenGroupDetails: boolean = false;
    isAddMemberOpen: boolean = false;

    @ViewChildren("chatDiv") chatDiv?: ElementRef;

    constructor(
        private licentaService: LicentaService,
        private dialog: MatDialog
    ) { }

    ngOnInit(): void {
        this.initializeChat();
    }

    private initializeChat(): void {
        this.licentaService.isUserLoggedIn().subscribe((response: any) => {
            this.userId = response?.userId ?? '';
        });

        timer(0, 10000).subscribe(_ => {
            this.licentaService.getLastUserConversationsForUser().subscribe((response: UserDetails[]) => {
                this.lastConversation = response;
            });

            this.licentaService.getLastGroupConversationsForUser().subscribe((response: GroupModel[]) => {
                this.lastConversationG = response;
            });
        });
    }

    findFriendsAndGroupsByName(name: string): void {
        const userSearch = this.licentaService.findFriendsByUsername(name);
        const groupSearch = this.licentaService.findUserGroupsByName(name);

        forkJoin([userSearch, groupSearch]).subscribe((response: [users: UserDetails[], groups: GroupModel[]]) => {
            const dialogRef = this.dialog.open(UsersGroupsSearchDialog, {
                data: {
                    users: response[0],
                    groups: response[1]
                }
            });

            dialogRef.afterClosed().subscribe(response => {
                if (!response) {
                    return;
                }
                if (response.isGroup) {
                    this.openChatWithGroup(response.id);
                }
                else {
                    this.openChatWithUser(response.id);
                }
            })
        });
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

    startCreateGroup(): void {
        this.isCreatingGroup = true;
    }

    closeCreateGroup(): void {
        this.isCreatingGroup = false;
    }


    openChatWithUser(userId: string): void {
        this.isGroup = false;
        this.firstTimeChat = true;
        this.chatSubscription.unsubscribe();
        this.chatSubscription = new Subscription();

        const subscription = timer(0, 10000).subscribe(_ => {
            this.licentaService.getAllMessagesBetweenUsers(userId).subscribe((response: MessagesModel[]) => {
                this.messages = response;
            });
        });

        this.chatSubscription.add(subscription);

        this.licentaService.getUserById(userId).subscribe((response: UserDetails) => {
            this.chatUser = response;
        })
    }

    openChatWithGroup(groupId: string): void {
        this.isGroup = true;
        this.chatSubscription.unsubscribe();
        this.chatSubscription = new Subscription();

        const subscription = timer(0, 10000).subscribe(_ => {
            this.licentaService.getAllMessagesInGroup(groupId).subscribe((response: MessagesModel[]) => {
                this.messages = response;
            });
        });

        this.chatSubscription.add(subscription);
        this.licentaService.getGroupById(groupId).subscribe((response: GroupModel) => {
            this.chatGroup = response;
        })
    }


    openGroupDetails(): void {
        if (!this.chatGroup) {
            return;
        }
        const groupId = this.chatGroup.id;

        const dialogRef = this.dialog.open(DetailsGroupDialog, {
            data: {
                groupId: groupId
            }
        });

        dialogRef.afterClosed().subscribe(_ => {
            this.openChatWithGroup(groupId);
        })
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

    getMessageClass(idSender: string): string {
        if (idSender === this.userId) {
            return "sent";
        }
        return "received";
    }

    isValidUrl(urlToCheck?: string): boolean {
        let url;

        if (!urlToCheck) {
            return false;
        }

        try {
            url = new URL(urlToCheck);
        } catch (_) {
            return false;
        }

        return url.protocol === "http:" || url.protocol === "https:";
    }

    openCreateGroupDialog(): void {
        this.dialog.open(CreateGroupDialog, {})
    }
}
