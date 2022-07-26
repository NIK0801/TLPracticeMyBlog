import { Injectable } from "@angular/core";
import { ICategory } from './interface.interface';
import { Observable } from "rxjs";
import { HttpClient, HttpParams, HttpRequest } from "@angular/common/http";

@Injectable()
export class CategoryService {
  [x: string]: any;
  private readonly apiUrl: string = 'http://localhost:4200/rest/category';

  constructor(private httpClient: HttpClient) {
  }

  public create(category: ICategory): Observable<null> {
    return this.httpClient.post<null>(`${this.apiUrl}/create`, category)
  }

  public getAll(): Observable<ICategory[]> {
    return this.httpClient.get<ICategory[]>(`${this.apiUrl}/list`);
  }

  public update(category: ICategory): Observable<null> {
    return this.httpClient.post<null>(`${this.apiUrl}/update`, category)
  }

  public delete(id: number): Observable<object> {
    return this.httpClient.delete<object>(`${this.apiUrl}/${id}/delete`)
  }
}

