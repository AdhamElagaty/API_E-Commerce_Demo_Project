using E_Commerce.Data.Contexts;
using E_Commerce.Data.Entities;
using E_Commerce.Repository.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(ECommerceDbContext context) 
        { 
            _context = context;
        }

        public async Task<int> CompleteAsync()
        => await _context.SaveChangesAsync();

        public IGenericRepository<TEntity, TKey>? Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            if (_repositories is null)
                _repositories = new Hashtable();

            var entityKey = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(entityKey))
            {
                var repositoryType = typeof(GenericRepository<,>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TKey)), _context);

                _repositories.Add(entityKey, repositoryInstance);
            }

            return _repositories[entityKey] as IGenericRepository<TEntity, TKey>;
        }
    }
}
