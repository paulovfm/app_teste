using App.Domain.Entities;
using App.Domain.IRepositories.IBase;
using App.Domain.ValueObject.Filtros;
using App.Domain.ValueObject.ListasPaginadas;

namespace App.Domain.IRepositories
{
    public interface IUsuarioRepository : IRepository<Usuario, FiltroUsuario, ListaPaginadaUsuario>
    {
        
    }
}