import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-select-customer-modal',
  templateUrl: './select-customer-modal.component.html',
  styleUrls: ['./select-customer-modal.component.css']
})
export class SelectCustomerModalComponent implements OnInit, OnDestroy {

  @Input() isOpen = false;
  @Output() closeModalEvent = new EventEmitter();
  id: string = "";
  name:string = "";
  customerFilterSub: Subscription|undefined;


  customerList: Customer[] = [];

  constructor(private _customerService: CustomerService) {
   }

  ngOnInit(): void {
  }

  closeModal() {
    this.customerList = [];
    this.closeModalEvent.emit();
  }

  filterCustomer(){
    this.customerFilterSub?.unsubscribe();
    this.customerFilterSub = this._customerService.filterCustomer(this.id, this.name).subscribe(
      customers => {
        this.customerList = customers;
      }
    );

  }
  ngOnDestroy(): void {
    this.customerFilterSub?.unsubscribe();
  }

  OnSelectCustomer(customer: Customer){
    this._customerService.setSelectedCustomer(customer);
    this.closeModal();
  }


}
