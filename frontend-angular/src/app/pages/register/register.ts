import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css'
})
export class Register {

  username = '';
  password = '';

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  register() {

    this.authService.register({
      username: this.username,
      password: this.password
    })
      .subscribe({
        next: () => {

          alert('Registration Successful');

          this.router.navigate(['/']);
        },

        error: () => {
          alert('Registration Failed');
        }
      });
  }
}
