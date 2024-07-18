import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { Usuario } from '../models/usuario-model';
import { UsuarioService } from '../services/usuario.service';
import { Router } from '@angular/router';
import * as CryptoJS from 'crypto-js';
import { Constantes } from '../constants/constantes-globales.constants';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm!: FormGroup;

  constructor(private fb: FormBuilder, private messageService: MessageService,
    public usuarioService: UsuarioService, public router: Router,

  ) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      usuario1: ['', [Validators.required, Validators.maxLength(50)]],
      pass: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(50)]]
    });
  }

  async onSubmit() {
    if (this.loginForm.valid) {
      await this.usuarioService.getUsuarioByUsuario1(this.loginForm.controls['usuario1'].value).subscribe(response => {
        if (response == null) {
          this.messageService.add({
            severity: 'info',
            summary: "Usuario no existente",
            detail: "",
          });
          return;
        }
        if (CryptoJS.AES.decrypt(response.pass!, Constantes.KEY_PSW).toString(CryptoJS.enc.Utf8) != this.loginForm.controls['pass'].value) {
          this.messageService.add({
            severity: 'info',
            summary: "Credenciales incorrectas",
            detail: "",
          });
        } else {
          sessionStorage.setItem("Usuario1", response.usuario1!)
          sessionStorage.setItem("IdUsuario", response.identificador?.toString()!)
          this.router.navigate(["pages/perfil"]);
        }

      });

    }
  }
}
