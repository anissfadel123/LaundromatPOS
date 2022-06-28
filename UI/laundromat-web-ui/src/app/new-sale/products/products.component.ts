import { Component, OnDestroy, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { Subscription } from 'rxjs';
import { ProductService } from 'src/app/services/product.service';
import { InvoiceService } from 'src/app/services/invoice.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit, OnDestroy {
  retailProducts: Product[] = [];
  subscriptions: Subscription[] =[];

  displayAddProductModal: boolean = false;

  constructor(private _productService: ProductService, private _invoiceService: InvoiceService) { }

  ngOnInit(): void {
    this.subscriptions.push(this._productService.products$.subscribe(
      products => {
        this.retailProducts = products;
      }
    ))
  }

  addProductToInvoice(product: Product){
    console.log("yessir");
    this._invoiceService.sendProductToInvoice(product);
  }

  openAddProductModal(){
    this.displayAddProductModal = true;
  }
  closeAddProductModal(){
    this.displayAddProductModal = false;
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(subs => { subs.unsubscribe(); })
  }


}
