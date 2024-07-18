import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

/**
 * Servicio para gestionar la variable del loading con patron Singleton
 * @author: nmorales
 * @since: 7/17/2024
 */
@Injectable({
  providedIn: 'root',
})
export class LoadingService {
  private isLoading$$ = new BehaviorSubject<boolean>(false);
  isLoading$ = this.isLoading$$.asObservable();

  constructor() {}

  /**
   * @method : metodo para definir la variable mostrar o no de pantalla de cargar
   * @author: nmorales
   * @since: 7/17/2024
   */
  setLoading(isLoading: boolean) {
    this.isLoading$$.next(isLoading);
  }
}
