import { Content } from '@angular/compiler/src/render3/r3_ast';
import { Component, OnInit } from '@angular/core';
import { TextFile } from 'src/app/models/textFile';
import { UploadService } from 'src/app/services/upload/upload.service';

@Component({
  selector: 'upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {
  fileContent: TextFile= {content:""};
  newCursussen: number;
  newInstanties: number; 
  readyLoading = false;

  constructor(private uploadService: UploadService) { }

  ngOnInit(): void {
  }

  handleFileInput(files: FileList) {
      this.submit(files.item(0));
    }

    submit(file: File){
      let reader = new FileReader();
      reader.onloadend = ((e)=>{
        this.fileContent.content = reader.result.toString().trim();
        this.uploadText(this.fileContent);
      })
      reader.readAsText(file);
    }

    uploadText(fileContent: TextFile){
      this.uploadService
        .postFile(fileContent)
        .subscribe((uploadResult)=>{
          this.newCursussen = uploadResult.newCursussen;
          this.newInstanties = uploadResult.newInstanties;
          this.readyLoading= true;
        })
    }
}