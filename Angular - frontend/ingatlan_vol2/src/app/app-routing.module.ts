import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NewadComponent } from './newad/newad.component';
import { OffersComponent } from './offers/offers.component';

const routes: Routes = [
  {path: "", component: HomeComponent},
  {path: "offers", component: OffersComponent},
  {path: "newad", component: NewadComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
