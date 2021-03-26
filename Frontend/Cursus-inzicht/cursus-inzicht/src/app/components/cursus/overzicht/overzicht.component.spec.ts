import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { CursusInstantieService } from 'src/app/services/cursusInstantie/cursus-instantie.service';

import { OverzichtComponent } from './overzicht.component';

describe('OverzichtComponent', () => {
    let sut: OverzichtComponent;
    let mockCursusInstantieService: CursusInstantieService;
  
    mockCursusInstantieService = jasmine.createSpyObj('mockCursusInstantieService', ['getAll']);
  
    beforeEach(() => {
      TestBed.configureTestingModule({
        declarations: [OverzichtComponent],
        imports: [HttpClientModule],
        providers: [
          {provide: CursusInstantieService, useValue: mockCursusInstantieService}]
    });
      it('should get all cursusInstanties', () =>{
        sut.ngOnInit();
        expect(mockCursusInstantieService.getAll).toHaveBeenCalled();
      })
    });
  });