import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SearchComponent } from './modules/search/search.component';
import { SearchHistoryComponent } from './modules/search-history/search-history.component';

const routes: Routes = [
  {path:'',redirectTo:"Home",pathMatch:"full"},
  {path:"Home",component:SearchComponent},
  {path:"History",component:SearchHistoryComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

 }
