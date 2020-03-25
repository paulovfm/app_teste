using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    [Table("Perfil")]
    public class Perfil : EntityBase
    {
        public string Nome { get; set; }

        public virtual List<Usuario> Usuario { get; set; }

        public virtual List<PerfilFuncionalidade> PerfilFuncionalidade { get; set; }
    }
}