import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Customer } from '../models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private readonly baseUrl = environment.baseUrl;
  private selectedCustomer = new Customer();

  customers$ = this.http.get<Customer[]>(`${this.baseUrl}/api/Customers`);

  constructor(private http: HttpClient) { }

  filterCustomer(id: string, name: string) : Observable<Customer[]> {
    return this.http.get<Customer[]>(`${this.baseUrl}/api/Customers/Filter?id=${ id }&name=${ name }`);
  }

  postCustomer(customer: Customer){
    return this.http.post(`${this.baseUrl}/api/Customers`, customer);
  }

  getSelectedCustomer() {
    return this.selectedCustomer;
  }

  setSelectedCustomer(customer: Customer){
    this.selectedCustomer.id = customer.id;
    this.selectedCustomer.firstName = customer.firstName;
    this.selectedCustomer.lastName = customer.lastName;
    this.selectedCustomer.email = customer.email;
    this.selectedCustomer.address = customer.address;
    this.selectedCustomer.points = customer.points;
    this.selectedCustomer.phone = customer.phone;
  }

}
