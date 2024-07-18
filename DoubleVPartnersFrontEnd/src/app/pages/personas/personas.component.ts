import { Component } from '@angular/core';
import { Persona } from 'src/app/models/persona-model';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-personas',
  templateUrl: './personas.component.html',
  styleUrls: ['./personas.component.scss']
})
export class PersonasComponent {
  personas!: Persona[];

  constructor(private personaService: PersonaService) { }

  ngOnInit(): void {
    this.personaService.GetPersonasSP().subscribe((data:any) => {
      this.personas = data;
    });
  }
}
