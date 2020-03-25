using System.Linq;
using App.Domain.ValueObject.ListasPaginadas;

namespace App.Application.ViewModels.ListasPaginadas
{
    public class ListaPaginadaPerfilViewModel : ListaPaginadaBase<PerfilViewModel>
    {
        public static ListaPaginadaPerfilViewModel FromDomainModel(ListaPaginadaPerfil listaPaginada)
        {
            var listaPaginadaViewModel = new ListaPaginadaPerfilViewModel
            {
                TamanhoPagina = listaPaginada.TamanhoPagina,
                Pagina = listaPaginada.Pagina,
                ItensTotal = listaPaginada.ItensTotal,
                Itens = listaPaginada.Itens.Select(PerfilViewModel.FromDomainModel).ToList()
            };

            return listaPaginadaViewModel;
        }
    }
}