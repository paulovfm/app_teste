import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SharedModule } from 'src/app/shared/shared.module';
import { ListaFuncionalidadesComponent } from './lista-funcionalidades/lista-funcionalidades.component';
import { EditarFuncionalidadeComponent } from './editar-funcionalidade/editar-funcionalidade.component';
import { CadastrarFuncionalidadeComponent } from './cadastrar-funcionalidade/cadastrar-funcionalidade.component';

const routes: Routes = [
  {path : '', component: ListaFuncionalidadesComponent },
  {path : 'cadastrar-funcionalidade', component: CadastrarFuncionalidadeComponent },
  {path : 'editar-funcionalidade/:id', component: EditarFuncionalidadeComponent },
];

@NgModule({
  declarations: [ListaFuncionalidadesComponent, EditarFuncionalidadeComponent, CadastrarFuncionalidadeComponent],
  imports: [
    SharedModule,
    RouterModule.forChild(routes)
  ]
})
export class FuncionalidadeModule { }
