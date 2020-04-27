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

@NgModule({
  declarations: [
    AppComponent,
    CampCreateComponent,
    CampListComponent,
    AuthComponent,
    LoadingSpinnerComponet
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
