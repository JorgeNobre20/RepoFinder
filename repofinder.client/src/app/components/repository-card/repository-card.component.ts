import { Component, Input } from '@angular/core';
import { RepositoryModel } from '../../models';

@Component({
  selector: 'app-repository-card',
  templateUrl: './repository-card.component.html',
  styleUrl: './repository-card.component.css'
})
export class RepositoryCardComponent {
  @Input("repository") public repository: RepositoryModel | null = null;
}
