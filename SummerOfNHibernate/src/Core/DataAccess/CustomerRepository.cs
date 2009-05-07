using Core.Domain;
using NHibernate;
using NHibernate.Cfg;
using System.Collections.Generic;

namespace Core.DataAccess {
    public class CustomerRepository {

        public Customer GetCustomerById(int id) {
            ISession session = GetSession();
            var customer = session.Get<Customer>(id);
            return customer;
        }

        public IList<Customer> GetCustomersByFirstName(string firstName) {
            ISession session = GetSession();
            var customers = session.CreateQuery("select from Customer c where c.FirstName ='" + firstName + "'").List<Customer>();
            return customers;
        }

        //Helper methods
        private static ISession GetSession() {
            ISessionFactory sessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            return sessionFactory.OpenSession();
        }

    }
}