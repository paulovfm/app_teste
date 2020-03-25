import { PerfilFuncionalidade } from './perfilFuncionalidade';

export class Perfil {
  id: string;
  nome: string;
  dataCadastro: Date;
  dataAtualizacao: Date;
  excluido: boolean;
  perfilFuncionalidade: PerfilFuncionalidade[];
}
