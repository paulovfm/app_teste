using System;
using System.Threading.Tasks;
using App.Domain.Entities;
using App.Domain.IRepositories.IBase;
using App.Domain.ValueObject.Filtros;
using App.Domain.ValueObject.ListasPaginadas;

namespace App.Domain.IRepositories
{
    public interface IFuncionalidadeRepository : IRepository<Funcionalidade, FiltroFuncionalidade, ListaPaginadaFuncionalidade>
    {
        Task<bool> FuncionalidadeUtilizada(Guid id);
    }
}