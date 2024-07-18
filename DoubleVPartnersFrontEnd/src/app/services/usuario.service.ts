import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import * as CryptoJS from 'crypto-js';
import { Usuario } from '../models/usuario-model';
import { Constantes } from '../constants/constantes-globales.constants';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient) { }

  controlador = "usuario/v1";

  registrarUsuario(usuario: Usuario): Observable<Usuario> {
    usuario.pass = CryptoJS.AES.encrypt(
      usuario.pass!,
      Constantes.KEY_PSW
    ).toString();
    return this.http.post<Usuario>(`${environment.APIBackend}${this.controlador}`, usuario);
  }

  getUsuarioByUsuario1AndPass(usuario: Usuario): Observable<Usuario> {
    usuario.pass = CryptoJS.AES.encrypt(
      usuario.pass!,
      Constantes.KEY_PSW
    ).toString();
    return this.http.post<Usuario>(`${environment.APIBackend}${this.controlador}/GetUsuarioByUsuario1AndPass`, usuario);
  }

  getUsuarioByUsuario1(usuario: string): Observable<Usuario> {
    return this.http.get<Usuario>(`${environment.APIBackend}${this.controlador}/GetUsuarioByUsuario1/${usuario}`);
  }
}
