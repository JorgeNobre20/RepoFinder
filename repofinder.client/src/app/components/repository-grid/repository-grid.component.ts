import { Component, Input } from '@angular/core';
import { RepositoryModel } from '../../models';

@Component({
  selector: 'app-repository-grid',
  templateUrl: './repository-grid.component.html',
  styleUrl: './repository-grid.component.css'
})
export class RepositoryGridComponent {
  @Input("repositories") repositories: RepositoryModel[] = [];
  @Input("isLoading") isLoading: boolean = true;
  @Input("error") error: string | null = null;
}
