using Core.Domain;
using NHibernate;
using NHibernate.Cfg;
using System.Collections.Generic;
using NHibernate.Criterion;

namespace Core.DataAccess {
    public class CustomerRepository {


        //HQL Methods
        public Customer GetCustomerById(int id) {
            ISession session = GetSession();
            var customer = session.Get<Customer>(id);
            return customer;
        }

        public IList<Customer> GetCustomersByFirstName(string firstName) {
            ISession session = GetSession();
            var customers = session.CreateQuery("select from Customer c where c.FirstName =:firstName")
                .SetString("firstName", firstName)
                .List<Customer>();
            return customers;
        }

        public IList<Customer> GetCustomersByFirstAndLastName(string firstName, string lastName) {
            var session = GetSession();
            var customers = session.CreateQuery("select from Customer c where c.FirstName = :firstName AND c.LastName = :lastName")
                .SetString("firstName", firstName)
                .SetString("lastName", lastName)
                .List<Customer>();
            return customers;
        }

        public IList<Customer> GetCustomersWithIdGreaterThan(int id) {
            var session = GetSession();
            var customers = session.CreateQuery("select from Customer c where c.ID > :id")
                .SetInt32("id", id)
                .List<Customer>();

            return customers;

        }

        //Criteria API methods
        public IList<Customer> CAPI_GetCustomersByFirstName(string firstName) {
            ISession session = GetSession();

            var customers = session.CreateCriteria<Customer>()
                .Add(new SimpleExpression("FirstName", firstName, "="))
                .List<Customer>();
            return customers;
        }

        public IList<Customer> CAPI_GetCustomersByFirstAndLastName(string firstName, string lastName) {
            var session = GetSession();

            var customers = session.CreateCriteria<Customer>()
                .Add(new SimpleExpression("FirstName", firstName, "="))
                .Add(new SimpleExpression("LastName", lastName, "="))
                .List<Customer>();
            return customers;
        }

        public IList<Customer> CAPI_GetCustomersWithIdGreaterThan(int id) {
            var session = GetSession();
            var customers = session
                .CreateCriteria<Customer>()
                .Add(new SimpleExpression("ID", id, ">"))
                .List<Customer>();

            return customers;

        }

        //Query By Example methods
        public IList<Customer> GetCustomersByExample(Customer customer) {
            ISession session = GetSession();
            var customers = session.CreateCriteria<Customer>()
                .Add(Example.Create(customer))
                .List<Customer>();

            return customers;
        }

        //Helper methods
        private static ISession GetSession() {
            ISessionFactory sessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}