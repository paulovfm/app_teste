using System;
using System.Collections.Generic;
using App.Domain.Entities;

namespace App.Application.ViewModels
{
    public class FuncionalidadeViewModel
    {
        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public bool Excluido { get; set; }

        public string Nome { get; set; }

        public virtual List<PerfilFuncionalidadeViewModel> PerfilFuncionalidade { get; set; }

        public static FuncionalidadeViewModel FromDomainModel(Funcionalidade funcionalidade)
        {
            var funcionalidadeViewModel = new FuncionalidadeViewModel
            {
                Id = funcionalidade.Id,
                DataCadastro = funcionalidade.DataCadastro,
                DataAtualizacao = funcionalidade.DataAtualizacao,
                Excluido = funcionalidade.Excluido,
                Nome = funcionalidade.Nome,
            };

            return funcionalidadeViewModel;
        }

        public static Funcionalidade ToDomainModel(FuncionalidadeViewModel funcionalidadeViewModel)
        {
            var funcionalidade = new Funcionalidade
            {
                Id = funcionalidadeViewModel.Id,
                Excluido = funcionalidadeViewModel.Excluido,
                DataCadastro = funcionalidadeViewModel.DataCadastro,
                DataAtualizacao = funcionalidadeViewModel.DataAtualizacao,
                Nome = funcionalidadeViewModel.Nome,
            };

            return funcionalidade;
        }
    }
}