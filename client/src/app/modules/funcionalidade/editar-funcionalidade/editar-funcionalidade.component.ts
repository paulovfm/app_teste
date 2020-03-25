import { Component, OnInit } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { FuncionalidadeService } from 'src/app/shared/services/funcionalidadeService.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-editar-funcionalidade',
  templateUrl: './editar-funcionalidade.component.html',
  styleUrls: ['./editar-funcionalidade.component.scss']
})
export class EditarFuncionalidadeComponent implements OnInit {

  @BlockUI() blockUI: NgBlockUI;

  formEditarFuncionalidade: FormGroup;
  funcionalidadeId: string;

  constructor(
    private formBuilder: FormBuilder,
    private funcionalidadeService: FuncionalidadeService,
    private router: Router,
    private toastr: ToastrService,
    private activatedRoute: ActivatedRoute
  ) {
    this.funcionalidadeId = this.activatedRoute.snapshot.params.id;
  }

  ngOnInit() {
    this.criarFormularios();
    this.carregarDados();
  }

  carregarDados() {
    this.blockUI.start();
    this.funcionalidadeService.obterPeloId(this.funcionalidadeId).subscribe(funcionalidadeRetorno => {

      this.formEditarFuncionalidade.patchValue(funcionalidadeRetorno);

      this.blockUI.stop();
    });
  }

  criarFormularios() {
    this.formEditarFuncionalidade = this.formBuilder.group({
      id: ['', Validators.required],
      nome: ['', Validators.required]
    });
  }

  salvarFuncionalidade(salvarFechar: number) {
    this.blockUI.start();

    this.funcionalidadeService.alterar(this.formEditarFuncionalidade.value)
      .subscribe(funcionalidade => {

        if (salvarFechar === 0) {
          this.carregarDados();
        }

        if (salvarFechar === 1) {
          this.router.navigate(['funcionalidades/cadastrar-funcionalidade']);
          this.criarFormularios();
        }

        if (salvarFechar === 2) {
          this.router.navigate(['funcionalidades']);
        }

        this.blockUI.reset();
        this.toastr.success(`A funcionalidade "${funcionalidade.nome}" foi alterada com sucesso.`);
      });
  }


}
