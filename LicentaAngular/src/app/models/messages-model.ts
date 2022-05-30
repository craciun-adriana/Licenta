import { Data } from "@angular/router";

export interface MessagesModel {
    id: string;
    idSender: string;
    idReceiver: string;
    idGroup: string;
    text: string;
    sendtime: Data;
}

export interface CreateMessageModel {
    idReceiver?: string;
    idGroup?: string;
    text: string;
}
