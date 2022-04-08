import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { ingatlanModel } from './ingatlan.model';
import { kategoriaModel } from './kategoria.model';

@Injectable({
  providedIn: 'root'
})
export class IngatlanService {

  constructor(private http:HttpClient) {

   }
   getIngatlanok(): Observable<ingatlanModel[]> {
     return this.http.get<ingatlanModel[]>("http://localhost:5000/api/ingatlan");
   }
   getKategoriak(): Observable<kategoriaModel[]> {
    return this.http.get<kategoriaModel[]>("http://localhost:5000/api/kategoriak");
  }

  insertIngatlan(ingatlan:ingatlanModel) {
    var seged = {
      "kategoriaId": Number(ingatlan.kategoriaId),
      "leiras": ingatlan.leiras,
      "hirdetesDatuma": ingatlan.hirdetesDatuma,
      "tehermentes": ingatlan.tehermentes,
      "kepUrl": ingatlan.kepUrl,
    }

    this.http.post("http://localhost:5000/api/ujingatlan", seged).subscribe();
  }
}
