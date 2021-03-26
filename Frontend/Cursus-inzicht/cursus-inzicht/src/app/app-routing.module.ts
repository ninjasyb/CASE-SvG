import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { OverzichtComponent } from './components/cursus/overzicht/overzicht.component';
import { CursusComponent } from './components/cursus/cursus/cursus.component';
import { HomeComponent } from './components/home/home.component';
import { UploadComponent } from './components/upload/upload.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'overzicht', component: OverzichtComponent },
  { path: 'cursussen', component: CursusComponent },
  { path: 'upload', component: UploadComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
