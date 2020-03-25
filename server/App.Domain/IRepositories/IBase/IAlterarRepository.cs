using System.Threading.Tasks;

namespace App.Domain.IRepositories.IBase
{
    public interface IAlterarRepository<TEntidade>
    {
        Task<TEntidade> Alterar(TEntidade entidade);
    }
}