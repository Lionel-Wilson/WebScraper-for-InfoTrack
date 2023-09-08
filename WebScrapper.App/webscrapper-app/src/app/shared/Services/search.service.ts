import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { SearchEngine } from '../Interfaces/search-engine';
import { SearchHistory } from '../Interfaces/search-history';


@Injectable({
  providedIn: 'root'
})
export class SearchService {

  private SearchServiceBaseUrl = 'https://localhost:7287';

  constructor(private http: HttpClient) { 
  }

  public SearchWeb(keywords:string,searchEngineId:number) {
    const requestUrl = `${this.SearchServiceBaseUrl}/Search?keywords=${keywords}&searchEngineId=${searchEngineId}`
    return this.http.get<Array<number>>(requestUrl);
  }

  getSearchHistory() {
    return this.http.get<Array<SearchHistory>>(this.SearchServiceBaseUrl+"/History");
  }

  
}
