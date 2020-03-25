using System;
using System.Collections.Generic;

namespace App.Domain.ValueObject.ListasPaginadas
{
    public abstract class ListaPaginadaBase<T>
    {
        public List<T> Itens { get; set; } = new List<T>();
        public int TamanhoPagina { get; set; } = 10;
        public int Pagina { get; set; } = 1;
        public int ItensTotal { get; set; } = 0;
        public int PaginasTotal
        {
            get
            {
                var retorno = 0;

                if (TamanhoPagina > 0 && ItensTotal > 0)
                {
                    var divisao = (double)ItensTotal / (double)TamanhoPagina;
                    retorno = (int)Math.Ceiling(divisao);
                }

                return retorno;
            }
        }
    }
}