import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'


import { AppComponent } from './app.component';
import { NewSaleComponent } from './new-sale/new-sale.component';
import { CleanComponent } from './clean/clean.component';
import { ReadyComponent } from './ready/ready.component';
import { PickupsComponent } from './pickups/pickups.component';
import { CustomerInventoryComponent } from './new-sale/customer-inventory/customer-inventory.component';
import { ProductsComponent } from './new-sale/products/products.component';

import { HttpClientModule } from '@angular/common/http';
import { CashInputModalComponent } from './custom-modals/cash-input-modal/cash-input-modal.component';
import { AddNewProductModalComponent } from './custom-modals/add-new-product-modal/add-new-product-modal.component';
import { RegisterCustomerModalComponent } from './custom-modals/register-customer-modal/register-customer-modal.component';
import { SelectCustomerModalComponent } from './custom-modals/select-customer-modal/select-customer-modal.component';


@NgModule({
  declarations: [
    AppComponent,
    NewSaleComponent,
    CleanComponent,
    ReadyComponent,
    PickupsComponent,
    CustomerInventoryComponent,
    ProductsComponent,
    CashInputModalComponent,
    AddNewProductModalComponent,
    RegisterCustomerModalComponent,
    SelectCustomerModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
