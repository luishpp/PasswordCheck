import { Component, OnInit  } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http'

@Component({
  selector: 'app-password-form',
  templateUrl: './password-form.component.html',
  styleUrls: ['./password-form.component.scss']
})

export class PasswordFormComponent {
  password = '';
  isValid: boolean | undefined;
  passwordForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient
  ) {}

  ngOnInit() {
    this.passwordForm = this.formBuilder.group({
      password: ['', Validators.required]
    });
  }

  public submitPassword(): void {
    this.checkPassword(this.passwordForm.value.password);
  }

  checkPassword(password: string) {
    const url = 'http://localhost:5062/api/v1/password';
    const body = '"' + password + '"';

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };

    return this.http.post<boolean>(url, body, httpOptions)
      .subscribe(result => {
        this.isValid = result;
      });
  }
}
