export interface GroupModel {
    id: string;
    name: string;
    picture: string;
    description: string;
    lastMessageTimestamp: Date;

}

export interface CreateGroupModel {
    name: string;
    picture: string;
    description: string;
}
