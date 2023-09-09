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


  }

  public searchWeb(keywords:string,searchEngineId:number){

    if(keywords && searchEngineId){
      this.searchService.SearchWeb(keywords,searchEngineId).subscribe(response=>{
        this.ranking = response;
        console.log("this is the ranking:"+this.ranking);
        this.resultsText = `www.infotrack.co.uk ranked #${response[0]} on Google.`;
      });
    }
    else{
      console.log("please type something and choose a search engine");
    }

  }


  public resultTextProducer( rankingArray:Array<number>,searchEngineId:number) {

    
    return `www.infotrack.co.uk ranked #${rankingArray[0]} on ${this.searchEngines}.`;
  }

/*
  public convertStringToList(rankingString:string){
    let arrayOfNumbers: number[] ;

    if(rankingString.includes(",")){
      arrayOfNumbers = rankingString.split(',').map(Number);
      console.log(arrayOfNumbers);

      return arrayOfNumbers;
    }
    else{
      arrayOfNumbers = [Number(rankingString)] ;
      console.log(arrayOfNumbers);
      return arrayOfNumbers;
    }
  }*/
}
