import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContatosComponent } from './compoments/contatos/contatos.component';
import { DashboardComponent } from './compoments/dashboard/dashboard.component';
import { EventosDetalheComponent } from './compoments/eventos/eventos-detalhe/eventos-detalhe.component';
import { EventosListaComponent } from './compoments/eventos/eventos-lista/eventos-lista.component';
import { EventosComponent } from './compoments/eventos/eventos.component';
import { PalestrantesComponent } from './compoments/palestrantes/palestrantes.component';
import { PerfilComponent } from './compoments/user/perfil/perfil.component';
import { LoginComponent } from './compoments/user/login/login.component';
import { RegistrationComponent } from './compoments/user/registration/registration.component';
import { UserComponent } from './compoments/user/user.component';

const routes: Routes = [
  {path: 'user', component: UserComponent,
  children: [
    {path: 'login', component: LoginComponent },
    {path: 'registration', component: RegistrationComponent },
  ]
},
{
  path: 'user/perfil',  component: PerfilComponent
},
  {path: 'eventos', redirectTo:'eventos/lista'},
    {path: 'eventos',  component: EventosComponent,
    children:[
      {path: "detalhe/:id",component: EventosDetalheComponent},
      {path: "detalhe",component: EventosDetalheComponent},
      {path: "lista",component: EventosListaComponent},
    ]
  },
  {path: 'dashboard',  component: DashboardComponent},
  {path: 'palestrantes',  component: PalestrantesComponent},
  {path: 'perfil',  component: PerfilComponent},
  {path: 'perfil',  component: PerfilComponent},
  {path: 'perfil',  component: PerfilComponent},
  {path: 'perfil',  component: PerfilComponent},
  {path: 'perfil',  component: PerfilComponent},
  {path: 'perfil',  component: PerfilComponent},
  {path: 'contatos',  component: ContatosComponent},
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  {path: '**', redirectTo: 'dashboard', pathMatch: 'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
