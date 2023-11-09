
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataExtractionTool.DataLayer.Models;

namespace DataExtractionTool.DataLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataExtractionToolContext dbContext;
        public Repository(DataExtractionToolContext diabetestalContext)
        {
            dbContext = diabetestalContext;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.dbContext.Set<T>().ToListAsync();
        }
        public decimal Max(Func<T, decimal> predicate)
        {
            return this.dbContext.Set<T>().Max(predicate);
        }
        public async Task<T> FindByIdAsync(int id)
        {
            
            return await this.dbContext.Set<T>().FindAsync(id);
        }

        public  bool Exists(Expression<Func<T, bool>> predicate)
        {

            return  this.dbContext.Set<T>().Any(predicate);
        }

        public async Task<List<T>> FindByExpressionAsync(Expression<Func<T, bool>> predicate)
        {

            return await this.dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<int> AddAsync(T entity)
        {
            this.dbContext.Add(entity);
            return await this.dbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(T entity)
        {
            this.dbContext.Update(entity);
            return await this.dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(T entity)
        {
            this.dbContext.Remove(entity);
            return await this.dbContext.SaveChangesAsync();
        }
        public int ExecuteProc(string query, SqlParameter[] param = null)
        {
            if (param == null)
                return dbContext.Database.ExecuteSqlRaw(query);
            return dbContext.Database.ExecuteSqlRaw(query, param);
        }
        public async Task<List<T>> GetDataProc(string query, SqlParameter[] param = null)
        {
            if (param == null)
                return await dbContext.Set<T>().FromSqlRaw(query).ToListAsync();

            return await dbContext.Set<T>().FromSqlRaw(query, param).ToListAsync();
        }

        //public int ExecuteAndGetDataProc(string query, SqlParameter[] param = null)
        //{
        //    if (param == null)
        //        return dbContext.Set<T>().FromSqlRaw(query);

        //    return dbContext.Set<T>().FromSqlRaw(query, param);
        //}
    }
}
