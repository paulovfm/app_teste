import { Component, OnInit } from '@angular/core';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UsuarioService } from 'src/app/shared/services/usuarioService.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Perfil } from 'src/app/shared/models/perfil';
import { PerfilService } from 'src/app/shared/services/PerfilService.service';

@Component({
  selector: 'app-editar-usuario',
  templateUrl: './editar-usuario.component.html',
  styleUrls: ['./editar-usuario.component.scss']
})
export class EditarUsuarioComponent implements OnInit {

  @BlockUI() blockUI: NgBlockUI;

  formEditarUsuario: FormGroup;
  usuarioId: string;
  listaPerfil: Perfil[];

  constructor(
    private formBuilder: FormBuilder,
    private usuarioService: UsuarioService,
    private perfilService: PerfilService,
    private router: Router,
    private toastr: ToastrService,
    private activatedRoute: ActivatedRoute
  ) {
    this.usuarioId = this.activatedRoute.snapshot.params.id;
  }

  ngOnInit() {
    this.blockUI.start();
    this.criarFormularios();
    this.perfilService.obterListaPerfil('').subscribe(retorno => {
      this.listaPerfil = retorno;
      this.blockUI.stop();
      this.carregarDados();
    });
  }

  carregarDados() {
    this.blockUI.start();
    this.usuarioService.obterPeloId(this.usuarioId).subscribe(usuarioRetorno => {
      this.formEditarUsuario.patchValue(usuarioRetorno);
      this.blockUI.stop();
    });
  }

  criarFormularios() {
    this.formEditarUsuario = this.formBuilder.group({
      id: ['', Validators.required],
      nome: ['', Validators.required],
      email: ['', Validators.required],
      senha: ['', Validators.required],
      perfilId: ['', Validators.required],
    });
  }

  salvarUsuario(salvarFechar: number) {
    this.blockUI.start();

    this.usuarioService.alterar(this.formEditarUsuario.value)
      .subscribe(usuario => {

        if (salvarFechar === 0) {
          this.carregarDados();
        }

        if (salvarFechar === 1) {
          this.router.navigate(['usuarios/cadastrar-usuario']);
          this.criarFormularios();
        }

        if (salvarFechar === 2) {
          this.router.navigate(['usuarios']);
        }

        this.blockUI.reset();
        this.toastr.success(`O usuario "${usuario.nome}" foi alterado com sucesso.`);
      });
  }

}
