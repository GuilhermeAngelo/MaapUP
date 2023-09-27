using System.Threading.Tasks;

namespace MaapUP.Infra.interfaces {

    public interface IBaseRepository<T> where T : Base{
        Task<T> Create(T obj);
        Task<T> Update (T obj);
        Task<T> Remove (Long id);
        Task<T>
        Task<T> Get(long id);
        Task<List<T>> Get();
    }
}