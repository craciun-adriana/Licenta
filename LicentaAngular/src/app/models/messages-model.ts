
export interface MessagesModel {
    id: string;
    idSender: string;
    nameSender: string;
    idReceiver: string;
    idGroup: string;
    text: string;
    sendTime: string;
}

export interface CreateMessageModel {
    idReceiver?: string;
    idGroup?: string;
    text: string;
}
