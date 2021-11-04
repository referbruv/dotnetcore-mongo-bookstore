import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./modules/shared/home/home.component";

const routes: Routes = [
    { path: '', redirectTo: 'books', pathMatch: 'full' },
    { path: 'books', loadChildren: () => import('./modules/books/books.module').then(x => x.BooksModule) }
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule {
}