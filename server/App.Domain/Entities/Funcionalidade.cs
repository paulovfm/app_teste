using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    [Table("Funcionalidade")]
    public class Funcionalidade : EntityBase
    {
        public string Nome { get; set; }

        public virtual List<PerfilFuncionalidade> PerfilFuncionalidade { get; set; }
    }
}