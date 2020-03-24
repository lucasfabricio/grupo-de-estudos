import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AdvertisementsComponent } from './advertisements/advertisements.component';
@NgModule({
  declarations: [
    AppComponent,
    AdvertisementsComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent, AdvertisementsComponent]
})
export class AppModule { }
