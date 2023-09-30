// persona.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  private apiUrl = 'URL_de_tu_API';  // Reemplaza con la URL de tu API

  constructor(private http: HttpClient) { }

  getClientes(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/personas`);
  }

  // Otros métodos para crear, actualizar y eliminar personas
}
