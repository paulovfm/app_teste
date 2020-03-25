using System;

namespace App.Application.ViewModels
{
    public class PerfilFuncionalidadeViewModel
    {
        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public bool Excluido { get; set; }

        public Guid PerfilId { get; set; }

        public Guid FuncionalidadeId { get; set; }

        public virtual PerfilViewModel Perfil { get; set; }

        public virtual FuncionalidadeViewModel Funcionalidade { get; set; }
    }
}