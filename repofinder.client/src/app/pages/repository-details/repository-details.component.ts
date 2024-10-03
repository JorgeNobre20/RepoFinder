import { Component } from '@angular/core';
import { RepositoryModel } from '../../models';
import { RepositoryService } from '../../services/repository.service';
import { ActivatedRoute } from '@angular/router';
import { ApiResponseError } from '../../errors/ApiResponseError';

@Component({
  selector: 'app-repository-details',
  templateUrl: './repository-details.component.html',
  styleUrl: './repository-details.component.css'
})
export class RepositoryDetailsComponent {
 
  public repository: RepositoryModel | null = null;
  public isLoading: boolean = true;
  public error: string | null = null;

  constructor(private RepositoryService: RepositoryService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    const githubUsername = this.route.snapshot.paramMap.get('githubUsername') || ''
    const repositoryName = this.route.snapshot.paramMap.get('repositoryName') || ''

    this.RepositoryService.getRepositoryByNameAndOwner(githubUsername, repositoryName).subscribe({
      next: (repository) => {
        this.repository = repository;
        this.isLoading = false;
      },

      error: (error: ApiResponseError) => {
        this.error = error.message;
        this.isLoading = false;
      },
    });
  }
}
