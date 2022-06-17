export interface AppointmentModel {
    idAppointment: string;
    name: string;
    timeAppointment: string;
    idBook: string;
    idFilm: string;
    idSeries: string;
    titleBook: string;
    titleFilm: string;
    titleSeries: string;
    idGroup: string;
    groupName: string;
    location: string;
}

export interface CreateAppointmentModel {
    name: string;
    timeAppointment: string;
    idBook: string;
    idFilm: string;
    idSeries: string;
    idGroup: string;
    location: string;
}
