using System.Threading.Tasks;

namespace App.Domain.IRepositories.IBase
{
    public interface IInserirRepository<TEntidade>
    {
        Task<TEntidade> Inserir(TEntidade entidade);
    }
}