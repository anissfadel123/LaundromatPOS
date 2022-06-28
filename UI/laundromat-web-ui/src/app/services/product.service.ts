import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private readonly baseUrl = environment.baseUrl;

  products$ = this.http.get<Product[]>(`${this.baseUrl}/api/Products`);


  constructor(private http: HttpClient) { }


}
