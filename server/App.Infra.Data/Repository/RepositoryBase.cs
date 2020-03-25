using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities.Interfaces;
using App.Domain.ValueObject.Filtros;
using App.Domain.ValueObject.ListasPaginadas;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repository
{
    public abstract class RepositoryBase<TEntidade, TFiltro, TListaPaginada>
        where TEntidade : IEntity
        where TFiltro : FiltroBase
        where TListaPaginada : ListaPaginadaBase<TEntidade>, new()
    {
        protected virtual async Task<TListaPaginada> Paginar(IQueryable<TEntidade> query, TFiltro filtro)
        {
            var listaPaginada = new TListaPaginada {ItensTotal = await query.CountAsync()};

            if (listaPaginada.ItensTotal > 0 && filtro.TamanhoPagina > 0)
            {
                var divisao = listaPaginada.ItensTotal / (double) filtro.TamanhoPagina;
                var totalPaginas = (int) Math.Ceiling(divisao);

                if (totalPaginas < filtro.Pagina)
                {
                    filtro.Pagina = 1;
                }
            }

            query = query.Skip((filtro.Pagina - 1) * filtro.TamanhoPagina);
            query = query.Take(filtro.TamanhoPagina);
            listaPaginada.Itens = await query.ToListAsync();

            listaPaginada.TamanhoPagina = filtro.TamanhoPagina;

            listaPaginada.Pagina = filtro.Pagina;

            return listaPaginada;
        }

        protected virtual TListaPaginada PaginarLista(IEnumerable<TEntidade> query, TFiltro filtro)
        {
            var enumerable = query.ToList();
            var listaPaginada = new TListaPaginada { ItensTotal = enumerable.Count() };

            if (listaPaginada.ItensTotal > 0 && filtro.TamanhoPagina > 0)
            {
                var divisao = listaPaginada.ItensTotal / (double)filtro.TamanhoPagina;
                var totalPaginas = (int)Math.Ceiling(divisao);

                if (totalPaginas < filtro.Pagina)
                {
                    filtro.Pagina = 1;
                }
            }

            query = enumerable.Skip((filtro.Pagina - 1) * filtro.TamanhoPagina);
            query = query.Take(filtro.TamanhoPagina);
            listaPaginada.Itens = query.ToList();

            listaPaginada.TamanhoPagina = filtro.TamanhoPagina;

            listaPaginada.Pagina = filtro.Pagina;

            return listaPaginada;
        }
    }
}