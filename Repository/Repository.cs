﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace De01_Enews.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _appDbContext;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _dbSet = appDbContext.Set<T>();
    }

    public IEnumerable<T> Get(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = ""
    )
    {
        IQueryable<T> query = _dbSet;
        query = query.Where(filter);
        query = includeProperties
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return orderBy(query).ToList();
    }

    public T? GetById(object id)
    {
        return _dbSet.Find(id);
    }

    public void Insert(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entityToUpdate)
    {
        _dbSet.Update(entityToUpdate);
    }

    public void Delete(object id)
    {
        var entityToDelete = _dbSet.Find(id);
        if (entityToDelete != null) Delete(entityToDelete);
    }

    public void Delete(T entityToDelete)
    {
        // Detached means the entity exists in the application but not managed by entityManager
        if (_appDbContext.Entry(entityToDelete).State == EntityState.Detached)
        {
            _dbSet.Attach(entityToDelete);
        }

        _dbSet.Remove(entityToDelete);
    }
}