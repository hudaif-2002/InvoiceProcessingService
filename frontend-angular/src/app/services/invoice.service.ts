import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  private apiUrl = `${environment.apiUrl}/invoices`;

  constructor(
    private http: HttpClient
  ) { }

  getInvoices() {

    let token = '';

    if (typeof window !== 'undefined') {
      token = localStorage.getItem('token') || '';
    }

    return this.http.get(
      this.apiUrl,
      {
        headers: {
          Authorization: `Bearer ${token}`
        }
      }
    );
  }

  createInvoice(invoice: any) {

    let token = '';

    if (typeof window !== 'undefined') {
      token = localStorage.getItem('token') || '';
    }

    return this.http.post(
      this.apiUrl,
      invoice,
      {
        headers: {
          Authorization: `Bearer ${token}`
        }
      }
    );
  }
}
