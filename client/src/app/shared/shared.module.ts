import { ModuleWithProviders } from '@angular/compiler/src/core';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { TableComponent } from './components/table/table.component';
import { PaginationModule, ModalModule } from 'ngx-bootstrap';
import { ToastrModule } from 'ngx-toastr';
import { BlockUIModule } from 'ng-block-ui';
import { BlockUiTemplateComponent } from './components/block-ui-template/block-ui-template.component';
import { ModalExcluirItemComponent } from './components/modal-excluir-item/modal-excluir-item.component';
import { UsuarioService } from './services/usuarioService.service';
import { InputComponent } from './components/input/input.component';
import { PerfilService } from './services/PerfilService.service';
import { FuncionalidadeService } from './services/funcionalidadeService.service';
import { NgSelectModule } from '@ng-select/ng-select';


@NgModule({
  declarations: [
    BlockUiTemplateComponent,
    InputComponent,
    TableComponent,
    ModalExcluirItemComponent,
  ],
  entryComponents: [
    BlockUiTemplateComponent
  ],
  imports: [
    RouterModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PaginationModule.forRoot(),
    ToastrModule.forRoot(),
    BlockUIModule.forRoot({
      template: BlockUiTemplateComponent
    }),
    ModalModule.forRoot(),
    NgSelectModule
  ],
  exports: [
    RouterModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TableComponent,
    PaginationModule,
    BlockUIModule,
    ModalExcluirItemComponent,
    ModalModule,
    InputComponent,
    NgSelectModule
  ]
})


export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [
        UsuarioService,
        PerfilService,
        FuncionalidadeService
      ]
    };
}
}
