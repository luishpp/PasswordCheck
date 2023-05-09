import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-password-form',
  templateUrl: './password-form.component.html',
  styleUrls: ['./password-form.component.scss']
})

export class PasswordFormComponent {
  password = '';
  isValid: boolean | undefined;

  constructor(private http: HttpClient) {}

  checkPassword() {
    this.http.get<boolean>(`http://localhost:5062/api/password/${this.password}`)
      .subscribe(result => {
        this.isValid = result
      }
    );
  }
}
