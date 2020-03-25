import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UsuarioService } from 'src/app/shared/services/usuarioService.service';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { PerfilService } from 'src/app/shared/services/PerfilService.service';
import { Perfil } from 'src/app/shared/models/perfil';

@Component({
  selector: 'app-cadastrar-usuario',
  templateUrl: './cadastrar-usuario.component.html',
  styleUrls: ['./cadastrar-usuario.component.scss']
})
export class CadastrarUsuarioComponent implements OnInit {

  @BlockUI() blockUI: NgBlockUI;

  formCadastrarUsuario: FormGroup;
  listaPerfil: Perfil[];

  constructor(
    private formBuilder: FormBuilder,
    private usuarioService: UsuarioService,
    private perfilService: PerfilService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    this.blockUI.start();
    this.criarFormularios();
    this.perfilService.obterListaPerfil('').subscribe(retorno => {
      this.listaPerfil = retorno;
      this.blockUI.stop();
    });
  }

  criarFormularios() {
    this.formCadastrarUsuario = this.formBuilder.group({
      nome: ['', Validators.required],
      email: ['', Validators.required],
      senha: ['', Validators.required],
      perfilId: ['', Validators.required],
    });
  }

  salvarUsuario(salvarFechar: number) {
    this.blockUI.start();

    const usuarioTemp = this.formCadastrarUsuario.value;

    this.usuarioService.inserir(usuarioTemp)
      .subscribe(usuario => {

        if (salvarFechar === 0) {
          this.router.navigate(['usuarios/editar-usuario', usuario.id]);
        }

        if (salvarFechar === 1) {
          this.router.navigate(['usuarios/cadastrar-usuario']);
          this.criarFormularios();
        }

        if (salvarFechar === 2) {
          this.router.navigate(['usuarios']);
        }

        this.blockUI.reset();
        this.toastr.success(`O usuario "${usuario.nome}" foi criado com sucesso.`);
      });
  }

}
