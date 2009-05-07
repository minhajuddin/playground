using Core.Domain;
using NHibernate;
using NHibernate.Cfg;

namespace Core.DataAccess {
    public class CustomerRepository {

        public Customer GetCustomerById(int id) {
            //var config = new Configuration();
            //config.Configure();
            //ISessionFactory sessionFactory = config.BuildSessionFactory();
            ISessionFactory sessionFactory = (new Configuration()).Configure().BuildSessionFactory();
            ISession session = sessionFactory.OpenSession();
            var customer = session.Get<Customer>(id);
            return customer;
        }

    }
}