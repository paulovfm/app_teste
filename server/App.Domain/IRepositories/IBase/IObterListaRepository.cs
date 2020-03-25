using System.Collections.Generic;
using System.Threading.Tasks;
using App.Domain.ValueObject.Filtros;

namespace App.Domain.IRepositories.IBase
{
    public interface IObterListaRepository<TEntidade, in TFiltro>
        where TFiltro : FiltroBase
    {
        Task<IList<TEntidade>> ObterLista(TFiltro filtro);
    }
}