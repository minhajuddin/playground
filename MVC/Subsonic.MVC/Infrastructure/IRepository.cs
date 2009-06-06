using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Collections;

namespace Subsonic.Web.Models {
    public interface IRepository<T> {
        IQueryable<T> GetAll();
        PagedList<T> GetPaged<TKey>(Func<T,TKey> orderBy, int pageIndex, int pageSize);
        PagedList<T> GetPaged(int pageIndex, int pageSize);
        PagedList<T> GetPaged(string sortBy, int pageIndex, int pageSize);
        IList<T> Search(string column, string value);
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T item);
        int Update(T item);
        int Delete(T item);
        int Delete(object key);
        int Delete(Expression<Func<T, bool>> expression);
        T GetByKey(object key);


        
    }
}
