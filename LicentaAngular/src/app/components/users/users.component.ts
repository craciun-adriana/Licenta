import { Component, OnInit } from '@angular/core';
import { UserDetails } from 'src/app/models/user-details';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-users',
    templateUrl: './users.component.html',
    styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

    admins: UserDetails[] = [];
    users: UserDetails[] = [];

    constructor(
        private licentaService: LicentaService
    ) { }

    ngOnInit(): void {
        this.initializePage();
    }

    private initializePage() {
        this.licentaService.getAllUsers(false).subscribe((response: UserDetails[]) => {
            this.users = response;
        })

        this.licentaService.getAllUsers(true).subscribe((response: UserDetails[]) => {
            this.admins = response;
        })
    }

    updateAdminStatus(userId: string, adminStatus: boolean): void {
        this.licentaService.updateAdminStatus(userId, adminStatus).subscribe(_ => {
            this.initializePage();
        });
    }
}
