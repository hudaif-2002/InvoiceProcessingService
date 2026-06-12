import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { InvoiceService } from '../../services/invoice.service';

@Component({
  selector: 'app-create-invoice',
  imports: [FormsModule],
  templateUrl: './create-invoice.html',
  styleUrl: './create-invoice.css'
})
export class CreateInvoice {

  customerName = '';

  amount = 0;

  constructor(
    private invoiceService: InvoiceService,
    private router: Router
  ) { }

  createInvoice() {

    this.invoiceService
      .createInvoice({
        customerName: this.customerName,
        amount: this.amount
      })
      .subscribe({

        next: () => {

          alert('Invoice Created');

          this.router.navigate([
            '/invoices'
          ]);
        },

        error: () => {

          alert('Failed to create invoice');
        }
      });
  }
}
