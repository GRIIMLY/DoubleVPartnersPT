import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PerfilComponent } from './perfil/perfil.component';
import { PagesComponent } from './pages.component';
import { LoginGuardGuard } from '../services/guards/login-guard.guard';
import { PersonasComponent } from './personas/personas.component';

const routes: Routes = [
  {
    path: '',
    component: PagesComponent,
    canActivate: [LoginGuardGuard],
    children: [{ path: 'perfil', component: PerfilComponent }, { path: 'personas', component: PersonasComponent }]
  },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
