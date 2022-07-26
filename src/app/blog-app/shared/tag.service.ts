import { Injectable } from "@angular/core";
import { ITag } from './interface.interface';
import { Observable } from "rxjs";
import { HttpClient, HttpParams, HttpRequest } from "@angular/common/http";

@Injectable()
export class TagService {
  private readonly apiUrl: string = 'http://localhost:4200/rest/Tag';

  constructor(private httpClient: HttpClient) {
  }

  public create(tag: ITag): Observable<null> {
    return this.httpClient.post<null>(`${this.apiUrl}/create`, tag)
  }

  public getAll(): Observable<ITag[]> {
    return this.httpClient.get<ITag[]>(`${this.apiUrl}/list`);
  }

  public update(tag: ITag): Observable<null> {
    return this.httpClient.post<null>(`${this.apiUrl}/update`, tag)
  }

  public delete(id: number): Observable<object> {
    return this.httpClient.delete(`${this.apiUrl}/delete/${id}`)
  }
}
