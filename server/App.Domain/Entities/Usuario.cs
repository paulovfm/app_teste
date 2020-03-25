using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    [Table("Usuario")]
    public class Usuario : EntityBase
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public Guid PerfilId { get; set; }

        public virtual Perfil Perfil { get; set; }
    }
}