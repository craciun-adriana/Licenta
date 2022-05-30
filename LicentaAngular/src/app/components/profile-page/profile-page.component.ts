import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserDetails } from 'src/app/models/user-details';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-profile-page',
    templateUrl: './profile-page.component.html',
    styleUrls: ['./profile-page.component.scss']
})
export class ProfilePageComponent implements OnInit {
    private userId: string = "";
    user: UserDetails | null = null;

    constructor(
        private licentaService: LicentaService,
        private router: Router,
        private activatedRoute: ActivatedRoute
    ) { }

    ngOnInit(): void {
        this.userId = this.activatedRoute.snapshot.paramMap.get('id') ?? '';
        if (this.userId !== '') {
            this.licentaService.getUserById(this.userId).subscribe((response: UserDetails) => {
                if (response !== null) {
                    this.user = response;
                } else {
                    this.router.navigate(['home']);
                }
            });
        }
        else {
            this.licentaService.isUserLoggedIn().subscribe((response: string) => {
                if (response !== "") {
                    this.licentaService.getUserById(response).subscribe((response: UserDetails) => {
                        if (response !== null) {
                            this.user = response;
                        }
                    });
                }
                else {
                    this.router.navigate(['login']);
                }
            })
        }
    }

}
