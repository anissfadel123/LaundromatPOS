import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CleanComponent } from './clean/clean.component';
import { NewSaleComponent } from './new-sale/new-sale.component';
import { PickupsComponent } from './pickups/pickups.component';
import { ReadyComponent } from './ready/ready.component';

const routes: Routes = [
  {path:"sale", component:NewSaleComponent},
  {path:"clean", component:CleanComponent},
  {path:"ready", component:ReadyComponent},
  {path:"pickups", component:PickupsComponent},
  {path:"**", redirectTo:'sale', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
