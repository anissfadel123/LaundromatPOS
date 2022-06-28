import { Component, EventEmitter, Input, OnChanges, OnDestroy, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup} from '@angular/forms';
import { Subscription } from 'rxjs';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-register-customer-modal',
  templateUrl: './register-customer-modal.component.html',
  styleUrls: ['./register-customer-modal.component.css']
})
export class RegisterCustomerModalComponent implements OnInit, OnDestroy, OnChanges {
  @Input() isOpen = false;
  @Output() closeModalEvent = new EventEmitter();
  postCustomerSub: Subscription|undefined;

  customerForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    phone: new FormControl(''),
    email: new FormControl(''),
    address: new FormControl('')

  });
  constructor(private _customerService: CustomerService) { }
  ngOnChanges(changes: SimpleChanges): void {
    console.log("yes changes have been made")
  }


  ngOnInit(): void {
    console.log("ng init baby")
  }

  closeModal() {
    this.closeModalEvent.emit();
  }

  onSubmit() {

    let value = this.customerForm.value;
    let newCustomer = new Customer(
      undefined,
      value.firstName,
      value.lastName,
      value.email,
      value.phone,
      value.address,
      0
    );

    this.postCustomerSub?.unsubscribe();
    this.postCustomerSub = this._customerService.postCustomer(newCustomer).subscribe();

    this.clear();
  }

  ngOnDestroy(): void {
    this.postCustomerSub?.unsubscribe();
  }

  clear(){
    this.customerForm.patchValue({
      firstName: '',
      lastName:'',
      email: '',
      phone: '',
      address: ''
    })
  }

}
