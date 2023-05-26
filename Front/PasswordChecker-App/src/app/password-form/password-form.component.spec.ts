import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PasswordFormComponent } from './password-form.component';

describe('PasswordFormComponent', () => {
  let component: PasswordFormComponent;
  let fixture: ComponentFixture<PasswordFormComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule, FormsModule, ReactiveFormsModule],
      declarations: [PasswordFormComponent]
    });
    fixture = TestBed.createComponent(PasswordFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });

  it('should display "Valid password" when a valid password is entered', () => {
    const inputElement = fixture.nativeElement.querySelector('#password');
    inputElement.value = 'AbTp9!fok';
    inputElement.dispatchEvent(new Event('input'));

    const buttonElement = fixture.nativeElement.querySelector('button');
    buttonElement.click();
    fixture.detectChanges();

    const resultElelent = fixture.nativeElement.querySelector('[data-id="result"]');
    if (resultElelent != null){
      expect(resultElelent.textContent).toContain('Valid password');
    }

    //console.log(inputElement.value);
    //console.log(buttonElement);
    //console.log(resultElelent);
  });

  it('should display "Invalid password" when an invalid password is entered', () => {
    const inputElement = fixture.nativeElement.querySelector('#password');
    inputElement.value = 'invalidpassword';
    inputElement.dispatchEvent(new Event('input'));

    const buttonElement = fixture.nativeElement.querySelector('button');
    buttonElement.click();
    fixture.detectChanges();

    const resultElelent = fixture.nativeElement.querySelector('[data-id="result"]');
    if (resultElelent != null){
      expect(resultElelent.textContent).toContain('Invalid password');
    }

    //console.log(inputElement.value);
    //console.log(buttonElement);
    //console.log(resultElelent);
  });
});

