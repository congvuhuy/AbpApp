import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProvinceService {
  private apiUrl = 'https://localhost:44370/api/app/province';
  constructor(private http: HttpClient) {}

  getProvinces(Sorting:string,SkipCount:number,MaxResultCount): Observable<any> {
    let params = new HttpParams()
      .set('Sorting', Sorting)
      .set('SkipCount', SkipCount.toString())
      .set('MaxResultCount', MaxResultCount.toString());
    return this.http.get<any>(`${this.apiUrl}`,{params});
  }

  getProvince(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  createProvince(body:{}): Observable<any> {
    return this.http.post<any>(this.apiUrl,JSON.stringify(body),{});
  }

  // updateProvince(id: number, province: UpdateProvinceDto): Observable<Province> {
  //   return this.http.put<Province>(`${this.apiUrl}/${id}`, province);
  // }
  //
  // deleteProvince(id: number): Observable<void> {
  //   return this.http.delete<void>(`${this.apiUrl}/${id}`);
  // }
}
