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
    public class UsuarioRepository : RepositoryBase<Usuario, FiltroUsuario, ListaPaginadaUsuario>, IUsuarioRepository
    {
        private readonly WebAppContext _db;

        public UsuarioRepository(WebAppContext db)
        {
            _db = db;
        }

        public async Task<IList<Usuario>> ObterLista(FiltroUsuario filtroUsuario)
        {
            var query = _db.Usuario
                    .Where(x => !x.Excluido
                        && x.Id == filtroUsuario.Id)
                    .OrderBy(x => x.Nome)
                    .AsNoTracking()
                    .AsQueryable();

            var usuario = await query.ToListAsync();

            return usuario;
        }

        public async Task<ListaPaginadaUsuario> ObterListaPaginada(FiltroUsuario filtroUsuario)
        {
            var query = _db.Usuario
                .Include($"{nameof(Usuario.Perfil)}")
                    .Where(x => !x.Excluido)
                    .OrderBy(x => x.Nome)
                    .AsNoTracking()
                    .AsQueryable();

            var listaPaginadaUsuario = await Paginar(query, filtroUsuario);

            return listaPaginadaUsuario;
        }

        public async Task<Usuario> ObterPeloId(Guid id)
        {
            var query = _db.Usuario
                .Include($"{nameof(Usuario.Perfil)}")
                .Where(x => x.Id == id)
                .AsQueryable();

            var usuario = await query.FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<Usuario> Inserir(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            usuario.DataCadastro = DateTime.UtcNow;

            _db.Usuario.Add(usuario);

            await _db.SaveChangesAsync();

            var retorno = await ObterPeloId(usuario.Id);

            return retorno;
        }

        public async Task<Usuario> Alterar(Usuario usuario)
        {
            usuario.DataAtualizacao = DateTime.UtcNow;

            _db.Entry(usuario).State = EntityState.Modified;

            await _db.SaveChangesAsync();

            var retorno = await ObterPeloId(usuario.Id);

            return retorno;
        }

        public async Task Excluir(Guid id)
        {
            var usuario = await ObterPeloId(id);

            usuario.DataAtualizacao = DateTime.UtcNow;
            usuario.Excluido = true;

            _db.Entry(usuario).State = EntityState.Modified;

            await _db.SaveChangesAsync();
        }
    }
}