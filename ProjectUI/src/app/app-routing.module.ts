import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { logging } from 'protractor';
import { AuthComponent } from './auth/auth.component';
import { CampCreateComponent } from './camp-create/camp-create.component';
import { CampListComponent } from './camp-list/camp-list.component';


const routes: Routes = [
  {path: 'login', component: AuthComponent},
  {path: '', component: CampListComponent},
  {path: 'create', component: CampCreateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
