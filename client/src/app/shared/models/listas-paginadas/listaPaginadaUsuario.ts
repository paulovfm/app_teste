import { Usuario } from '../usuario';

export class ListaPaginadaUsuario {
  tamanhoPagina: number;
  pagina: number;
  itensTotal: number;
  itens: Array<Usuario>;
}
