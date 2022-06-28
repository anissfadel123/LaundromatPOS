import { Component, OnDestroy, OnInit } from '@angular/core';
import { InvoiceItem } from 'src/app/models/invoice-item.model';
import { Product } from 'src/app/models/product.model';
import { Subscription } from 'rxjs';
import { InvoiceService } from 'src/app/services/invoice.service';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';


@Component({
  selector: 'app-customer-inventory',
  templateUrl: './customer-inventory.component.html',
  styleUrls: ['./customer-inventory.component.css']
})
export class CustomerInventoryComponent implements OnInit, OnDestroy {

  customer: Customer;
  invoiceItemList: InvoiceItem[] = [];
  subscriptions:Subscription[] = [];
  displayPaymentModal: boolean = false;
  displayCancelTransactionModal: boolean = false;
  displayCashAmountModal: boolean = false;
  displaySelectCustomerModal: boolean = false;

  constructor(private invoiceService: InvoiceService, private _customerService: CustomerService) {
    this.customer = this._customerService.getSelectedCustomer();
   }


  ngOnInit(): void {
    this.subscriptions.push(this.invoiceService.product$.subscribe(
      (product) => {
          this.addProduct(product);
      }
    ));
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(sub =>{ sub.unsubscribe() });
  }


  addProduct(product: Product) : void {

    for(let i=0; i<this.invoiceItemList.length; i++){
        if(this.invoiceItemList[i].product === product){
          this.invoiceItemList[i].addProduct(1);
          return;
        }
    }
      this.invoiceItemList.push(new InvoiceItem(product));
  }

  removeInvoiceItem(invoiceItem:InvoiceItem){
    let index = this.invoiceItemList.indexOf(invoiceItem);
    if(index != -1){
      this.invoiceItemList.splice(index, 1);
    }
  }

  getSubTotal(){
    let subTotal = 0;
    for(let i=0; i<this.invoiceItemList.length; i++){
      subTotal += this.invoiceItemList[i].getAmountWithoutTax();
    }
    return subTotal;
  }

  getTaxTotal(){
    let taxTotal = 0;
    for(let i=0; i<this.invoiceItemList.length; i++){
      taxTotal += this.invoiceItemList[i].getTotalTaxAmount();
    }
    return taxTotal;
  }

  getGrandTotal() {
    return this.getSubTotal() + this.getTaxTotal();
  }

  openPaymentMethodModal() {
    this.displayPaymentModal = true;
  }

  closePaymentMethodModal() {
    this.displayPaymentModal = false;
  }

  closeCancelTransactionModal(){
    this.displayCancelTransactionModal = false;
  }

  openCancelTransactionModal(){
    this.displayCancelTransactionModal = true;
  }

  openCashAmountModal() {
    this.displayCashAmountModal = true;
    console.log("open")
  }

  closeCashAmountModal() {
    this.displayCashAmountModal = false;
    console.log("close")
  }

  openSelectCustomerModal() {
    this.displaySelectCustomerModal= true;
  }

  closeSelectCustomerModal() {
    this.displaySelectCustomerModal = false;
  }





  clearInvoice(){
    this.invoiceItemList.length = 0;
  }

  cancelCustomerTransaction(){
    this.clearInvoice();
    this.displayCancelTransactionModal = false;
  }

}
