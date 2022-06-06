import { FriendshipStatus } from "./friendship-status";
export interface FriendshipModel {

    id: string;

    idSender: string;

    idReceiver: string;

    friendshipStatus: FriendshipStatus;

    lastUpdate: Date;
}

export interface CreateFriendshipModel {
    idReceiver: string;
}
