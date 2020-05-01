import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { CampCreateComponent } from './camp-create/camp-create.component';
import { CampsComponent } from './camps/camps.component';


const routes: Routes = [
  {path: 'login', component: AuthComponent},
  {path: '', component: CampsComponent},
  {path: 'addcamp', component: CampCreateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
