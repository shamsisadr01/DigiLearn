﻿using Common.L1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.L1.Domain.Repository;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetAsync(Guid id);

    Task<T?> GetTracking(Guid id);

    Task AddAsync(T entity);
    void Add(T entity);

    Task AddRange(ICollection<T> entities);

    void Update(T entity);
    void Remove(T entity);

    Task<int> Save();
    void SaveSync();

    Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

    bool Exists(Expression<Func<T, bool>> expression);

    T? Get(Guid id);
}

public interface IMongoRepository<TEntity> where TEntity : BaseEntity
{
    Task Delete(Guid id);
    Task<TEntity?> GetById(Guid id);
    Task Insert(TEntity entity);
    Task Update(TEntity entity);

}

