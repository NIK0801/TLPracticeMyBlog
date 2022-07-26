import { Injectable } from "@angular/core";
import { IPost } from './interface.interface';
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class PostService {
  private readonly apiUrl: string = 'http://localhost:4200/rest/post';

  constructor(private httpClient: HttpClient) {
  }

  public create(post: IPost): Observable<null> {
    return this.httpClient.post<null>(`${this.apiUrl}/create`, post)
  }

  public getAll(): Observable<IPost[]> {
    return this.httpClient.get<IPost[]>(`${this.apiUrl}/list`);
  }
  public getById(id: number): Observable<IPost> {
    return this.httpClient.get<IPost>(`${this.apiUrl}/${id}`);
  }

  public update(post: IPost): Observable<null> {
    return this.httpClient.post<null>(`${this.apiUrl}/update`, post)
  }

  public delete(id: number): Observable<object> {
    return this.httpClient.delete<object>(`${this.apiUrl}/${id}/delete`)
  }
}
