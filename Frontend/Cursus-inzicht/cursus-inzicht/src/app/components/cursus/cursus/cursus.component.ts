import { Component, OnInit } from '@angular/core';
import { Cursus } from 'src/app/models/cursus';
import { CursusService } from 'src/app/services/cursusService/cursus.service';

@Component({
  selector: 'cursus',
  templateUrl: './cursus.component.html',
  styleUrls: ['./cursus.component.css']
})
export class CursusComponent implements OnInit {
  cursussen: Cursus[];
  isLoadingCursussen = true;
  
  constructor(private cursusService: CursusService) { }

  ngOnInit(): void {
    this.cursusService
    .getAll()
    .subscribe((arr)=> {
      this.cursussen = arr;
      this.isLoadingCursussen = false;
    })
  }
}
