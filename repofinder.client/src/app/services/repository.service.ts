import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RepositoryModel } from '../models';
import { Observable } from 'rxjs';
import { Pagination } from '../utils/Pagination';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {
  private API_BASE_URL: string = "https://localhost:7108/api";

  constructor(private http: HttpClient) { }

  getMyRepositories(): Observable<RepositoryModel[]> {
    const requestUrl = `${this.API_BASE_URL}/github/repositories/JorgeNobre20`;
    console.log(requestUrl)
    return this.http.get<RepositoryModel[]>(requestUrl);
  }

  getRepositoryByNameAndOwner(githubUsername: string, repositoryName: string): Observable<RepositoryModel> {
    const requestUrl = `${this.API_BASE_URL}/github/repositories/${githubUsername}/${repositoryName}`;
    return this.http.get<RepositoryModel>(requestUrl);
  }
}
