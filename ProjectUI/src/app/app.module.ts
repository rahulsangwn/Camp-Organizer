import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CampCreateComponent } from './admin-module/camp-create/camp-create.component';
import { AuthComponent } from './admin-module/auth/auth.component';
import { LoadingSpinnerComponet } from 'src/shared/loading-spinner/loading-spinner.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FilterViewComponent } from './camps/filter-view/filter-view.component';
import { CampItemComponent } from './camps/camp-list/camp-item/camp-item.component';
import { CampsComponent } from './camps/camps.component';
import { CampListComponent } from './camps/camp-list/camp-list.component';
import { CampBookComponent } from './camps/camp-book/camp-book.component';
import { AdminModuleModule } from './admin-module/admin-module.module';
import { ManageBookingComponent } from './camps/manage-booking/manage-booking.component';

@NgModule({
  declarations: [
    AppComponent,
    LoadingSpinnerComponet,
    NavbarComponent,
    FilterViewComponent,
    CampItemComponent,
    CampsComponent,
    CampListComponent,
    CampBookComponent,
    ManageBookingComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    AdminModuleModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
