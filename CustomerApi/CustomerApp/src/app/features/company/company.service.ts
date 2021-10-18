import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from 'src/app/models/company.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(private http: HttpClient) { }

  getAll():Observable<Company[]>{
    return this.http.get<Company[]>(environment.apiUrl + 'company')
  }

  getById(id : number) : Observable<Company>{
    return this.http.get<Company>(environment.apiUrl + 'company/' + id)
  }

  create(company : Company) : Observable<Company>{
    return this.http.post<Company>(environment.apiUrl + 'company', company);
  }

  update(company : Company):Observable<Company>{
    return this.http.put<Company>(environment.apiUrl + 'company', company);
  }
}
