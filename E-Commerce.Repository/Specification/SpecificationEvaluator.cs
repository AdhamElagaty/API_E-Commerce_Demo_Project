using E_Commerce.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Specification
{
    public class SpecificationEvaluator<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specs)
        {
            var query = inputQuery;
            if (specs.Criteria is not null)
                query = query.Where(specs.Criteria);

            if (specs.OrderBy is not null)
                query = query.OrderBy(specs.OrderBy);

            if (specs.OrderByDescending is not null)
                query = query.OrderByDescending(specs.OrderByDescending);

            query = specs.Includes.Aggregate(query, (current, includeExpression) => current.Include(includeExpression));

            return query;
        }
    }
}
