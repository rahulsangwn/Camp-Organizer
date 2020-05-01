import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CampCreateComponent } from './camp-create/camp-create.component';
import { CampListComponent } from './camp-list/camp-list.component';
import { AuthComponent } from './auth/auth.component';
import { LoadingSpinnerComponet } from 'src/shared/loading-spinner/loading-spinner.component';
import { NavbarComponent } from './navbar/navbar.component';
import { Routes, RouterModule } from '@angular/router';
import { FilterViewComponent } from './filter-view/filter-view.component';
import { CampItemComponent } from './camp-list/camp-item/camp-item.component';
import { CampsComponent } from './camps/camps.component';

@NgModule({
  declarations: [
    AppComponent,
    CampCreateComponent,
    CampListComponent,
    AuthComponent,
    LoadingSpinnerComponet,
    NavbarComponent,
    FilterViewComponent,
    CampItemComponent,
    CampsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
    // RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
