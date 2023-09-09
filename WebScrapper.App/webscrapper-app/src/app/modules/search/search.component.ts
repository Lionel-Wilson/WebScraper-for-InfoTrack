import { SearchEngine } from './../../shared/Interfaces/search-engine';
import { Component } from '@angular/core';
import { SearchHistory } from 'src/app/shared/Interfaces/search-history';
import { SearchService } from 'src/app/shared/Services/search.service';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent {  

  public ranking: Array<number> =[];
  public searchHistory: Array<SearchHistory> =[];

  public searchTerms: string ='' ;
  public selectedSearchEngineId: number | undefined ;
  public searchEngines : Array<SearchEngine> =[];

  public resultsText :string = "Results appear here"

  constructor(private searchService:SearchService){
      this.getSearcEngines();


  }

  public searchWeb(keywords:string,searchEngineId:number){

    if(keywords && searchEngineId){
      this.searchService.SearchWeb(keywords,searchEngineId).subscribe(response=>{
        this.ranking = response;
        console.log("this is the ranking:"+this.ranking);
        this.resultsText = this.resultTextProducer(response,searchEngineId,keywords);
      });
    }
    else{
      console.log("please type something and choose a search engine");
    }

  }


  public resultTextProducer( rankingArray:Array<number>,searchEngineId:number,keywords:string) {
    let rankNumber = rankingArray[0];
    let rankNumberPosition = "st";
    if(rankNumber != 0){
      // Ensure the number is within the valid range
      if (rankNumber < 0 || rankNumber > 100) {
        rankNumberPosition= 'Invalid';
      }

      // Special cases for 11, 12, and 13
      else if (rankNumber >= 11 && rankNumber <= 13) {
        rankNumberPosition= 'th';
      }
      else{
      // Extract the last digit
      const lastDigit = rankNumber % 10;

      // Determine the position string based on the last digit
      switch (lastDigit) {
        case 1:
          rankNumberPosition= 'st';
          break
        case 2:
          rankNumberPosition= 'nd';
          break
        case 3:
          rankNumberPosition= 'rd';
          break
        default:
          rankNumberPosition= 'th';
      }
      }
        
        return `www.infotrack.co.uk ranked ${rankNumber}${rankNumberPosition} on ${this.searchEngines.find(engine=> engine.id == searchEngineId)?.name} for the search term "${keywords}"`;
    }

    return `www.infotrack.co.uk didn't rank in the top 100 results for the search term "${keywords}". Looks like we need to work on our SEO.`;
 
  }

  public getSearcEngines(){
    this.searchService.getSearchEngines().subscribe(response=>{
      this.searchEngines = response;

    })
  }


}
