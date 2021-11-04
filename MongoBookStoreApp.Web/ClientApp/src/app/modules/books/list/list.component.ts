import { Component, OnInit } from '@angular/core';
import { Book } from '../../../models/book';
import { BooksService } from '../../../services/books.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  books: Book[];

  constructor(private bs: BooksService) { }

  ngOnInit() {
    this.bs.getAll().subscribe((data: Book[]) => {
      this.books = data;
    });
  }

  delete(bookId) {
    this.bs.delete(bookId).subscribe((d) => {
      this.books = this.books.filter(x => x.id !== bookId);
    });
  }

}
