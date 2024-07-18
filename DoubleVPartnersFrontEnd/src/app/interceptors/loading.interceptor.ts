import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoadingService } from '../services/loading.service';
import { finalize } from 'rxjs/operators';
/**
 * Interceptor para gestionar cuando se debe mostrar la pantalla de carga y cuando no
 * @author: nmorales
 * @since: 7/17/2024
 */
@Injectable()
export class LoadingInterceptor implements HttpInterceptor {
  private totalRequests = 0;

  constructor(private loadingService: LoadingService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler) {
    this.totalRequests++;
    // se define que hay una peticion en progreso
    //this.loadingService.setLoading(true);

    this.loadingService.setLoading(true);

    // se controla cuando todas las peticiones estan finalizadas para quitar el loading
    return next.handle(request).pipe(
      finalize(() => {
        try {
          this.totalRequests--;
          if (this.totalRequests === 0) {
            this.loadingService.setLoading(false);
          }
        } catch (error) {}
      })
    );
  }
}
