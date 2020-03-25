using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.Domain.IRepositories;
using App.Domain.ValueObject.Filtros;
using App.Domain.ValueObject.ListasPaginadas;

namespace App.Domain.Services
{
    public class PerfilService
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilService(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        public async Task<IList<Perfil>> ObterLista(FiltroPerfil filtroPerfil)
        {
            var listaPerfil = await _perfilRepository.ObterLista(filtroPerfil);
            return listaPerfil;
        }

        public async Task<ListaPaginadaPerfil> ObterListaPaginada(FiltroPerfil filtroPerfil)
        {
            var listaPaginadaPerfil = await _perfilRepository.ObterListaPaginada(filtroPerfil);
            return listaPaginadaPerfil;
        }

        public async Task<Perfil> ObterPeloId(Guid id)
        {
            var perfil = await _perfilRepository.ObterPeloId(id);
            return perfil;
        }

        public async Task<Perfil> Inserir(Perfil perfil)
        {
            perfil = await _perfilRepository.Inserir(perfil);

            return perfil;
        }

        public async Task<Perfil> Alterar(Perfil perfil)
        {
            perfil = await _perfilRepository.Alterar(perfil);

            return perfil;
        }

        public async Task Excluir(Guid id)
        {
            var perfilUtilizado = await PerfilUtilizado(id);
            if (!perfilUtilizado)
            {
                await _perfilRepository.Excluir(id);
            }
            else
            {
                throw new Exception("Não é possível excluir esse perfil, ele está sendo utilizado em um usuário.");
            }
        }

        public async Task<bool> PerfilUtilizado(Guid id)
        {
            var retorno = await _perfilRepository.PerfilUtilizado(id);

            return retorno;
        }
    }
}