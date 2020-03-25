import { BaseService } from './base.service';
import { FiltroFuncionalidade } from '../models/filtros/filtroFuncionalidade';
import { HttpClient } from '@angular/common/http';
import { Funcionalidade } from '../models/funcionalidade';
import { Observable } from 'rxjs';
import { ListaPaginadaFuncionalidade } from '../models/listas-paginadas/listaPaginadaFuncionalidade';

export class FuncionalidadeService extends BaseService {

  filtroFuncionalidade: FiltroFuncionalidade;

  constructor(private http: HttpClient) {
    super();
  }

  obterListaFuncionalidade(token: string) {
    this.filtroFuncionalidade = new FiltroFuncionalidade();
    this.filtroFuncionalidade.nome = token;
    return this.http.post<Funcionalidade[]>(this.UrlService + 'funcionalidade/obterLista', this.filtroFuncionalidade, super.ObterHeaderJson());
  }

  obterListaPaginada(filtroFuncionalidade: FiltroFuncionalidade): Observable<ListaPaginadaFuncionalidade> {
    return this.http.post<ListaPaginadaFuncionalidade>(this.UrlService + 'funcionalidade/obterListaPaginada', filtroFuncionalidade, super.ObterHeaderJson());
  }

  obterPeloId(id: string): Observable<Funcionalidade> {
    return this.http.get<Funcionalidade>(this.UrlService + 'funcionalidade/obterPeloId?id=' + id, super.ObterHeaderJson());
  }

  inserir(funcionalidade: Funcionalidade): Observable<Funcionalidade> {
    return this.http.post<Funcionalidade>(this.UrlService + 'funcionalidade/inserir', funcionalidade, super.ObterHeaderJson());
  }

  alterar(funcionalidade: Funcionalidade): Observable<Funcionalidade> {
    return this.http.put<Funcionalidade>(this.UrlService + 'funcionalidade/alterar', funcionalidade, super.ObterHeaderJson());
  }

  excluir(id: string): Observable<any> {
    return this.http.delete<any>(this.UrlService + 'funcionalidade/excluir?id=' + id, super.ObterHeaderJson());
  }
}
