using System;
using System.Collections.Generic;

namespace App.Domain.ValueObject.Filtros
{
    public abstract class FiltroBase
    {
        public Guid Id { get; set; }

        public List<Guid> Ids { get; set; } = new List<Guid>();

        public string Termo { get; set; } = "";

        public int TamanhoPagina { get; set; } = 10;

        public int Pagina { get; set; } = 1;

        public bool? Excluido { get; set; }
    }
}