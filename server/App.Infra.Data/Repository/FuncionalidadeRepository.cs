using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.Domain.IRepositories;
using App.Domain.ValueObject.Filtros;
using App.Domain.ValueObject.ListasPaginadas;
using App.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repository
{
    public class FuncionalidadeRepository : RepositoryBase<Funcionalidade, FiltroFuncionalidade, ListaPaginadaFuncionalidade>, IFuncionalidadeRepository
    {
        private readonly WebAppContext _db;

        public FuncionalidadeRepository(WebAppContext db)
        {
            _db = db;
        }

        public async Task<IList<Funcionalidade>> ObterLista(FiltroFuncionalidade filtroFuncionalidade)
        {
            var query = _db.Funcionalidade
                    .Where(x => !x.Excluido)
                    .OrderBy(x => x.Nome)
                    .AsNoTracking()
                    .AsQueryable();

            var funcionalidade = await query.ToListAsync();

            return funcionalidade;
        }

        public async Task<ListaPaginadaFuncionalidade> ObterListaPaginada(FiltroFuncionalidade filtroFuncionalidade)
        {
            var query = _db.Funcionalidade
                    .Where(x => !x.Excluido)
                    .OrderBy(x => x.Nome)
                    .AsNoTracking()
                    .AsQueryable();

            var listaPaginadaFuncionalidade = await Paginar(query, filtroFuncionalidade);

            return listaPaginadaFuncionalidade;
        }

        public async Task<Funcionalidade> ObterPeloId(Guid id)
        {
            var query = _db.Funcionalidade
                .Where(x => x.Id == id)
                .AsQueryable();

            var funcionalidade = await query.FirstOrDefaultAsync();

            return funcionalidade;
        }

        public async Task<Funcionalidade> Inserir(Funcionalidade funcionalidade)
        {
            funcionalidade.Id = Guid.NewGuid();
            funcionalidade.DataCadastro = DateTime.UtcNow;

            _db.Funcionalidade.Add(funcionalidade);

            await _db.SaveChangesAsync();

            return funcionalidade;
        }

        public async Task<Funcionalidade> Alterar(Funcionalidade funcionalidade)
        {
            funcionalidade.DataAtualizacao = DateTime.UtcNow;

            _db.Entry(funcionalidade).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            return funcionalidade;
        }

        public async Task Excluir(Guid id)
        {
            var funcionalidade = await ObterPeloId(id);

            funcionalidade.DataAtualizacao = DateTime.UtcNow;
            funcionalidade.Excluido = true;

            _db.Entry(funcionalidade).State = EntityState.Modified;

            await _db.SaveChangesAsync();
        }

        public async Task<bool> FuncionalidadeUtilizada(Guid id)
        {
            var funcionalidadeUtilizada = await _db.PerfilFuncionalidade
                .Where(x => !x.Excluido
                    && x.FuncionalidadeId == id).AnyAsync();

            return funcionalidadeUtilizada;
        }
    }
}