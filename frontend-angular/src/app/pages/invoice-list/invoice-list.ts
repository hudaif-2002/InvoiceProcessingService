import {
  Component,
  OnInit,
  ChangeDetectorRef
} from '@angular/core';

import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

import { InvoiceService } from '../../services/invoice.service';

@Component({
  selector: 'app-invoice-list',
  imports: [CommonModule, RouterLink],
  templateUrl: './invoice-list.html',
  styleUrl: './invoice-list.css'
})
export class InvoiceList implements OnInit {

  invoices: any[] = [];

  constructor(
    private invoiceService: InvoiceService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.loadInvoices();
  }

  loadInvoices() {

    this.invoiceService
      .getInvoices()
      .subscribe({
        next: (data: any) => {

          console.log('INVOICES:', data);

          this.invoices = data;

          this.cdr.detectChanges();

          console.log('COUNT:', this.invoices.length);
        },

        error: (err) => {
          console.error('ERROR:', err);
        }
      });
  }
}
