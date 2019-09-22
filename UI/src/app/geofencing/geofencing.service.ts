import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AddressSearchResult } from './geofencing.model';

@Injectable()
export class GeofencingService  {
    apiURL: string = "https://localhost:44356/api/geofence";

    constructor(
        public httpClient: HttpClient) {
    }

    public addressSearch(address: string): Observable<AddressSearchResult[]> {
        return this.httpClient.get<AddressSearchResult[]>(`${this.apiURL}/autocomplete/${address}`);
    }

    public getGeocode(gnafId: string, displayLine: string): Observable<AddressSearchResult> {
        return this.httpClient.get<AddressSearchResult>(`${this.apiURL}/geocode/${gnafId}/${displayLine}`);
    }
}