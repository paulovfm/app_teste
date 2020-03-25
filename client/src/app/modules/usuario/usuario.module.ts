import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { ListaUsuariosComponent } from './lista-usuarios/lista-usuarios.component';
import { CadastrarUsuarioComponent } from './cadastrar-usuario/cadastrar-usuario.component';
import { EditarUsuarioComponent } from './editar-usuario/editar-usuario.component';

const routes: Routes = [
  {path : '', component: ListaUsuariosComponent },
  {path : 'cadastrar-usuario', component: CadastrarUsuarioComponent },
  {path : 'editar-usuario/:id', component: EditarUsuarioComponent },
];

@NgModule({
  declarations: [ListaUsuariosComponent, CadastrarUsuarioComponent, EditarUsuarioComponent],
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ]
})
export class UsuarioModule { }
