import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterDetails } from 'src/app/models/register-details';
import { Sex } from 'src/app/models/sex';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-register-page',
    templateUrl: './register-page.component.html',
    styleUrls: ['./register-page.component.scss']
})
export class RegisterPageComponent {

    registerForm = new FormGroup({
        firstName: new FormControl('', Validators.required),
        lastName: new FormControl('', Validators.required),
        email: new FormControl('', Validators.required),
        userName: new FormControl('', Validators.required),
        password: new FormControl('', Validators.required),
        dateOfBirth: new FormControl('', Validators.required),
        sex: new FormControl('', Validators.required),
    });

    showErrorMessage = false;

    constructor(
        private licentaService: LicentaService,
        private router: Router
    ) { }

    clickRegister(): void {
        const registerDetails: RegisterDetails = {
            firstName: this.registerForm.get('firstName')?.value,
            lastName: this.registerForm.get('lastName')?.value,
            email: this.registerForm.get('email')?.value,
            userName: this.registerForm.get('userName')?.value,
            password: this.registerForm.get('password')?.value,
            dateOfBirth: this.registerForm.get('dateOfBirth')?.value,
            sex: this.registerForm.get('sex')?.value,

        };
        this.licentaService.registerUser(registerDetails).subscribe(response => {
            if (response === false) {
                this.showErrorMessage = true;
            } else {
                this.router.navigate(['login']);
            }
        });
    }
}
