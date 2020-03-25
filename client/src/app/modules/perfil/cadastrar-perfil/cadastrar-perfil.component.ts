import { Component, OnInit } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PerfilService } from 'src/app/shared/services/PerfilService.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Funcionalidade } from 'src/app/shared/models/funcionalidade';
import { FuncionalidadeService } from 'src/app/shared/services/funcionalidadeService.service';
import { Perfil } from 'src/app/shared/models/perfil';
import { PerfilFuncionalidade } from 'src/app/shared/models/perfilFuncionalidade';

@Component({
  selector: 'app-cadastrar-perfil',
  templateUrl: './cadastrar-perfil.component.html',
  styleUrls: ['./cadastrar-perfil.component.scss']
})
export class CadastrarPerfilComponent implements OnInit {

  @BlockUI() blockUI: NgBlockUI;

  formCadastrarPerfil: FormGroup;
  listaFuncionalidade: Funcionalidade[];

  constructor(
    private formBuilder: FormBuilder,
    private perfilService: PerfilService,
    private funcionalidadeService: FuncionalidadeService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.blockUI.start();
    this.criarFormularios();
    this.funcionalidadeService.obterListaFuncionalidade('').subscribe(retorno => {
      this.listaFuncionalidade = retorno;
      this.blockUI.stop();
    });
  }

  criarFormularios() {
    this.formCadastrarPerfil = this.formBuilder.group({
      nome: ['', Validators.required],
      funcionalidadeSelecionada: ['']
    });
  }

  salvarPerfil(salvarFechar: number) {
    this.blockUI.start();

    const perfil = new Perfil();
    perfil.nome = this.formCadastrarPerfil.value.nome;
    perfil.perfilFuncionalidade = new Array<PerfilFuncionalidade>();

    if (this.formCadastrarPerfil.value.funcionalidadeSelecionada.length > 0) {
      this.formCadastrarPerfil.value.funcionalidadeSelecionada.forEach(perfilFuncionalidade => {
        const perfilFuncionalidadeTemp = new PerfilFuncionalidade();
        perfilFuncionalidadeTemp.funcionalidadeId = perfilFuncionalidade;

        perfil.perfilFuncionalidade.push(perfilFuncionalidadeTemp);
      });
    }

    this.perfilService.inserir(perfil)
      .subscribe(retorno => {

        if (salvarFechar === 0) {
          this.router.navigate(['perfis/editar-perfil', retorno.id]);
        }

        if (salvarFechar === 1) {
          this.router.navigate(['perfis/cadastrar-perfil']);
          this.criarFormularios();
        }

        if (salvarFechar === 2) {
          this.router.navigate(['perfis']);
        }

        this.blockUI.reset();
        this.toastr.success(`O perfil "${retorno.nome}" foi criado com sucesso.`);
      });
  }

}
