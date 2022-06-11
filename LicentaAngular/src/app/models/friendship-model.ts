import { FriendshipStatus } from "./friendship-status";
export interface FriendshipModel {

    id: string;

    idSender: string;

    nameSender: string;

    pictureSender: string;

    idReceiver: string;

    nameReceiver: string;

    status: string;

    lastUpdate: Date;
}

export interface CreateFriendshipModel {
    idReceiver: string;
}
