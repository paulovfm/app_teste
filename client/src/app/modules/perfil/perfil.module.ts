import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { ListaPerfisComponent } from './lista-perfis/lista-perfis.component';
import { CadastrarPerfilComponent } from './cadastrar-perfil/cadastrar-perfil.component';
import { EditarPerfilComponent } from './editar-perfil/editar-perfil.component';

const routes: Routes = [
  {path : '', component: ListaPerfisComponent },
  {path : 'cadastrar-perfil', component: CadastrarPerfilComponent },
  {path : 'editar-perfil/:id', component: EditarPerfilComponent },
];

@NgModule({
  declarations: [ListaPerfisComponent, CadastrarPerfilComponent, EditarPerfilComponent],
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ]
})
export class PerfilModule { }
