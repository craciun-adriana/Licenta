import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MessagesModel } from 'src/app/models/messages-model';
import { UserDetails } from 'src/app/models/user-details';

@Component({
    selector: 'app-message',
    templateUrl: './message.component.html',
    styleUrls: ['./message.component.scss']
})
export class MessageComponent implements AfterViewInit {

    @Input() message?: MessagesModel;
    @Input() chatUser: UserDetails | null = null;
    @Input() userId: string = '';
    @Input() isGroup: boolean = false;
    @Input() isLast: boolean = false;

    @Output() onIsLastItem: EventEmitter<void> = new EventEmitter<void>();
    constructor() { }

    ngAfterViewInit(): void {
        if (this.isLast) {
            this.onIsLastItem.emit();
        }
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

}
