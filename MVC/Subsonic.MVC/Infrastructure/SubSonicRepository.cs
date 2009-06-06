

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.DataProviders;
using SubSonic.Linq;
using SubSonic;
using System.Collections;
using SubSonic.Schema;
using SubSonic.Extensions;
using SubSonic.Query;
using System.Linq.Expressions;

namespace Subsonic.Web.Models {

    /// <summary>
    /// A Repository class which wraps the Chinook Database
    /// </summary>
    public class SubSonicRepository<T> : IRepository<T> where T : new() {

        IQuerySurface _db;
        public SubSonicRepository(IQuerySurface db) {
            _db = db;
        }
        public SubSonicRepository() {
            _db = DB.CreateDB();
        }

        #region IRepository<T> Members

        /// <summary>
        /// Returns all T items from the  Chinook Database
        /// </summary>
        public IQueryable<T> GetAll() {
            return _db.GetQuery<T>();
        }

        /// <summary>
        /// Returns a single record from the Chinook DB by Primary Key
        /// </summary>
        public T GetByKey(object key) {
            ITable tbl = _db.FindTableByClassName(typeof(T).Name);
            return _db.Select.From(tbl)
                .Where(tbl.PrimaryKey.Name).IsEqualTo(key)
                .ExecuteSingle<T>();
        }

        /// <summary>
        /// Returns a server-side Paged List from the  Chinook Database
        /// </summary>
        public PagedList<T> GetPaged<TKey>(Func<T, TKey> orderBy, int pageIndex, int pageSize) {
            
            return new PagedList<T>(_db.GetQuery<T>().OrderBy(orderBy).AsQueryable(), pageIndex, pageSize);
        }
        /// <summary>
        /// Returns a server-side Paged List from the  Chinook Database
        /// </summary>
        public PagedList<T> GetPaged(int pageIndex, int pageSize) {
            ITable tbl = _db.FindTableByClassName(typeof(T).Name);
            string orderBy = tbl.PrimaryKey != null ? tbl.PrimaryKey.Name : tbl.Columns[0].Name;
            return GetPaged(orderBy, pageIndex, pageSize);
        }
        /// <summary>
        /// Returns a server-side Paged List from the  Chinook Database
        /// </summary>
        public PagedList<T> GetPaged(string sortBy, int pageIndex, int pageSize) {
            int totalCount = this.GetAll().Count();
            ITable tbl = _db.FindTableByClassName(typeof(T).Name);
            
            var qry = _db.Select.From(tbl)
                .Paged(pageIndex, pageSize);

            if (!sortBy.EndsWith(" desc", StringComparison.InvariantCultureIgnoreCase)) {
                qry.OrderAsc(sortBy);
            } else {
                qry.OrderDesc(sortBy.Replace(" desc", ""));
            }

            var list = qry.ExecuteTypedList<T>();

            PagedList<T> result = new PagedList<T>(list, totalCount, pageIndex, pageSize);
            

            //pull the page count
            return result;

        
        }
        /// <summary>
        /// Returns an IQueryable  based on the passed-in Expression  Chinook Database
        /// </summary>
        public IList<T> Search(string column, string value) {
            if (!value.EndsWith("%"))
                value += "%";
            var qry = _db.Select.From<T>().Where(column).Like(value).OrderAsc(column);
            return qry.ExecuteTypedList<T>();
        }

        /// <summary>
        /// Returns an IQueryable  based on the passed-in Expression  Chinook Database
        /// </summary>
        public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> expression) {
            return GetAll().Where(expression);
        }

        ISqlQuery BuildUpdateQuery(T item) {
            ITable tbl = _db.FindTable(typeof(T).Name);
            Update<T> query = new Update<T>(_db.Provider);
            int result = 0;
            if (tbl != null) {
                var settings = item.ToDictionary();

                foreach (string key in settings.Keys) {
                    IColumn col = tbl.GetColumn(key);
                    if (col != null) {
                        if (col.IsPrimaryKey) {
                            Constraint c = new Constraint(ConstraintType.Where, col.Name);
                            c.ParameterValue = settings[col.Name];
                            c.ParameterName = col.Name;
                            c.ConstructionFragment = col.Name;
                            query.Constraints.Add(c);

                        } else {
                            query.Set(col.Name).EqualTo(settings[key]);
                        }
                    }
                }

                if (query.Constraints.Count == 0) {
                    query.Constraints = item.ToConstraintList();
                }
            }
            return query;
        }

