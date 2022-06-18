import { StringMapWithRename } from "@angular/compiler/src/compiler_facade_interface"

export interface GroupMemberModel {
    id: string;
    idGroup: string;
    idUser: string;
    isAdmin: boolean;
}

export interface CreateGroupMemberModel {
    idGroup: string;
    idUser: string;
    isAdmin: boolean;
}
