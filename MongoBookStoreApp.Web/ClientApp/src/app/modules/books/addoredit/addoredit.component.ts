import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../../../models/book';
import { BooksService } from '../../../services/books.service';

@Component({
  selector: 'app-addoredit',
  templateUrl: './addoredit.component.html',
  styleUrls: ['./addoredit.component.css']
})
export class AddoreditComponent implements OnInit {
  form: FormGroup;
  isEdit: boolean = false;

  constructor(private bs: BooksService, private activatedRoute: ActivatedRoute, private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
      id: new FormControl({ value: '', disabled: true }),
      name: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      isdn: new FormControl('', [Validators.required]),
      price: new FormControl('', [Validators.required]),
      authorName: new FormControl('', [Validators.required])
    });

    this.activatedRoute.paramMap.subscribe((p) => {
      if (p.has('id')) {
        let bookId = p.get('id');
        if (bookId) {
          this.isEdit = true;
          this.bs.getSingle(bookId).subscribe((book: Book) => {
            this.form.get('id').patchValue(book.id);
            this.form.get('name').patchValue(book.name);
            this.form.get('description').patchValue(book.description);
            this.form.get('isdn').patchValue(book.isdn);
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
      this.bs.update(book).subscribe((res) => {
        this.router.navigate(['/']);
      })
    } else {
      this.bs.add(book).subscribe((res) => {
        this.router.navigate(['/']);
      })
    }


  }

}
