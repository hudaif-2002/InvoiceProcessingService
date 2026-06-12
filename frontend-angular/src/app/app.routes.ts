import { Routes } from '@angular/router';

import { Login } from './pages/login/login';
import { Register } from './pages/register/register';
import { Dashboard } from './pages/dashboard/dashboard';
import { InvoiceList } from './pages/invoice-list/invoice-list';
import { CreateInvoice } from './pages/create-invoice/create-invoice';

export const routes: Routes = [
  { path: '', component: Login },
  { path: 'register', component: Register },
  { path: 'home', component: Dashboard },
  { path: 'invoices', component: InvoiceList },
  { path: 'create-invoice', component: CreateInvoice }
];
