using E_Commerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity, TKey>? Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
        Task<int> CompleteAsync();
    }
}
