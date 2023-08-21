import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AplicacaoRequest } from '../shared/aplicacao-request';
import { AplicacaoResponse } from '../shared/aplicacao-response';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })
export class AplicacaoService {    
    url!: string;
    private readonly baseUrl = "https://localhost:7054/";

    constructor(private httpClient: HttpClient) {
        this.url = `${ this.baseUrl }api/calculadora/CDB`;
    }
    
    calcular(aplicacaoRequest: AplicacaoRequest): Observable<AplicacaoResponse> {
        return this.httpClient.post<AplicacaoResponse>(this.url, aplicacaoRequest);
    }

}
