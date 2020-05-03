import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CampsComponent } from './camps/camps.component';


const routes: Routes = [
  {path: 'dashboard', component: CampsComponent},
  {path: '', component: CampsComponent},
  //{path: 'admin', redirectTo: 'admin', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
