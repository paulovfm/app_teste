using System;
using System.Collections.Generic;
using System.Linq;
using App.Domain.Entities;

namespace App.Application.ViewModels
{
    public class PerfilViewModel
    {
        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public bool Excluido { get; set; }

        public string Nome { get; set; }

        public virtual List<UsuarioViewModel> Usuario { get; set; }

        public virtual List<PerfilFuncionalidadeViewModel> PerfilFuncionalidade { get; set; }

        public static PerfilViewModel FromDomainModel(Perfil perfil)
        {
            var perfilViewModel = new PerfilViewModel
            {
                Id = perfil.Id,
                DataCadastro = perfil.DataCadastro,
                DataAtualizacao = perfil.DataAtualizacao,
                Excluido = perfil.Excluido,
                Nome = perfil.Nome,
                PerfilFuncionalidade = new List<PerfilFuncionalidadeViewModel>()
            };

            if (perfil.PerfilFuncionalidade != null)
            {
                foreach (var perfilFuncionalidade in perfil.PerfilFuncionalidade.OrderBy(x => x.Funcionalidade.Nome))
                {
                    var perfilFuncionalidadeViewModel = new PerfilFuncionalidadeViewModel
                    {
                        Id = perfilFuncionalidade.Id,
                        Excluido = perfilFuncionalidade.Excluido,
                        DataCadastro = perfilFuncionalidade.DataCadastro,
                        DataAtualizacao = perfilFuncionalidade.DataAtualizacao,
                        PerfilId = perfilFuncionalidade.PerfilId,
                        FuncionalidadeId = perfilFuncionalidade.FuncionalidadeId,
                    };

                    perfilViewModel.PerfilFuncionalidade.Add(perfilFuncionalidadeViewModel);
                }
            }

            return perfilViewModel;
        }

        public static Perfil ToDomainModel(PerfilViewModel perfilViewModel)
        {
            var perfil = new Perfil
            {
                Id = perfilViewModel.Id,
                Excluido = perfilViewModel.Excluido,
                DataCadastro = perfilViewModel.DataCadastro,
                DataAtualizacao = perfilViewModel.DataAtualizacao,
                Nome = perfilViewModel.Nome,
                PerfilFuncionalidade = new List<PerfilFuncionalidade>()
            };

            if (perfilViewModel.PerfilFuncionalidade != null)
            {
                foreach (var perfilFuncionalidadeViewModel in perfilViewModel.PerfilFuncionalidade)
                {
                    var perfilFuncionalidade = new PerfilFuncionalidade
                    {
                        Id = perfilFuncionalidadeViewModel.Id,
                        Excluido = perfilFuncionalidadeViewModel.Excluido,
                        DataCadastro = perfilFuncionalidadeViewModel.DataCadastro,
                        DataAtualizacao = perfilFuncionalidadeViewModel.DataAtualizacao,
                        PerfilId = perfilFuncionalidadeViewModel.PerfilId,
                        FuncionalidadeId = perfilFuncionalidadeViewModel.FuncionalidadeId,
                    };

                    perfil.PerfilFuncionalidade.Add(perfilFuncionalidade);
                }
            }

            return perfil;
        }
    }
}