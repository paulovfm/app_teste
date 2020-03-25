using System;
using System.Threading.Tasks;

namespace App.Domain.IRepositories.IBase
{
    public interface IObterPeloIdRepository<TEntidade>
    {
        Task<TEntidade> ObterPeloId(Guid id);
    }
}