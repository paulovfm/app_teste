using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.Domain.IRepositories;
using App.Domain.ValueObject.Filtros;
using App.Domain.ValueObject.ListasPaginadas;

namespace App.Domain.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IList<Usuario>> ObterLista(FiltroUsuario filtroUsuario)
        {
            var listaUsuario = await _usuarioRepository.ObterLista(filtroUsuario);
            return listaUsuario;
        }

        public async Task<ListaPaginadaUsuario> ObterListaPaginada(FiltroUsuario filtroUsuario)
        {
            var listaPaginadaUsuario = await _usuarioRepository.ObterListaPaginada(filtroUsuario);
            return listaPaginadaUsuario;
        }

        public async Task<Usuario> ObterPeloId(Guid id)
        {
            var usuario = await _usuarioRepository.ObterPeloId(id);
            return usuario;
        }

        public async Task<Usuario> Inserir(Usuario usuario)
        {
            usuario = await _usuarioRepository.Inserir(usuario);

            return usuario;
        }

        public async Task<Usuario> Alterar(Usuario usuario)
        {
            usuario = await _usuarioRepository.Alterar(usuario);

            return usuario;
        }

        public async Task Excluir(Guid id)
        {
            await _usuarioRepository.Excluir(id);
        }
    }
}