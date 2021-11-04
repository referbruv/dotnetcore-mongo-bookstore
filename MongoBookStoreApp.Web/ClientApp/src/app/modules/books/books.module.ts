import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddoreditComponent } from './addoredit/addoredit.component';
import { ListComponent } from './list/list.component';
import { BooksRoutingModule } from './books-routing.module';
import { LandingComponent } from './landing/landing.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [AddoreditComponent, ListComponent, LandingComponent],
  imports: [
    CommonModule,
    BooksRoutingModule,
    ReactiveFormsModule
  ]
})
export class BooksModule { }




