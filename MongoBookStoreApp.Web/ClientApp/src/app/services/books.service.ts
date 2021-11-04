import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAll() {
    return this.http.get(`${this.baseUrl}api/books`);
  }

  getSingle(bookId: string) {
    return this.http.get(`${this.baseUrl}api/books/${bookId}`);
  }

  update(book: Book) {
    return this.http.put(`${this.baseUrl}api/books/${book.id}`, book);
  }

  add(book: Book) {
    return this.http.post(`${this.baseUrl}api/books`, book);
  }

  delete(bookId: any) {
    return this.http.delete(`${this.baseUrl}api/books/${bookId}`);
  }
}
