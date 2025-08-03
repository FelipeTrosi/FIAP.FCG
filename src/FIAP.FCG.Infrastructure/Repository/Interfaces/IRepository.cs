using FIAP.FCG.Domain.Entity;

namespace FIAP.FCG.Infrastructure.Repository.Interfaces;

public interface IRepository<T> where T : EntityBase
{
    IList<T> GetAll();
    T? GetById(long id);
    void Create(T entity);
    void Update(T entity);
    void DeleteById(long id);

}
