import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Book, ErrorResponse } from '../../../models/book';
import { BooksService } from '../../../services/books.service';

@Component({
  selector: 'app-addoredit',
  templateUrl: './addoredit.component.html',
  styleUrls: ['./addoredit.component.css']
})
export class AddoreditComponent implements OnInit {
  form: FormGroup;
  isEdit: boolean = false;
  isErrorResponse: boolean = false;
  error: string;
  bookId: string;

  constructor(private bs: BooksService, private activatedRoute: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
      id: new FormControl({ value: '', disabled: true }),
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      isbn: new FormControl('', [Validators.required]),
      price: new FormControl('', [Validators.required]),
      authorName: new FormControl('', [Validators.required])
    });

    this.activatedRoute.paramMap.subscribe((p) => {
      if (p.has('id')) {
        this.bookId = p.get('id');
        if (this.bookId) {
          this.isEdit = true;
          this.bs.getSingle(this.bookId).subscribe((book: Book) => {
            this.form.get('name').patchValue(book.name);
            this.form.get('description').patchValue(book.description);
            this.form.get('isbn').patchValue(book.isbn);
            this.form.get('price').patchValue(book.price);
            this.form.get('authorName').patchValue(book.authorName);
          });
        }
      }
    });
  }

  save() {
    let book = <Book>this.form.value;
    if (this.isEdit) {
      book.id = this.bookId;
      this.bs.update(book).subscribe((res) => {
        this.router.navigate(['/']);
      }, (err: ErrorResponse) => {
        this.isErrorResponse = true;
        this.error = err.errors.join('<br>');
        console.log(err);
      });
    } else {
      this.bs.add(book).subscribe((res) => {
        this.router.navigate(['/']);
      }, (err: ErrorResponse) => {
        this.isErrorResponse = true;
        this.error = err.errors.join('<br>');
        console.log(err);
      })
    }


  }

}
