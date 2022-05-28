import { Sex } from './sex';

export interface RegisterDetails {
    firstName: string;
    lastName: string;
    email: string;
    userName: string;
    password: string;
    dateOfBirth: Date;
    sex: Sex;
}
