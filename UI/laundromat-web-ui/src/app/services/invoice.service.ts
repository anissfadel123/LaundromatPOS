import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Product } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  private _productToInvoiceSource = new Subject<Product>();
  product$ = this._productToInvoiceSource.asObservable();
  constructor() { }

  sendProductToInvoice(product: Product){
    this._productToInvoiceSource.next(product);
  }
}
