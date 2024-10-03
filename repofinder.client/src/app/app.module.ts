import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MyRepositoriesComponent } from './pages/my-repositories/my-repositories.component';
import { RepositoryDetailsComponent } from './pages/repository-details/repository-details.component';
import { RepositoryGridComponent } from './components/repository-grid/repository-grid.component';
import { RepositoryCardComponent } from './components/repository-card/repository-card.component';
import { LoadingComponent } from './components/loading/loading.component';

@NgModule({
  declarations: [
    AppComponent,
    MyRepositoriesComponent,
    RepositoryDetailsComponent,
    RepositoryGridComponent,
    LoadingComponent,
    RepositoryCardComponent
  ],
  imports: [
    BrowserModule, 
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
