import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './modules/shared/nav-menu/nav-menu.component';
import { HomeComponent } from './modules/shared/home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { BookInterceptor } from './services/book.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: BookInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
