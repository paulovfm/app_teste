import { Component, OnInit } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { FiltroPerfil } from 'src/app/shared/models/filtros/filtroPerfil';
import { ToastrService } from 'ngx-toastr';
import { PageChangedEvent } from 'ngx-bootstrap';
import { Perfil } from 'src/app/shared/models/perfil';
import { ListaPaginadaPerfil } from 'src/app/shared/models/listas-paginadas/listaPaginadaPerfil';
import { PerfilService } from 'src/app/shared/services/PerfilService.service';

@Component({
  selector: 'app-lista-perfis',
  templateUrl: './lista-perfis.component.html',
  styleUrls: ['./lista-perfis.component.scss']
})
export class ListaPerfisComponent implements OnInit {

  @BlockUI() blockUI: NgBlockUI;

  listaPaginadaPerfil: ListaPaginadaPerfil;
  filtroPerfil: FiltroPerfil;

  constructor(
    private perfilService: PerfilService,
    private toastr: ToastrService
  ) {
    this.listaPaginadaPerfil = new ListaPaginadaPerfil();
    this.filtroPerfil = new FiltroPerfil();
  }

  ngOnInit() {
    this.obterListaPaginada();
  }

  obterListaPaginada() {
    this.blockUI.start();
    this.perfilService.obterListaPaginada(this.filtroPerfil)
      .subscribe(listaPaginadaPerfil => {
        this.listaPaginadaPerfil = listaPaginadaPerfil;
        this.blockUI.stop();
      });
  }

  alterarPagina(event: PageChangedEvent) {
    this.filtroPerfil.pagina = event.page;
    this.filtroPerfil.tamanhoPagina = event.itemsPerPage;
    this.obterListaPaginada();
  }

  confirmadaExclusao(perfil: Perfil) {
    this.blockUI.start();
    this.perfilService.excluir(perfil.id)
      .subscribe(resultado => {
        this.toastr.success(`O Perfil "${perfil.nome}" foi excluído com sucesso.`);
        this.blockUI.stop();
        this.obterListaPaginada();
      }, error => {
        this.toastr.error(`${error.error.Message}`);
        this.blockUI.stop();
      });
  }

}
