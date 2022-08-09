import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Shared/Components/header/header.component';
import { FooterComponent } from './Shared/Components/footer/footer.component';
import { MovieItemComponent } from './Movies/movie-item/movie-item.component';
import { MoviesListComponent } from './Movies/movies-list/movies-list.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MovieItemComponent,
    MoviesListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
