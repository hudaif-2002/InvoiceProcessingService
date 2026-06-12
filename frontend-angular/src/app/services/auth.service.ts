import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { LoginModel } from '../models/login.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl =
    `${environment.apiUrl}/auth`;

  constructor(
    private http: HttpClient
  ) { }

  login(
    loginData: LoginModel
  ): Observable<any> {

    return this.http.post(
      `${this.apiUrl}/login`,
      loginData
    );
  }

  register(
    userData: any
  ): Observable<any> {

    return this.http.post(
      `${this.apiUrl}/register`,
      userData
    );
  }

  saveToken(token: string) {

    if (typeof window !== 'undefined') {
      localStorage.setItem('token', token);
    }
  }

  getToken() {

    if (typeof window !== 'undefined') {
      return localStorage.getItem('token');
    }

    return null;
  }

  logout() {

    if (typeof window !== 'undefined') {
      localStorage.removeItem('token');
    }
  }
}
