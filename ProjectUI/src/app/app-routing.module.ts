import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CampsComponent } from './camps/camps.component';
import { ManageBookingComponent } from './camps/manage-booking/manage-booking.component';


const routes: Routes = [
  //{path: 'dashboard', component: CampsComponent},
  {path: '', component: CampsComponent},
  {path: 'manage', component: ManageBookingComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
