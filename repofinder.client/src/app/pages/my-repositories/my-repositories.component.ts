import { Component, OnInit } from '@angular/core';
import { RepositoryModel } from '../../models';
import { RepositoryService } from '../../services/repository.service';
import { ApiResponseError } from '../../errors/ApiResponseError';

@Component({
  selector: 'app-my-repositories',
  templateUrl: './my-repositories.component.html',
  styleUrl: './my-repositories.component.css',
})
export class MyRepositoriesComponent implements OnInit {
  public repositories: RepositoryModel[] = [];
  public isLoading: boolean = true;
  public error: string | null = null;

  constructor(private RepositoryService: RepositoryService) {}

  ngOnInit(): void {
    this.RepositoryService.getMyRepositories().subscribe({
      next: (repositories) => {
        this.repositories = repositories;
        this.isLoading = false;
      },

      error: (error: ApiResponseError) => {
        console.log(error)
        this.error = error.message;
        this.isLoading = false;
      },
    });
  }
}
