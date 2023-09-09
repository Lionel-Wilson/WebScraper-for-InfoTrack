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

  public formatUserFriendlyDate(dateString: string): string {
    // Parse the input date string into a Date object
    const date = new Date(dateString);
  
    // Check if the date is valid
    if (isNaN(date.getTime())) {
      return "Invalid Date";
    }
  
    // Define months and days for formatting
    const months = [
      "January", "February", "March", "April",
      "May", "June", "July", "August",
      "September", "October", "November", "December"
    ];
  
    // Extract date components
    const year = date.getFullYear();
    const month = months[date.getMonth()];
    const day = date.getDate();
    const hours = date.getHours();
    const minutes = date.getMinutes();
    const seconds = date.getSeconds();
  
    // Format the date string in a user-friendly way
    const formattedDate = `${month} ${day}, ${year} ${hours}:${minutes}:${seconds}`;
  
    return formattedDate;
  }
  




}
