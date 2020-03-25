import { BaseService } from './base.service';
import { FiltroPerfil } from '../models/filtros/filtroPerfil';
import { HttpClient } from '@angular/common/http';
import { Perfil } from '../models/perfil';
import { Observable } from 'rxjs';
import { ListaPaginadaPerfil } from '../models/listas-paginadas/listaPaginadaPerfil';

export class PerfilService extends BaseService {

  filtroPerfil: FiltroPerfil;

  constructor(private http: HttpClient) {
    super();
  }

  obterListaPerfil(token: string) {
    this.filtroPerfil = new FiltroPerfil();
    this.filtroPerfil.nome = token;
    return this.http.post<Perfil[]>(this.UrlService + 'perfil/obterLista', this.filtroPerfil, super.ObterHeaderJson());
  }

  obterListaPaginada(filtroPerfil: FiltroPerfil): Observable<ListaPaginadaPerfil> {
    return this.http.post<ListaPaginadaPerfil>(this.UrlService + 'perfil/obterListaPaginada', filtroPerfil, super.ObterHeaderJson());
  }

  obterPeloId(id: string): Observable<Perfil> {
    return this.http.get<Perfil>(this.UrlService + 'perfil/obterPeloId?id=' + id, super.ObterHeaderJson());
  }

  inserir(perfil: Perfil): Observable<Perfil> {
    return this.http.post<Perfil>(this.UrlService + 'perfil/inserir', perfil, super.ObterHeaderJson());
  }

  alterar(perfil: Perfil): Observable<Perfil> {
    return this.http.put<Perfil>(this.UrlService + 'perfil/alterar', perfil, super.ObterHeaderJson());
  }

  excluir(id: string): Observable<any> {
    return this.http.delete<any>(this.UrlService + 'perfil/excluir?id=' + id, super.ObterHeaderJson());
  }
}
