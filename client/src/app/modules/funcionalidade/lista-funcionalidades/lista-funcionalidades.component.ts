import { Component, OnInit } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { ListaPaginadaFuncionalidade } from 'src/app/shared/models/listas-paginadas/listaPaginadaFuncionalidade';
import { FiltroFuncionalidade } from 'src/app/shared/models/filtros/filtroFuncionalidade';
import { FuncionalidadeService } from 'src/app/shared/services/funcionalidadeService.service';
import { ToastrService } from 'ngx-toastr';
import { PageChangedEvent } from 'ngx-bootstrap';
import { Funcionalidade } from 'src/app/shared/models/funcionalidade';

@Component({
  selector: 'app-lista-funcionalidades',
  templateUrl: './lista-funcionalidades.component.html',
  styleUrls: ['./lista-funcionalidades.component.scss']
})
export class ListaFuncionalidadesComponent implements OnInit {

  @BlockUI() blockUI: NgBlockUI;

  listaPaginadaFuncionalidade: ListaPaginadaFuncionalidade;
  filtroFuncionalidade: FiltroFuncionalidade;

  constructor(
    private funcionalidadeService: FuncionalidadeService,
    private toastr: ToastrService
  ) {
    this.listaPaginadaFuncionalidade = new ListaPaginadaFuncionalidade();
    this.filtroFuncionalidade = new FiltroFuncionalidade();
  }

  ngOnInit() {
    this.obterListaPaginada();
  }

  obterListaPaginada() {
    this.blockUI.start();
    this.funcionalidadeService.obterListaPaginada(this.filtroFuncionalidade)
      .subscribe(listaPaginadaFuncionalidade => {
        this.listaPaginadaFuncionalidade = listaPaginadaFuncionalidade;
        this.blockUI.stop();
      });
  }

  alterarPagina(event: PageChangedEvent) {
    this.filtroFuncionalidade.pagina = event.page;
    this.filtroFuncionalidade.tamanhoPagina = event.itemsPerPage;
    this.obterListaPaginada();
  }

  confirmadaExclusao(funcionalidade: Funcionalidade) {
    this.blockUI.start();
    this.funcionalidadeService.excluir(funcionalidade.id)
      .subscribe(resultado => {
        this.toastr.success(`O Funcionalidade "${funcionalidade.nome}" foi excluído com sucesso.`);
        this.blockUI.stop();
        this.obterListaPaginada();
      }, error => {
        this.toastr.error(`${error.error.Message}`);
        this.blockUI.stop();
      });
  }


}
