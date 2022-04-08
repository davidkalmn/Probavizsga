import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OpenpageComponent } from './openpage/openpage.component';
import { OffersComponent } from './offers/offers.component';
import { NewadComponent } from './newad/newad.component';

const routes: Routes = [
  { path: "offers", component: OffersComponent},
  { path: "newad", component: NewadComponent},
  { path: "**", component: OpenpageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
