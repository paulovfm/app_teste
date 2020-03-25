import { Component, OnInit } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PerfilService } from 'src/app/shared/services/PerfilService.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FuncionalidadeService } from 'src/app/shared/services/funcionalidadeService.service';
import { Funcionalidade } from 'src/app/shared/models/funcionalidade';
import { PerfilFuncionalidade } from 'src/app/shared/models/perfilFuncionalidade';
import { Perfil } from 'src/app/shared/models/perfil';

@Component({
  selector: 'app-editar-perfil',
  templateUrl: './editar-perfil.component.html',
  styleUrls: ['./editar-perfil.component.scss']
})
export class EditarPerfilComponent implements OnInit {

  @BlockUI() blockUI: NgBlockUI;

  formEditarPerfil: FormGroup;
  perfilId: string;
  listaFuncionalidade: Funcionalidade[];

  constructor(
    private formBuilder: FormBuilder,
    private perfilService: PerfilService,
    private router: Router,
    private toastr: ToastrService,
    private activatedRoute: ActivatedRoute,
    private funcionalidadeService: FuncionalidadeService,
  ) {
    this.perfilId = this.activatedRoute.snapshot.params.id;
  }

  ngOnInit() {
    this.blockUI.start();
    this.criarFormularios();
    this.funcionalidadeService.obterListaFuncionalidade('').subscribe(retorno => {
      this.listaFuncionalidade = retorno;
      this.blockUI.stop();
      this.carregarDados();
    });

  }

  carregarDados() {
    this.blockUI.start();
    this.perfilService.obterPeloId(this.perfilId).subscribe(perfilRetorno => {

      this.formEditarPerfil.patchValue(perfilRetorno);

      const funcionalidadeSelecionada = new Array<string>();
      perfilRetorno.perfilFuncionalidade.forEach(perfilFuncionalidade => {
        funcionalidadeSelecionada.push(perfilFuncionalidade.funcionalidadeId);
      });

      this.formEditarPerfil.patchValue({
        funcionalidadeSelecionada
      });

      this.blockUI.stop();
    });
  }

  criarFormularios() {
    this.formEditarPerfil = this.formBuilder.group({
      id: ['', Validators.required],
      nome: ['', Validators.required],
      funcionalidadeSelecionada: ['']
    });
  }

  salvarPerfil(salvarFechar: number) {
    this.blockUI.start();

    const perfil = new Perfil();
    perfil.id = this.formEditarPerfil.value.id;
    perfil.nome = this.formEditarPerfil.value.nome;
    perfil.perfilFuncionalidade = new Array<PerfilFuncionalidade>();

    if (this.formEditarPerfil.value.funcionalidadeSelecionada.length > 0) {
      this.formEditarPerfil.value.funcionalidadeSelecionada.forEach(perfilFuncionalidade => {
        const perfilFuncionalidadeTemp = new PerfilFuncionalidade();
        perfilFuncionalidadeTemp.funcionalidadeId = perfilFuncionalidade;
        perfilFuncionalidadeTemp.perfilId = this.perfilId;

        perfil.perfilFuncionalidade.push(perfilFuncionalidadeTemp);
      });
    }

    this.perfilService.alterar(perfil)
      .subscribe(retorno => {

        if (salvarFechar === 0) {
          this.carregarDados();
        }

        if (salvarFechar === 1) {
          this.router.navigate(['perfis/cadastrar-perfil']);
          this.criarFormularios();
        }

        if (salvarFechar === 2) {
          this.router.navigate(['perfis']);
        }

        this.blockUI.reset();
        this.toastr.success(`O perfil "${retorno.nome}" foi alterado com sucesso.`);
      });
  }

}
