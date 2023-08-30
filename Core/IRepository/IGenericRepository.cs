using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Update;

namespace DemoApp.Core.IRespository;

public interface IGenericRespository <T>  where T: class
{
    protected Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null,bool tracked = true);
    protected Task<T> GetAsync(Expression<Func<T, bool>>? filter = null,bool tracked = true);
    protected Task<bool> Delete(T entity);
    protected Task<T> Update(T entity);
    protected Task<T> CreateAsync(T entity);

}