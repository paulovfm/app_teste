using System;
using System.Threading.Tasks;

namespace App.Domain.IRepositories.IBase
{
    public interface IExcluirRepository
    {
        Task Excluir(Guid id);
    }
}