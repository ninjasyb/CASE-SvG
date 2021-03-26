import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { TextFile } from 'src/app/models/textFile';
import { UploadService } from 'src/app/services/upload/upload.service';

import { UploadComponent } from './upload.component';

describe('UploadComponent', () => {
  let sut: UploadComponent;
  let mockUploadService: UploadService;
  let fileContent: TextFile= {content:"ContentForTesting"};
  
  mockUploadService = jasmine.createSpyObj('mockUploadService', ['postFile']);

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UploadComponent],
      imports: [HttpClientModule],
      providers: [
        {provide: UploadService, useValue: mockUploadService}]
  });
    it('should post file contents'), () => {
      sut.uploadText(fileContent);
      expect(mockUploadService.postFile).toHaveBeenCalled();
    } 
  });
});
