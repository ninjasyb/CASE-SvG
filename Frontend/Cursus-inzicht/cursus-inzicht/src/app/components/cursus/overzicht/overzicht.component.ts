import { Component, OnInit } from '@angular/core';
import { Cursus } from 'src/app/models/cursus';
import { CursusCompleet } from 'src/app/models/cursuscompleet';
import { CursusInstantie } from 'src/app/models/cursusinstantie';
import { CursusInstantieService } from 'src/app/services/cursusInstantie/cursus-instantie.service';
import { CursusService } from 'src/app/services/cursusService/cursus.service';


@Component({
  selector: 'overzicht',
  templateUrl: './overzicht.component.html',
  styleUrls: ['./overzicht.component.css']
})
export class OverzichtComponent implements OnInit {
  cursusinstanties: CursusInstantie[];
  cursussen: Cursus[];
  cursussenCompleet: CursusCompleet[] =[];
  cursusCompleetSorted: CursusCompleet[] = [];
  isLoading= true;

  constructor(
    private cursusinstantieService: CursusInstantieService,
    private cursusService: CursusService) { }

  ngOnInit(): void {
    this.cursusService
      .getAll()
      .subscribe((arr)=>{
        this.cursussen=arr;
        this.cursusinstantieService
        .getAll()
        .subscribe((arra)=>{
          for (let cursusinstantie of arra){
            for (let cursus of this.cursussen){
              if(cursus.id === cursusinstantie.cursusId){
                  let cursusCompleet = {
                    id: cursusinstantie.cursusId,
                    titel: cursus.titel,
                    cursusCode: cursus.cursusCode,
                    duur: cursus.duur,
                    startdatum: cursusinstantie.startdatum
                  }              
                  this.cursussenCompleet.push(cursusCompleet);
                }
              }
            }
        })
        this.cursusCompleetSorted = this.cursussenCompleet.sort((a, b) => new Date(b.startdatum).getTime() - new Date(a.startdatum).getTime());
        this.isLoading=false;
      })
  }
}
