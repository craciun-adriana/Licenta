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
    isAdmin: boolean = false;

    constructor(
        private licentaService: LicentaService
    ) { }

    ngOnInit(): void {
        this.initializePage();
    }

    private initializePage() {
        this.licentaService.getAllUsers(this.isAdmin).subscribe((response: UserDetails[]) => {
            this.users = response;
        })
        this.isAdmin = true;
        this.licentaService.getAllUsers(this.isAdmin).subscribe((response: UserDetails[]) => {
            this.admins = response;
        })
        debugger
    }

    updateAdminStatus(userId: string, adminStatus: boolean): void {
        this.licentaService.updateAdminStatus(userId, adminStatus).subscribe(_ => {
            this.initializePage();
        });
    }
}
