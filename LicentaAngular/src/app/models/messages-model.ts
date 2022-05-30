import { Data } from "@angular/router";

export interface MessagesModel {
    id: string;
    idSender: string;
    idReceiver: string;
    IdGroup: string;
    IdReply: string;
    text: string;
    sendtime: Data;
}
