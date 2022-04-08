import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';
import { OpenpageComponent } from './openpage/openpage.component';
import { OffersComponent } from './offers/offers.component';
import { TableModule } from 'primeng/table';
import { NewadComponent } from './newad/newad.component';

@NgModule({
  declarations: [
    AppComponent,
    OpenpageComponent,
    OffersComponent,
    NewadComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    TableModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
