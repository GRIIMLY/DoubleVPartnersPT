import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router,
} from '@angular/router';
import { Observable } from 'rxjs';


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
      debugger
    if (sessionStorage.getItem("Usuario1") == null) {
      //route
      this.router.navigateByUrl("");
      return false;
    }
    else {
      return true;
    }
  }
}
