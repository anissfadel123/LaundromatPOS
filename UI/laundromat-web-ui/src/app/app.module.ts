import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NewSaleComponent } from './new-sale/new-sale.component';
import { CleanComponent } from './clean/clean.component';
import { ReadyComponent } from './ready/ready.component';
import { PickupsComponent } from './pickups/pickups.component';
import { CustomerInventoryComponent } from './new-sale/customer-inventory/customer-inventory.component';
import { ProductsComponent } from './new-sale/products/products.component';

@NgModule({
  declarations: [
    AppComponent,
    NewSaleComponent,
    CleanComponent,
    ReadyComponent,
    PickupsComponent,
    CustomerInventoryComponent,
    ProductsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
