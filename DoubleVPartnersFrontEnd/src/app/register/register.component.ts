import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  public registerForm!: FormGroup;

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      Usuario1: ['', [Validators.required, Validators.maxLength(50)]],
      Pass: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required]],
      FechaCreacion: [new Date(), []]
    });
  }

  onSubmit(): void {
    if (this.registerForm.valid) {
      console.log('Register data', this.registerForm.value);
    }
  }
}
