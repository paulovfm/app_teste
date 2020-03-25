using System;
using App.Domain.Entities;

namespace App.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public bool Excluido { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public Guid PerfilId { get; set; }

        public virtual PerfilViewModel Perfil { get; set; }

        public static UsuarioViewModel FromDomainModel(Usuario usuario)
        {
            var usuarioViewModel = new UsuarioViewModel
            {
                Id = usuario.Id,
                DataCadastro = usuario.DataCadastro,
                DataAtualizacao = usuario.DataAtualizacao,
                Excluido = usuario.Excluido,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                PerfilId = usuario.PerfilId,
                Perfil = new PerfilViewModel
                {
                    Nome = usuario.Perfil.Nome,
                }
            };

            return usuarioViewModel;
        }

        public static Usuario ToDomainModel(UsuarioViewModel usuarioViewModel)
        {
            var usuario = new Usuario
            {
                Id = usuarioViewModel.Id,
                DataCadastro = usuarioViewModel.DataCadastro,
                DataAtualizacao = usuarioViewModel.DataAtualizacao,
                Excluido = usuarioViewModel.Excluido,
                Nome = usuarioViewModel.Nome,
                Email = usuarioViewModel.Email,
                Senha = usuarioViewModel.Senha,
                PerfilId = usuarioViewModel.PerfilId,
            };

            return usuario;
        }
    }
}