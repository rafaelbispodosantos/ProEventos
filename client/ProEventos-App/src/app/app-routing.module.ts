import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContatosComponent } from './compoments/contatos/contatos.component';
import { DashboardComponent } from './compoments/dashboard/dashboard.component';
import { EventosComponent } from './compoments/eventos/eventos.component';
import { PalestrantesComponent } from './compoments/palestrantes/palestrantes.component';
import { PerfilComponent } from './compoments/perfil/perfil.component';

const routes: Routes = [
  {path: 'eventos',  component: EventosComponent},
  {path: 'dashboard',  component: DashboardComponent},
  {path: 'palestrantes',  component: PalestrantesComponent},
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
