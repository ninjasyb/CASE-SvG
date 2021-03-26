import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { CursusService } from 'src/app/services/cursusService/cursus.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { CursusComponent } from './cursus.component';
import { BrowserModule } from '@angular/platform-browser';

describe('CursusComponent', () => {
  let sut: CursusComponent;
  let mockCursusService: CursusService;
  mockCursusService = jasmine.createSpyObj('mockCursusService', ['getAll']);

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CursusComponent],
      imports: [HttpClientModule],
      providers: [
        {provide: CursusService, useValue: mockCursusService}]
  });

    it('should get all Cursussen', () =>{
      sut.ngOnInit();
      expect(mockCursusService.getAll).toHaveBeenCalled();
    })
  });
});