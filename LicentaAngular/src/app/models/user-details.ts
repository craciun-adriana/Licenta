import { Sex } from "./sex";

export interface UserDetails {
    id: string;
    userName: string;
    profilePicture: string;
    firstName: string;
    lastName: string;
    dateOfBirth: string;
    description: string;
    sex: Sex;
    lastOnline: Date;
    isAdmin: boolean;
    rank: number;
}

export interface UserUpdate {
    userName: string;
    profilePicture: string;
    firstName: string;
    lastName: string;
    dateOfBirth: string;
    description: string;
    sex: Sex;
}
