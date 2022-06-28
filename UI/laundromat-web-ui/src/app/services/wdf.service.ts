import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Wdf } from '../models/wdf.model';

@Injectable({
  providedIn: 'root'
})
export class WdfService {
  private readonly baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  wdfs$ = this.http.get<Wdf[]>(`${this.baseUrl}/api/Wdf`);

  incrementStatus(id: number) {
    return this.http.put<number>(`${this.baseUrl}/api/Wdf/IncrementStatus`, id);
  }

  decrementStatus(id: number) {
    return this.http.put<number>(`${this.baseUrl}/api/Wdf/DecrementStatus`, id);
  }
}