        ISqlQuery BuildInsertQuery(T item) {
            ITable tbl = _db.FindTableByClassName(typeof(T).Name);
            Insert query = null;
            if (tbl != null) {
                var hashed = item.ToDictionary();
                query = new Insert(_db.Provider).Into<T>(tbl); ;
                foreach (string key in hashed.Keys) {
                    IColumn col = tbl.GetColumn(key);
                    if (col != null) {
                        if (!col.AutoIncrement) {
                            query.Value(key, hashed[key]);
                        }
                    }
                }
            }
            return query;
        }

        ISqlQuery BuildDeleteQuery(T item) {
            ITable tbl = _db.FindTable(typeof(T).Name);
            int result = 0;
            var query = new Delete<T>(_db.Provider);
            if (tbl != null) {
                IColumn pk = tbl.PrimaryKey;
                var settings = item.ToDictionary();
                if (pk != null) {
                    Constraint c = new Constraint(ConstraintType.Where, pk.Name);
                    c.ParameterValue = settings[pk.Name];
                    c.ParameterName = pk.Name;
                    c.ConstructionFragment = pk.Name;
                    query.Constraints.Add(c);
                } else {
                    query.Constraints = item.ToConstraintList();
                }
            }
            return query;
        }

        /// <summary>
        /// Adds a T item to the Chinook Database
        /// </summary>
        public void Add(T item) {
            var query = BuildInsertQuery(item);
            if (query != null)
                query.Execute();
        }


        /// <summary>
        /// Adds a bunch of T items to the Chinook Database
        ///</summary>
        public void Add(IEnumerable<T> items) {
            BatchQuery bQuery = new BatchQuery(_db.Provider);
            foreach (T item in items) {
                var query = BuildInsertQuery(item);
                bQuery.Queue(query);
            }
            bQuery.Execute();
        }


        /// <summary>
        /// Updates the passed-in T item in the Chinook Database
        /// </summary>
        public int Update(T item) {
            int result = 0;
            var query = BuildUpdateQuery(item);
            if (query != null)
                result = query.Execute();
            return result;
        }

        /// <summary>
        /// Updates the passed-in T items in the Chinook Database
        /// </summary>
        public int Update(IEnumerable<T> items) {
            BatchQuery bQuery = new BatchQuery(_db.Provider);
            int result = 0;

            foreach (T item in items) {
                var query = BuildUpdateQuery(item);
                bQuery.Queue(query);
            }
            result = bQuery.Execute();
            return result;
        }

        /// <summary>
        /// Deletes the passed-in T items in the Chinook Database
        /// </summary>
        public int Delete(IEnumerable<T> items) {
            BatchQuery bQuery = new BatchQuery(_db.Provider);
            int result = 0;

            foreach (T item in items) {
                var query = BuildUpdateQuery(item);
                if (query != null)
                    bQuery.Queue(query);
            }
            result = bQuery.Execute();
            return result;
        }

        /// <summary>
        /// Deletes the passed-in T item from the Chinook Database
        /// </summary>
        public int Delete(T item) {
            int result = 0;
            var query = BuildDeleteQuery(item);
            if (query != null) {
                result = query.Execute();
            }
            return result;
        }
        /// <summary>
        /// Deletes the T item from the Chinook Database by Primary Key
        /// </summary>
        public int Delete(object key) {
            ITable tbl = _db.FindTable(typeof(T).Name);
            int result = 0;
            if (tbl != null) {
                result = new Delete<T>(_db.Provider).Where(tbl.PrimaryKey.Name).IsEqualTo(key).Execute();
            }
            return result;
        }

        /// <summary>
        /// Deletes 0 to n T items from the Chinook Database based on the passed-in Expression
        /// </summary>
        public int Delete(Expression<Func<T, bool>> expression) {
            return _db.Delete(expression).Execute();
        }

        #endregion
    }
}
