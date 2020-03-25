using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.Domain.IRepositories;
using App.Domain.ValueObject.Filtros;
using App.Domain.ValueObject.ListasPaginadas;

namespace App.Domain.Services
{
    public class FuncionalidadeService
    {
        private readonly IFuncionalidadeRepository _funcionalidadeRepository;

        public FuncionalidadeService(IFuncionalidadeRepository funcionalidadeRepository)
        {
            _funcionalidadeRepository = funcionalidadeRepository;
        }

        public async Task<IList<Funcionalidade>> ObterLista(FiltroFuncionalidade filtroFuncionalidade)
        {
            var listaFuncionalidade = await _funcionalidadeRepository.ObterLista(filtroFuncionalidade);
            return listaFuncionalidade;
        }

        public async Task<ListaPaginadaFuncionalidade> ObterListaPaginada(FiltroFuncionalidade filtroFuncionalidade)
        {
            var listaPaginadaFuncionalidade = await _funcionalidadeRepository.ObterListaPaginada(filtroFuncionalidade);
            return listaPaginadaFuncionalidade;
        }

        public async Task<Funcionalidade> ObterPeloId(Guid id)
        {
            var funcionalidade = await _funcionalidadeRepository.ObterPeloId(id);
            return funcionalidade;
        }

        public async Task<Funcionalidade> Inserir(Funcionalidade funcionalidade)
        {
            funcionalidade = await _funcionalidadeRepository.Inserir(funcionalidade);

            return funcionalidade;
        }

        public async Task<Funcionalidade> Alterar(Funcionalidade funcionalidade)
        {
            funcionalidade = await _funcionalidadeRepository.Alterar(funcionalidade);

            return funcionalidade;
        }

        public async Task Excluir(Guid id)
        {
            var funcionalidadeUtilizada = await FuncionalidadeUtilizada(id);
            if (!funcionalidadeUtilizada)
            {
                await _funcionalidadeRepository.Excluir(id);
            }
            else
            {
                throw new Exception("Não é possível excluir essa funcionalidade, ela está sendo utilizada em um perfil.");
            }
        }

        public async Task<bool> FuncionalidadeUtilizada(Guid id)
        {
            var retorno = await _funcionalidadeRepository.FuncionalidadeUtilizada(id);

            return retorno;
        }
    }
}