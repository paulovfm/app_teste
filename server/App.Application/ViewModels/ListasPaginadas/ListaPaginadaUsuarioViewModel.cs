using System.Linq;
using App.Domain.ValueObject.ListasPaginadas;

namespace App.Application.ViewModels.ListasPaginadas
{
    public class ListaPaginadaUsuarioViewModel : ListaPaginadaBase<UsuarioViewModel>
    {
        public static ListaPaginadaUsuarioViewModel FromDomainModel(ListaPaginadaUsuario listaPaginada)
        {
            var listaPaginadaViewModel = new ListaPaginadaUsuarioViewModel
            {
                TamanhoPagina = listaPaginada.TamanhoPagina,
                Pagina = listaPaginada.Pagina,
                ItensTotal = listaPaginada.ItensTotal,
                Itens = listaPaginada.Itens.Select(UsuarioViewModel.FromDomainModel).ToList()
            };

            return listaPaginadaViewModel;
        }
    }
}