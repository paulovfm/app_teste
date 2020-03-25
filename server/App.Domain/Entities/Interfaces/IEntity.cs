using System;

namespace App.Domain.Entities.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}