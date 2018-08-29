import { Injectable } from '@angular/core';
import { AirportRequest } from '../models/airport-request';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AirportDataService {

  constructor(private http: HttpClient) { }

  public getAirportData(requestBody: AirportRequest): Observable<any> {
    return this.http.post('/api/getAirports', requestBody)
  } 
}
