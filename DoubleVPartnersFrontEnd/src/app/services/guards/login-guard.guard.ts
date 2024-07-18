import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router,
} from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from '../login.service';
import { AuditoriaService } from '../pages/auditoria.service';
import { SesionVariablesService } from '../pages/sesion-variables.service';

@Injectable({
  providedIn: 'root',
})
export class LoginGuardGuard implements CanActivate {
  /**
   *Constructor del guard
   *
   * @param router
   */
  constructor(
    public router: Router,
    public auditoriaService: AuditoriaService,
    private loginService: LoginService,
    private sesionService: SesionVariablesService
  ) { }

  /**
   * metodo para proteger las vistas del sistema /pages
   *
   * @param route
   * @param state
   * @returns {boolean}  si tiene permitido o no el acceso
   * @author: NMG
   */
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    this.auditoriaService.construirUsuario();
    if (this.sesionService.sesionObj?.UsuarioSesion == undefined ||this.sesionService.sesionObj?.UsuarioSesion == null) {
      //route
      this.router.navigateByUrl("/noautenticado/login");
      return false;
    }
    else {
      return true;
    }
  }
}
