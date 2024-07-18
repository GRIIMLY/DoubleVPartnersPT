import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { PagesComponent } from './pages.component';
import { PerfilComponent } from './perfil/perfil.component';
import { PrimengModule } from '../primeng/primeng.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { PersonasComponent } from './personas/personas.component';


@NgModule({
  declarations: [
    PerfilComponent,
    PagesComponent,
    PersonasComponent

  ],
  imports: [
    CommonModule,
    PagesRoutingModule,
    PrimengModule,
    ReactiveFormsModule
  ],
})
export class PagesModule { }
