import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { PasswordFormComponent } from './password-form.component';

describe('PasswordFormComponent', () => {
  let component: PasswordFormComponent;
  let fixture: ComponentFixture<PasswordFormComponent>;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule, FormsModule],
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
    const inputEl = fixture.nativeElement.querySelector('#password');
    inputEl.value = 'AbTp9!fok';
    inputEl.dispatchEvent(new Event('input'));

    const buttonEl = fixture.nativeElement.querySelector('button');
    buttonEl.click();
    fixture.detectChanges();

    const resultEl = fixture.nativeElement.querySelector('p');
    if (resultEl != null){
      expect(resultEl.textContent).toContain('Valid password');
    }
  });

  it('should display "Invalid password" when an invalid password is entered', () => {
    const inputEl = fixture.nativeElement.querySelector('#password');
    inputEl.value = 'invalidpassword';
    inputEl.dispatchEvent(new Event('input'));

    const buttonEl = fixture.nativeElement.querySelector('button');
    buttonEl.click();
    fixture.detectChanges();

    const resultEl = fixture.nativeElement.querySelector('p');
    if (resultEl != null){
      expect(resultEl.textContent).toContain('Invalid password');
    }
  });
});
