import { HttpClient } from '@angular/common/http';
import { Content } from '@angular/compiler/src/render3/r3_ast';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { TextFile } from 'src/app/models/textFile';
import { UploadResult } from 'src/app/models/uploadResult';

@Injectable({
  providedIn: 'root'
})
export class UploadService {

  constructor(private httpClient: HttpClient) { }

  postFile(fileContent: TextFile): Observable<UploadResult> {
    const endpoint = 'https://localhost:44381/api/cursusinstanties/fileUpload';
    
    return this.httpClient
      .post<UploadResult>(endpoint, fileContent)
  }
}
