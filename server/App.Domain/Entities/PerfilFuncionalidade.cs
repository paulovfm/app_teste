using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    [Table("PerfilFuncionalidade")]
    public class PerfilFuncionalidade : EntityBase
    {
        public Guid PerfilId { get; set; }

        public Guid FuncionalidadeId { get; set; }

        public virtual Perfil Perfil { get; set; }

        public virtual Funcionalidade Funcionalidade { get; set; }
    }
}