using MbUnit.Framework;
using Soh.Data;
using Soh.Infrastructure;
using System.Collections.Generic;
namespace InfrastructureTests {
    [TestFixture]
    public class CustomerRepositoryTests {
        private CustomerRepository _customerRepository;

        [FixtureSetUp]
        public void FixtureSetup() {
            _customerRepository = new CustomerRepository();
        }

        [Test]
        public void GetCustomerByIdReturnsACustomer() {
            Customer customer = _customerRepository.GetCustomerById(1);
            Assert.IsNotNull(customer);
            Assert.IsInstanceOfType<Customer>(customer);
        }

        [Test]
        public void GetCustomersByFirstNameReturnsACustomer() {
            IList<Customer> customers = _customerRepository.GetCustomerByNameHql("khaja");
            Assert.IsInstanceOfType<IList<Customer>>(customers);
            Assert.AreEqual(1, customers.Count);
        }

        [Test]
        public void CritGetCustomersByFirstNameReturnsACustomer() {
            IList<Customer> customers = _customerRepository.GetCustomerByNameCrit("khaja");
            Assert.IsInstanceOfType<IList<Customer>>(customers);
            Assert.AreEqual(1, customers.Count);
        }

        [Test]
        public void CanGetCustomersWithIdGreaterThan() {
            var customers = _customerRepository.GetCustomersWithIdGreaterThanHql(1);
            Assert.AreEqual(2, customers.Count);
        }

        
    }
}