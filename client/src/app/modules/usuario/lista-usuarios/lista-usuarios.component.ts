import { Component, OnInit } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { ListaPaginadaUsuario } from 'src/app/shared/models/listas-paginadas/listaPaginadaUsuario';
import { FiltroUsuario } from 'src/app/shared/models/filtros/filtroUsuario';
import { ToastrService } from 'ngx-toastr';
import { PageChangedEvent } from 'ngx-bootstrap';
import { Usuario } from 'src/app/shared/models/usuario';
import { UsuarioService } from 'src/app/shared/services/usuarioService.service';


@Component({
  selector: 'app-lista-usuarios',
  templateUrl: './lista-usuarios.component.html',
  styleUrls: ['./lista-usuarios.component.scss']
})

export class ListaUsuariosComponent implements OnInit {

  @BlockUI() blockUI: NgBlockUI;

  listaPaginadaUsuario: ListaPaginadaUsuario;
  filtroUsuario: FiltroUsuario;

  constructor(
    private usuarioService: UsuarioService,
    private toastr: ToastrService
  ) {
    this.listaPaginadaUsuario = new ListaPaginadaUsuario();
    this.filtroUsuario = new FiltroUsuario();
  }

  ngOnInit() {
    this.obterListaPaginada();
  }

  obterListaPaginada() {
    this.blockUI.start();
    this.usuarioService.obterListaPaginada(this.filtroUsuario)
      .subscribe(listaPaginadaUsuario => {
        this.listaPaginadaUsuario = listaPaginadaUsuario;
        this.blockUI.stop();
      });
  }

  alterarPagina(event: PageChangedEvent) {
    this.filtroUsuario.pagina = event.page;
    this.filtroUsuario.tamanhoPagina = event.itemsPerPage;
    this.obterListaPaginada();
  }

  confirmadaExclusao(usuario: Usuario) {
    this.blockUI.start();
    this.usuarioService.excluir(usuario.id)
      .subscribe(resultado => {
        this.toastr.success(`O Usuario "${usuario.nome}" foi excluído com sucesso.`);
        this.blockUI.stop();
        this.obterListaPaginada();
      }, error => {
        this.toastr.error(`${error.error}`);
        this.blockUI.stop();
      });
  }

}
