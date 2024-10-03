export interface Pagination<T> {
  itemsPerPage: number;
  count: number;
  totalPages: number;
  items: T[]
}