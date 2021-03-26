import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { CursusInstantie } from '../../models/cursusinstantie';

@Injectable({
  providedIn: 'root'
})
export class CursusInstantieService {

  cursusInstanties: CursusInstantie[] = [];
  subject = new Subject;


  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<CursusInstantie[]>{
    return this.httpClient
    .get<CursusInstantie[]>('https://localhost:44381/api/Cursusinstanties')
  }


  //deze functie is voor een volgende slice, dus nog niet getest
  add(cursusinstantie: CursusInstantie){
    this.httpClient
      .post<CursusInstantie>('https://localhost:44381/api/Cursusinstanties', cursusinstantie)
      .subscribe((cursusinstantie) =>{
        this.cursusInstanties.push(cursusinstantie);
        this.subject.next(this.cursusInstanties);
      })
  }
}
