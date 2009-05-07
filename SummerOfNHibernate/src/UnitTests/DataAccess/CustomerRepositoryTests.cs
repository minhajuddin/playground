using MbUnit.Framework;
using Core.DataAccess;
using Core.Domain;
using System.Collections.Generic;

namespace UnitTests.DataAccess {
    [TestFixture]
    public class CustomerRepositoryTests {
        CustomerRepository _repo;

        [FixtureSetUp]
        public void FixtureSetup() {
            _repo = new CustomerRepository();
        }

        [Test]
        public void GetCustomerByIdReturnsACustomer() {
            var customer = _repo.GetCustomerById(1);
            Assert.IsNotNull(customer);
            Assert.AreEqual(1, customer.ID);
        }

        [Test]
        public void GetCustomerByFirstNameShouldReturnAnIListOfCustomerWithAMatchingFirstName() {
            var customers = _repo.GetCustomersByFirstName("Khaja");

            Assert.IsNotNull(customers);
            Assert.IsInstanceOfType(typeof(IList<Customer>), customers);
            Assert.IsTrue(customers.Count > 0);
        }
    }
}