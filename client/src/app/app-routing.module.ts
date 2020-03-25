import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: '', loadChildren: () => import('./modules/usuario/usuario.module').then(m => m.UsuarioModule) },
  { path: 'usuarios', loadChildren: () => import('./modules/usuario/usuario.module').then(m => m.UsuarioModule) },
  { path: 'perfis', loadChildren: () => import('./modules/perfil/perfil.module').then(m => m.PerfilModule) },
  // tslint:disable-next-line: max-line-length
  { path: 'funcionalidades', loadChildren: () => import('./modules/funcionalidade/funcionalidade.module').then(m => m.FuncionalidadeModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
