import { Product } from "./product.model";

export class InvoiceItem {
  public product: Product;
  private quantity: number;
  private discount: number = 0;
  private taxRate: number = 0;

  constructor(product:Product){
    this.product = product;
    this.quantity = 1;
  }

  addProduct(amt:number){
    this.quantity += amt;
  }

  getQuantity(): number{
    return this.quantity;
  }

  setQuantity(quantity: number): void {
    if(quantity>0){
      this.quantity = quantity;
    }
  }

  public getAmountWithoutTax() {
    return this.product.price * this.quantity;
  }

  public getTotalTaxAmount() {
    return this.getAmountWithoutTax() * this.taxRate;
  }

  public getAmountWithTax() : number {
    return this.getAmountWithoutTax() + this.getTotalTaxAmount();
  }

  public getAmountWithTaxAndDiscount() : number {
    return this.getAmountWithTax() - this.discount;
  }

  public getDiscount() {
    return this.discount;
  }

  public getProductPrice() {
    return this.product.price;
  }

  public getProductDescription(){
    return this.product.productDescription;
  }

}
