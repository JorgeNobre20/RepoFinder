export interface RepositoryModel {
  id: number;
  name: string;
  description: string | null;
  language: string | null;
  updatedAt: Date;
  owner: {
    id: number;
    login: string;
    avatarUrl: string;
  }
}