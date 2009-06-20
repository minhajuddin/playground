using System.Collections.Generic;
using Soh.Data;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;

namespace Soh.Infrastructure {
    public class CustomerRepository {
        private ISessionFactory _factory;

        public CustomerRepository() {
            _factory = (new Configuration())
                .Configure()
                .BuildSessionFactory();
        }

        private ISession GetSession() {
            return _factory.OpenSession();
        }


        public Customer GetCustomerById(int customerId) {
            ISession session = GetSession();
            return session.Get<Customer>(customerId);
        }

        public IList<Customer> GetCustomerByNameHql(string firstName) {
            ISession session = GetSession();
            return session.CreateQuery("select from Customer c where c.FirstName=:fn")
                .SetString("fn", firstName)
                .List<Customer>();
        }

        public IList<Customer> GetCustomersWithIdGreaterThanHql(int id) {
            ISession session = GetSession();
            return session.CreateQuery("select from Customer c where c.CustomerId > :cid")
                .SetInt32("cid", id)
                .List<Customer>();
        }

        public IList<Customer> GetCustomerByNameCrit(string firstname) {
            ISession session = GetSession();
            return session.CreateCriteria(typeof(Customer))
                .Add(Restrictions.Eq("FirstName", firstname))
                .List<Customer>();
        }
    }
}