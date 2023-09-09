import { Component,  } from '@angular/core';
import { SearchEngine } from 'src/app/shared/Interfaces/search-engine';
import { SearchHistory } from 'src/app/shared/Interfaces/search-history';
import { SearchService } from 'src/app/shared/Services/search.service';

@Component({
  selector: 'app-search-history',
  templateUrl: './search-history.component.html',
  styleUrls: ['./search-history.component.css']
})
export class SearchHistoryComponent {
  public searchHistory: Array<SearchHistory> =[];
  public searchEngines: Array<SearchEngine> =[];

  constructor(private searchService:SearchService) {
    this.getSearchHistory();
   }

  public getSearchHistory(){
    this.searchService.getSearchHistory().subscribe(response=>{
      this.searchHistory = response;
      console.log("this is the searchHistory:");
      console.log(this.searchHistory);
    })
  }

  public getSearcEngines(){
    this.searchService.getSearchEngines().subscribe(response=>{
      this.searchEngines = response;
      console.log("these are the search engines:"+this.searchHistory);
    })
  }




}
