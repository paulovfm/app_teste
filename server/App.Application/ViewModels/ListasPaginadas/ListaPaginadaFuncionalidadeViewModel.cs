using System.Linq;
using App.Domain.ValueObject.ListasPaginadas;

namespace App.Application.ViewModels.ListasPaginadas
{
    public class ListaPaginadaFuncionalidadeViewModel : ListaPaginadaBase<FuncionalidadeViewModel>
    {
        public static ListaPaginadaFuncionalidadeViewModel FromDomainModel(ListaPaginadaFuncionalidade listaPaginada)
        {
            var listaPaginadaViewModel = new ListaPaginadaFuncionalidadeViewModel
            {
                TamanhoPagina = listaPaginada.TamanhoPagina,
                Pagina = listaPaginada.Pagina,
                ItensTotal = listaPaginada.ItensTotal,
                Itens = listaPaginada.Itens.Select(FuncionalidadeViewModel.FromDomainModel).ToList()
            };

            return listaPaginadaViewModel;
        }
    }
}