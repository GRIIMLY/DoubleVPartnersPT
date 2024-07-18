import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { Persona } from 'src/app/models/persona-model';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent {
  personaForm!: FormGroup;
  tiposIdentificacion: string[] = ['Cedula de ciudadania', 'Pasaporte', 'Tarjeta de identidad'];

  constructor(private fb: FormBuilder, private personaService: PersonaService, private messageService: MessageService,) { }

  ngOnInit(): void {
    this.personaForm = this.fb.group({
      Identificador: [null, []],
      Nombres: ['', Validators.required],
      Apellidos: ['', Validators.required],
      NumeroIdentificacion: ['', Validators.required],
      Email: ['', [Validators.required, Validators.email]],
      TipoIdentificacion: ['Cedula de ciudadania', Validators.required],
      FechaCreacion: [new Date()],
      NumeroIdentificacionConcatenado: [''],
      NombresApellidosConcatenados: [''],
      UsuarioId: [''],
    });
    this.getPersonaUsuario();
  }

  onSubmit(): void {
    if (this.personaForm.valid) {
      const persona: Persona = this.personaForm.value;
      persona.NumeroIdentificacionConcatenado = `${persona.TipoIdentificacion}-${persona.NumeroIdentificacion}`;
      persona.NombresApellidosConcatenados = `${persona.Nombres} ${persona.Apellidos}`;
      persona.UsuarioId = +sessionStorage.getItem("IdUsuario")?.toString()!;
      if (persona.Identificador == null) {
        this.personaService.registrarPersona(persona).subscribe(response => {
          this.messageService.add({
            severity: 'success',
            summary: "Se registra la persona exitosamente",
            detail: "",
          });
          this.getPersonaUsuario();
        });
      } else {
        this.personaService.actualizarPersona(persona).subscribe(response => {
          this.messageService.add({
            severity: 'success',
            summary: "Se actualiza la persona exitosamente",
            detail: "",
          });
        });
      }
    }
  }

  getPersonaUsuario() {
    this.personaService.getPersonaPorIdUsuario(+sessionStorage.getItem("IdUsuario")?.toString()!).subscribe(response => {
      if (response) {
        var personaFormateado = this.convertirPrimeraLetraMayuscula(response);
        this.personaForm.setValue(personaFormateado);
      }
    });
  }

  public convertirPrimeraLetraMayuscula(objeto: any) {
    if (!objeto || typeof objeto !== 'object') {
      return objeto;
    }

    var nuevoObjeto: any = {};
    Object.keys(objeto).forEach(clave => {
      const primeraLetraMayuscula = clave.charAt(0).toUpperCase() + clave.slice(1);
      nuevoObjeto[primeraLetraMayuscula] = objeto[clave];

      if (objeto[clave] && typeof objeto[clave] === 'object') {
        nuevoObjeto[primeraLetraMayuscula] = this.convertirPrimeraLetraMayuscula(objeto[clave]);
      }
    });

    return nuevoObjeto;
  }
}
