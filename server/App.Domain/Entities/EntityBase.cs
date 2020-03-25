using System;
using App.Domain.Entities.Interfaces;

namespace App.Domain.Entities
{
    public class EntityBase : IEntity
    {
        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public DateTime? DataAtualizacao { get; set; }

        public bool Excluido { get; set; } = false;
    }
}
