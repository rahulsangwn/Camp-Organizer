import { NgModule } from '@angular/core';
import { AuthComponent } from './auth/auth.component';
import { CampCreateComponent } from './camp-create/camp-create.component';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [
    { path: 'login', component: AuthComponent },
    { path: 'addcamp', component: CampCreateComponent, canActivate: [AuthGuard] }
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AdminRoutingModule {

}