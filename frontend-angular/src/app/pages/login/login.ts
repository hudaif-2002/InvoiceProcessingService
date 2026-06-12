import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  imports: [FormsModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {

  username = '';
  password = '';

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  login() {

    this.authService.login({
      username: this.username,
      password: this.password
    })
      .subscribe({
        next: (response) => {

          this.authService.saveToken(
            response.token
          );

          this.router.navigate(['/home']);
        },

        error: () => {
          alert('Login Failed');
        }
      });
  }
}
