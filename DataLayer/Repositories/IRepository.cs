using DataExtractionTool.DataLayer.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataExtractionTool.DataLayer.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAllAsync();
        decimal Max(Func<T, decimal> predicate);
        //IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        Task<T> FindByIdAsync(int id);

        Task<List<T>> FindByExpressionAsync(Expression<Func<T, bool>> predicate);

        bool Exists(Expression<Func<T, bool>> predicate);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        int ExecuteProc(string query, SqlParameter[] param);
        Task<List<T>> GetDataProc(string query, SqlParameter[] param);
    }
}
