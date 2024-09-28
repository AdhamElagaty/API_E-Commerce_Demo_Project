using E_Commerce.Data.Contexts;
using E_Commerce.Data.Entities;
using E_Commerce.Repository.Interfaces;
using E_Commerce.Repository.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Repository
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly ECommerceDbContext _context;
        public GenericRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
            => await _context.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity)
            => _context.Set<TEntity>().Remove(entity);

        public async Task<IReadOnlyList<TEntity>> GetAllAsNoTrackingAsync()
            => await _context.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
            => await _context.Set<TEntity>().ToListAsync();

        public async Task<TEntity> GetByIdAsync(TKey? id)
            => await _context.Set<TEntity>().FindAsync(id);

        public void Update(TEntity entity)
            => _context.Set<TEntity>().Update(entity);

        public async Task<IReadOnlyList<TEntity>> GetAllWithSpecificationAsync(ISpecification<TEntity> specs)
        => await ApplySpecification(specs).ToListAsync();

        public async Task<TEntity> GetWithSpecificationByIdAsync(ISpecification<TEntity> specs)
            => await ApplySpecification(specs).FirstOrDefaultAsync();

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specs)
            => SpecificationEvaluator<TEntity, TKey>.GetQuery(_context.Set<TEntity>(), specs);
        
        public async Task<int> GetCoutSpecificationAsync(ISpecification<TEntity> specs)
            => await ApplySpecification(specs).CountAsync();
    }
}
