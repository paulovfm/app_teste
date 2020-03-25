using System.Threading.Tasks;
using App.Domain.ValueObject.Filtros;
using App.Domain.ValueObject.ListasPaginadas;

namespace App.Domain.IRepositories.IBase
{
    public interface IObterListaPaginadaRepository<TEntidade, in TFiltro, TListaPaginada>
        where TFiltro : FiltroBase
        where TListaPaginada : ListaPaginadaBase<TEntidade>
    {
        Task<TListaPaginada> ObterListaPaginada(TFiltro filtro);
    }
}