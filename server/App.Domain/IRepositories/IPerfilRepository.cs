using System;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.Domain.IRepositories.IBase;
using App.Domain.ValueObject.Filtros;
using App.Domain.ValueObject.ListasPaginadas;

namespace App.Domain.IRepositories
{
    public interface IPerfilRepository : IRepository<Perfil, FiltroPerfil, ListaPaginadaPerfil>
    {
        Task<bool> PerfilUtilizado(Guid id);
    }
}