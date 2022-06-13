import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CreateBookModel } from 'src/app/models/book-model';
import { LicentaService } from 'src/app/services/licenta-service.service';

@Component({
    selector: 'app-add-book',
    templateUrl: './add-book.component.html',
    styleUrls: ['./add-book.component.scss']
})
export class AddBookComponent implements OnInit {

    addBookForm = new FormGroup({
        title: new FormControl('', Validators.required),
        author: new FormControl('', Validators.required),
        description: new FormControl('', Validators.required),
        releaseDate: new FormControl('', Validators.required),
        prequelId: new FormControl('',),
        sequelId: new FormControl('',),
        genre: new FormControl('', Validators.required),
        picture: new FormControl('', Validators.required),
    })

    errorMessage: string = '';

    constructor(
        public licentaService: LicentaService
    ) { }

    ngOnInit(): void {
    }

    addBook(): void {
        const bookDetails: CreateBookModel = {
            title: this.addBookForm.get('title')?.value,
            author: this.addBookForm.get('author')?.value,
            description: this.addBookForm.get('description')?.value,
            relaseDate: this.addBookForm.get('releaseDate')?.value,
            prequelId: this.addBookForm.get('prequelId')?.value,
            sequelId: this.addBookForm.get('seguelId')?.value,
            genre: this.addBookForm.get('genre')?.value,
            picture: this.addBookForm.get('picture')?.value,
        }
        this.licentaService.createBook(bookDetails).subscribe(response => {
            if (response !== null)
                this.errorMessage = "Book was created.";
            else this.errorMessage = 'Book can not be created.';
        })
    }

}
