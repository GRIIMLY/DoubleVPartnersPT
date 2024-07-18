import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import * as CryptoJS from 'crypto-js';
import { Usuario } from '../models/usuario-model';
import { Constantes } from '../constants/constantes-globales.constants';
import { Persona } from '../models/persona-model';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  constructor(private http: HttpClient) { }

  controlador = "persona/v1";

  registrarPersona(persona: Persona): Observable<Persona> {
    return this.http.post<Persona>(`${environment.APIBackend}${this.controlador}`, persona);
  }

  actualizarPersona(persona: Persona): Observable<Persona> {
    return this.http.put<Persona>(`${environment.APIBackend}${this.controlador}`, persona);
  }

  getPersonaPorIdUsuario(IdUsuario: number): Observable<Persona> {
    return this.http.get<Persona>(`${environment.APIBackend}${this.controlador}/PorIdUsuario/${IdUsuario}`);
  }


  GetPersonasSP(): Observable<Persona> {
    return this.http.get<Persona>(`${environment.APIBackend}${this.controlador}/GetPersonasSP`);
  }


}
