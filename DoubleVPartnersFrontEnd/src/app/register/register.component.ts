import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { UsuarioService } from '../services/usuario.service';
import { MustMatch } from '../validators/validator';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  public registerForm!: FormGroup;
  /**
   * evento para cerrar la modal de registro
   * @property {EventEmitter<void>}
   */
  @Output()
  public evtCerrarModal = new EventEmitter<void>();

  constructor(private fb: FormBuilder, private messageService: MessageService,
    public usuarioService: UsuarioService) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      usuario1: ['', [Validators.required, Validators.maxLength(50)]],
      pass: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', [Validators.required]],
      fechaCreacion: [new Date(), []]
    }, {
      validator: MustMatch('pass', 'confirmPassword')
    });
  }

  async onSubmit() {
    debugger
    if (this.registerForm.valid) {
     this.usuarioService.getUsuarioByUsuario1(this.registerForm.controls['usuario1'].value).subscribe(response => {
        if (response != null) {
          this.messageService.add({
            severity: 'info',
            summary: "El Usuario ya existe",
            detail: "",
          });
          return;
        }
        this.usuarioService.registrarUsuario(this.registerForm.value).subscribe(response => {
          this.messageService.add({
            severity: 'success',
            summary: "Registro exitoso",
            detail: "",
          });
          this.evtCerrarModal.emit();
        });

      });

    }
  }
}
