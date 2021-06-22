import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventosComponent } from './compoments/eventos/eventos.component';
import { PalestrantesComponent } from './compoments/palestrantes/palestrantes.component';
import { NavComponent } from './compoments/nav/nav.component';
import { DateTimeFormtPipe } from './helpers/DateTimeFormt.pipe';
import { ContatosComponent } from './compoments/contatos/contatos.component';
import { DashboardComponent } from './compoments/dashboard/dashboard.component';
import { PerfilComponent } from './compoments/user/perfil/perfil.component';

import {TooltipModule} from 'ngx-bootstrap/tooltip'
import {BsDropdownModule} from 'ngx-bootstrap/dropdown'
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { ModalModule } from 'ngx-bootstrap/modal';
import {ToastrModule} from 'ngx-toastr'
import { CommonModule } from '@angular/common';
import { TituloComponent } from './shared/titulo/titulo.component';
import { EventosDetalheComponent } from './compoments/eventos/eventos-detalhe/eventos-detalhe.component';
import { EventosListaComponent } from './compoments/eventos/eventos-lista/eventos-lista.component';
import { UserComponent } from './compoments/user/user.component';
import { LoginComponent } from './compoments/user/login/login.component';
import { RegistrationComponent } from './compoments/user/registration/registration.component';


@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
    PalestrantesComponent,
    NavComponent,
    DateTimeFormtPipe,
    ContatosComponent,
    DashboardComponent,
    PerfilComponent,
    TituloComponent,
    EventosDetalheComponent,
    EventosListaComponent,
    UserComponent,
    LoginComponent,
    RegistrationComponent,





  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    CommonModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 2000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressAnimation:'increasing'
    }),

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
