import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginDetails } from 'src/app/models/login-details';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-login-page',
    templateUrl: './login-page.component.html',
    styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent {

    loginForm = new FormGroup({
        userName: new FormControl('', Validators.required),
        password: new FormControl('', Validators.required),
        rememberMe: new FormControl('', Validators.required),
    });

    showErrorMessage = false;

    constructor(
        private licentaService: LicentaService,
        private router: Router
    ) { }

    clickLogin(): void {
        const loginDetails: LoginDetails = {
            userName: this.loginForm.get('userName')?.value,
            password: this.loginForm.get('password')?.value,
            rememberMe: this.loginForm.get('rememberMe')?.value ? true : false
        };

        this.licentaService.loginUser(loginDetails).subscribe(response => {
            if (response === false) {
                this.showErrorMessage = true;
            } else {
                this.router.navigate(['home']);
            }
        });
    }
}
