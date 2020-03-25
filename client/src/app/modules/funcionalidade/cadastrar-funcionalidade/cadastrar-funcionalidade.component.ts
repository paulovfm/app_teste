import { Component, OnInit } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FuncionalidadeService } from 'src/app/shared/services/funcionalidadeService.service';

@Component({
  selector: 'app-cadastrar-funcionalidade',
  templateUrl: './cadastrar-funcionalidade.component.html',
  styleUrls: ['./cadastrar-funcionalidade.component.scss']
})
export class CadastrarFuncionalidadeComponent implements OnInit {

  @BlockUI() blockUI: NgBlockUI;

  formCadastrarFuncionalidade: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private funcionalidadeService: FuncionalidadeService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.criarFormularios();
  }

  criarFormularios() {
    this.formCadastrarFuncionalidade = this.formBuilder.group({
      nome: ['', Validators.required]
    });
  }

  salvarFuncionalidade(salvarFechar: number) {
    this.blockUI.start();

    const funcionalidadeTemp = this.formCadastrarFuncionalidade.value;

    this.funcionalidadeService.inserir(funcionalidadeTemp)
      .subscribe(funcionalidade => {

        if (salvarFechar === 0) {
          this.router.navigate(['funcionalidades/editar-funcionalidade', funcionalidade.id]);
        }

        if (salvarFechar === 1) {
          this.router.navigate(['funcionalidades/cadastrar-funcionalidade']);
          this.criarFormularios();
        }

        if (salvarFechar === 2) {
          this.router.navigate(['funcionalidades']);
        }

        this.blockUI.reset();
        this.toastr.success(`A funcionalidade "${funcionalidade.nome}" foi criada com sucesso.`);
      });
  }

}
