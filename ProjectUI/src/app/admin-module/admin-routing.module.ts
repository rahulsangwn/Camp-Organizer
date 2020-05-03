import { NgModule } from '@angular/core';
import { AuthComponent } from './auth/auth.component';
import { CampCreateComponent } from './camp-create/camp-create.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
    { path: 'login', component: AuthComponent },
    { path: 'addcamp', component: CampCreateComponent }
    // {
    //     path: 'admin', 
    //     component: AuthComponent,
    //     children: [
    //         { path: '', component: AuthComponent },
    //         { path: 'new', component: CampCreateComponent }
    //     ]
    // }
];
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AdminRoutingModule {

}