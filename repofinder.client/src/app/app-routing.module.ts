import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MyRepositoriesComponent } from './pages/my-repositories/my-repositories.component';
import { RepositoryDetailsComponent } from './pages/repository-details/repository-details.component';

const routes: Routes = [
  { path: '', redirectTo: '/my-repositories', pathMatch: 'full' },
  {
    path: 'my-repositories',
    component: MyRepositoriesComponent,
  },
  {
    path: 'repository-details/:githubUsername/:repositoryName',
    component: RepositoryDetailsComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
