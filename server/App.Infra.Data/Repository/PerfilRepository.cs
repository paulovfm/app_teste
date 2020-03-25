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
    public class PerfilRepository : RepositoryBase<Perfil, FiltroPerfil, ListaPaginadaPerfil>, IPerfilRepository
    {
        private readonly WebAppContext _db;

        public PerfilRepository(WebAppContext db)
        {
            _db = db;
        }

        public async Task<IList<Perfil>> ObterLista(FiltroPerfil filtroPerfil)
        {
            var query = _db.Perfil
                    .Where(x => !x.Excluido)
                    .OrderBy(x => x.Nome)
                    .AsNoTracking()
                    .AsQueryable();

            var perfil = await query.ToListAsync();

            return perfil;
        }

        public async Task<ListaPaginadaPerfil> ObterListaPaginada(FiltroPerfil filtroPerfil)
        {
            var query = _db.Perfil
                    .Where(x => !x.Excluido)
                    .OrderBy(x => x.Nome)
                    .AsNoTracking()
                    .AsQueryable();

            var listaPaginadaPerfil = await Paginar(query, filtroPerfil);

            return listaPaginadaPerfil;
        }

        public async Task<Perfil> ObterPeloId(Guid id)
        {
            var query = _db.Perfil
                .Include($"{nameof(Perfil.PerfilFuncionalidade)}.{nameof(PerfilFuncionalidade.Funcionalidade)}")
                .Where(x => x.Id == id)
                .AsQueryable();

            var perfil = await query.FirstOrDefaultAsync();

            return perfil;
        }

        public async Task<Perfil> Inserir(Perfil perfil)
        {
            perfil.Id = Guid.NewGuid();
            perfil.DataCadastro = DateTime.UtcNow;

            foreach (var perfilFuncionalidade in perfil.PerfilFuncionalidade)
            {
                perfilFuncionalidade.DataCadastro = DateTime.UtcNow;
            }

            _db.Perfil.Add(perfil);

            await _db.SaveChangesAsync();

            var retorno = await ObterPeloId(perfil.Id);

            return retorno;
        }

        public async Task<Perfil> Alterar(Perfil perfil)
        {
            perfil.DataAtualizacao = DateTime.UtcNow;

            _db.Entry(perfil).State = EntityState.Modified;

            var perfilFuncionalidadeDb = _db.PerfilFuncionalidade
                .Where(x => x.PerfilId == perfil.Id)
                .AsNoTracking()
                .AsQueryable();

            foreach (var perfilFuncionalidade in perfilFuncionalidadeDb)
            {
                var existePerfilFuncionalidade = perfil.PerfilFuncionalidade.Find(x => x.FuncionalidadeId == perfilFuncionalidade.FuncionalidadeId);

                if (existePerfilFuncionalidade != null)
                {
                    existePerfilFuncionalidade.Id = perfilFuncionalidade.Id;
                    existePerfilFuncionalidade.DataCadastro = perfilFuncionalidade.DataCadastro;
                    existePerfilFuncionalidade.DataAtualizacao = DateTime.UtcNow;
                    _db.Entry(existePerfilFuncionalidade).State = EntityState.Modified;
                }
                else
                {
                    _db.PerfilFuncionalidade.Remove(perfilFuncionalidade);
                }
            }

            foreach (var perfilFuncionalidade in perfil.PerfilFuncionalidade.Where(perfilFuncionalidade => perfilFuncionalidade.Id == Guid.Empty))
            {
                perfilFuncionalidade.Id = Guid.NewGuid();
                perfilFuncionalidade.DataCadastro = DateTime.UtcNow;
                _db.Entry(perfilFuncionalidade).State = EntityState.Added;
            }

            await _db.SaveChangesAsync();

            var retorno = await ObterPeloId(perfil.Id);

            return retorno;
        }

        public async Task Excluir(Guid id)
        {
            var perfil = await ObterPeloId(id);

            foreach (var perfilFuncionalidade in perfil.PerfilFuncionalidade)
            {
                perfilFuncionalidade.Excluido = true;
            }

            perfil.DataAtualizacao = DateTime.UtcNow;
            perfil.Excluido = true;

            _db.Entry(perfil).State = EntityState.Modified;

            await _db.SaveChangesAsync();
        }

        public async Task<bool> PerfilUtilizado(Guid id)
        {
            var perfilUtilizado = await _db.Usuario
                .Where(x => !x.Excluido
                    && x.PerfilId == id).AnyAsync();

            return perfilUtilizado;
        }
    }
}
