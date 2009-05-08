using Core.Domain;
using NHibernate;
using NHibernate.Cfg;
using System.Collections.Generic;
using NHibernate.Criterion;

namespace Core.DataAccess {
    public class CustomerRepository {

        private ISession _session;

        public CustomerRepository() {
            _session = GetSession();
        }


        //HQL Methods
        public Customer GetCustomerById(int id) {
            var customer = _session.Get<Customer>(id);
            return customer;
        }

        public IList<Customer> GetCustomersByFirstName(string firstName) {
            var customers = _session.CreateQuery("select from Customer c where c.FirstName =:firstName")
                .SetString("firstName", firstName)
                .List<Customer>();
            return customers;
        }

        public IList<Customer> GetCustomersByFirstAndLastName(string firstName, string lastName) {

            var customers = _session.CreateQuery("select from Customer c where c.FirstName = :firstName AND c.LastName = :lastName")
                .SetString("firstName", firstName)
                .SetString("lastName", lastName)
                .List<Customer>();
            return customers;
        }

        public IList<string> GetDistinctCustomerFirstnames() {
            return _session.CreateQuery("select distinct c.FirstName from Customer c")
                .List<string>();
        }

        public IList<Customer> GetCustomersOrderedByLastName() {
            return _session.CreateQuery("SELECT FROM Customer C ORDER BY C.LastName")
                .List<Customer>();
        }

        public IList<Customer> GetCustomersWithIdGreaterThan(int id) {

            var customers = _session.CreateQuery("select from Customer c where c.ID > :id")
                .SetInt32("id", id)
                .List<Customer>();

            return customers;

        }

        //Criteria API methods
        public IList<Customer> CAPI_GetCustomersByFirstName(string firstName) {
            ISession _session = GetSession();

            var customers = _session.CreateCriteria<Customer>()
                .Add(new SimpleExpression("FirstName", firstName, "="))
                .List<Customer>();
            return customers;
        }

        public IList<Customer> CAPI_GetCustomersByFirstAndLastName(string firstName, string lastName) {


            var customers = _session.CreateCriteria<Customer>()
                .Add(new SimpleExpression("FirstName", firstName, "="))
                .Add(new SimpleExpression("LastName", lastName, "="))
                .List<Customer>();
            return customers;
        }

        public IList<Customer> CAPI_GetCustomersWithIdGreaterThan(int id) {

            var customers = _session
                .CreateCriteria<Customer>()
                .Add(new SimpleExpression("ID", id, ">"))
                .List<Customer>();

            return customers;

        }

        public IList<string> CAPI_GetDistinctCustomerFirstnames() {
            return _session.CreateCriteria<Customer>()
                .SetProjection(Projections.Distinct(Projections.Property("FirstName")))
                .List<string>();
        }

        //Query By Example methods
        public IList<Customer> GetCustomersByExample(Customer customer) {
            ISession _session = GetSession();
            var customers = _session.CreateCriteria<Customer>()
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