import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AddressSearchResult } from './geofencing.model';
import { environment } from 'src/environments/environment';
import { QuestionGroupModel } from '../survey/survey.component';

@Injectable()
export class GeofencingService  {

    constructor(
        public httpClient: HttpClient) {
    }

    public addressSearch(address: string): Observable<AddressSearchResult[]> {
        return this.httpClient.get<AddressSearchResult[]>(`${environment.apiURL}/autocomplete/${address}`);
    }

    public getGeocode(gnafId: string, displayLine: string): Observable<AddressSearchResult> {
        return this.httpClient.get<AddressSearchResult>(`${environment.apiURL}/geocode/${gnafId}/${displayLine}`);
    }

    public getQuestionGroup(questionGroupId: number, languageId: number): Observable<any> {
        return this.httpClient.get<QuestionGroupModel>(`${environment.apiURL}/questiongroup/${questionGroupId}/language/${languageId}`);
    }
}
