import { NgModule } from '@angular/core';
import { AddoreditComponent } from './addoredit/addoredit.component';
import { ListComponent } from './list/list.component';
import { RouterModule } from '@angular/router';
import { LandingComponent } from './landing/landing.component';

@NgModule({
  imports: [
    RouterModule.forChild([
      { path: '', component: ListComponent },
      { path: 'list', component: ListComponent },
      { path: 'edit/:id', component: AddoreditComponent },
      { path: 'add', component: AddoreditComponent },
      { path: '**', component: ListComponent }
    ])
  ],
  exports: [
    RouterModule
  ]
})
export class BooksRoutingModule {
}
