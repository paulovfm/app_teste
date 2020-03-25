import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { Usuario } from 'src/app/shared/models/usuario';
import { FiltroUsuario } from 'src/app/shared/models/filtros/filtroUsuario';
import { Observable } from 'rxjs';
import { ListaPaginadaUsuario } from 'src/app/shared/models/listas-paginadas/listaPaginadaUsuario';

export class UsuarioService extends BaseService {

  filtroUsuario: FiltroUsuario;

  constructor(private http: HttpClient) {
    super();
  }

  obterListaUsuario(token: string) {
    this.filtroUsuario = new FiltroUsuario();
    this.filtroUsuario.nome = token;
    return this.http.post<Usuario[]>(this.UrlService + 'usuario/obterLista', this.filtroUsuario, super.ObterHeaderJson());
  }

  obterListaPaginada(filtroUsuario: FiltroUsuario): Observable<ListaPaginadaUsuario> {
    return this.http.post<ListaPaginadaUsuario>(this.UrlService + 'usuario/obterListaPaginada', filtroUsuario, super.ObterHeaderJson());
  }

  obterPeloId(id: string): Observable<Usuario> {
    return this.http.get<Usuario>(this.UrlService + 'usuario/obterPeloId?id=' + id, super.ObterHeaderJson());
  }

  inserir(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.UrlService + 'usuario/inserir', usuario, super.ObterHeaderJson());
  }

  alterar(usuario: Usuario): Observable<Usuario> {
    return this.http.put<Usuario>(this.UrlService + 'usuario/alterar', usuario, super.ObterHeaderJson());
  }

  excluir(id: string): Observable<any> {
    return this.http.delete<any>(this.UrlService + 'usuario/excluir?id=' + id, super.ObterHeaderJson());
  }
}
