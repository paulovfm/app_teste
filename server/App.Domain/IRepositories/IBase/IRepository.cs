using App.Domain.ValueObject.Filtros;
using App.Domain.ValueObject.ListasPaginadas;

namespace App.Domain.IRepositories.IBase
{
    public interface IRepository<TEntidade, in TFiltro, TListaPaginada> : IObterListaRepository<TEntidade, TFiltro>, IInserirRepository<TEntidade>, IObterPeloIdRepository<TEntidade>, IAlterarRepository<TEntidade>, IExcluirRepository, IObterListaPaginadaRepository<TEntidade, TFiltro, TListaPaginada>
        where TFiltro : FiltroBase
        where TListaPaginada : ListaPaginadaBase<TEntidade>
    {
    }
}