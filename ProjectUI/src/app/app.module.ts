import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CampCreateComponent } from './camp-create/camp-create.component';
import { AuthComponent } from './auth/auth.component';
import { LoadingSpinnerComponet } from 'src/shared/loading-spinner/loading-spinner.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FilterViewComponent } from './camps/filter-view/filter-view.component';
import { CampItemComponent } from './camps/camp-list/camp-item/camp-item.component';
import { CampsComponent } from './camps/camps.component';
import { CampListComponent } from './camps/camp-list/camp-list.component';

@NgModule({
  declarations: [
    AppComponent,
    CampCreateComponent,
    AuthComponent,
    LoadingSpinnerComponet,
    NavbarComponent,
    FilterViewComponent,
    CampItemComponent,
    CampsComponent,
    CampListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
