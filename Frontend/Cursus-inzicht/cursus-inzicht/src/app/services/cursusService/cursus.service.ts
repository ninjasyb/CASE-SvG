import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Cursus } from '../../models/cursus';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class CursusService {
  cursussen: Cursus[] = [];
  subject = new Subject<Cursus[]>();
    
  constructor(private httpClient: HttpClient){}

  getAll(): Observable<Cursus[]> {
      return this.httpClient
        .get<Cursus[]>('https://localhost:44381/api/Cursus')
      }
   

      //deze functie is voor een volgende slice, dus nog niet getest.
    add(newCursus: Cursus) {
      this.httpClient
          .post<Cursus>("https://localhost:44381/api/cursus", newCursus)
          .subscribe((newCursus)=>{
              this.cursussen.push(newCursus);
              this.subject.next(this.cursussen);
          });
  }
}
