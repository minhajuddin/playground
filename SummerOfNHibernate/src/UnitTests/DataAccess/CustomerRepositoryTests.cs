using MbUnit.Framework;
using Core.DataAccess;
using Core.Domain;
using System.Collections.Generic;
using System;
using System.Linq;

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
            foreach (var cust in customers) {
                Assert.AreEqual("Khaja", cust.FirstName, StringComparison.OrdinalIgnoreCase);
            }
            Assert.IsTrue(customers.Count > 0);
        }

        [Test]
        public void CAPI_GetCustomerByFirstNameShouldReturnAnIListOfCustomerWithAMatchingFirstName() {
            var customers = _repo.CAPI_GetCustomersByFirstName("Khaja");

            Assert.IsNotNull(customers);
            Assert.IsInstanceOfType(typeof(IList<Customer>), customers);
            foreach (var cust in customers) {
                Assert.AreEqual("Khaja", cust.FirstName, StringComparison.OrdinalIgnoreCase);
            }
            Assert.IsTrue(customers.Count > 0);
        }


        [Test]
        public void GetCustomersByFirstAndLastNameReturnsAnIListOfCustomersWithAMatchingFirstNameAndLastName() {
            var customers = _repo.GetCustomersByFirstAndLastName("Khaja", "Minhajuddin");
            Assert.IsNotNull(customers);
            Assert.IsInstanceOfType(typeof(IList<Customer>), customers);
            foreach (var cust in customers) {
                Assert.AreEqual("Khaja", cust.FirstName, StringComparison.OrdinalIgnoreCase);
                Assert.AreEqual("Minhajuddin", cust.LastName, StringComparison.OrdinalIgnoreCase);
            }
            Assert.IsTrue(customers.Count > 0);
        }

        [Test]
        public void CAPI_GetCustomersByFirstAndLastNameReturnsAnIListOfCustomersWithAMatchingFirstNameAndLastName() {
            var customers = _repo.CAPI_GetCustomersByFirstAndLastName("Khaja", "Minhajuddin");
            Assert.IsNotNull(customers);
            Assert.IsInstanceOfType(typeof(IList<Customer>), customers);
            foreach (var cust in customers) {
                Assert.AreEqual("Khaja", cust.FirstName, StringComparison.OrdinalIgnoreCase);
                Assert.AreEqual("Minhajuddin", cust.LastName, StringComparison.OrdinalIgnoreCase);
            }
            Assert.IsTrue(customers.Count > 0);
        }


        [Test]
        public void GetCustomerWithIdGreaterThanReturnsAnIListOfCustomers() {
            var customers = _repo.GetCustomersWithIdGreaterThan(0);
            Assert.IsNotNull(customers);
            Assert.IsInstanceOfType(typeof(IList<Customer>), customers);
            foreach (var cust in customers) {
                Assert.IsTrue(0 < cust.ID);
            }
            Assert.IsTrue(customers.Count > 0);
        }

        [Test]
        public void CAPI_GetCustomerWithIdGreaterThanReturnsAnIListOfCustomers() {
            var customers = _repo.CAPI_GetCustomersWithIdGreaterThan(0);
            Assert.IsNotNull(customers);
            Assert.IsInstanceOfType(typeof(IList<Customer>), customers);
            foreach (var cust in customers) {
                Assert.IsTrue(0 < cust.ID);
            }
            Assert.IsTrue(customers.Count > 0);
        }

        //QBE Tests
        [Test]
        public void CanGetCustomersByExample() {
            var ipCustomer = new Customer { FirstName = "Khaja" };
            var customers = _repo.GetCustomersByExample(ipCustomer);

            Assert.IsNotNull(customers);
            Assert.IsInstanceOfType(typeof(IList<Customer>), customers);
            foreach (var cust in customers) {
                Assert.AreEqual("Khaja", cust.FirstName, StringComparison.OrdinalIgnoreCase);
            }
            Assert.IsTrue(customers.Count > 0);
        }

        [Test]
        public void CanGetCustomersByExampleWithFirstNameAndLastName() {
            var ipCustomer = new Customer { FirstName = "Khaja", LastName = "Minhajuddin" };
            var customers = _repo.GetCustomersByExample(ipCustomer);

            Assert.IsNotNull(customers);
            Assert.IsInstanceOfType(typeof(IList<Customer>), customers);
            foreach (var cust in customers) {
                Assert.AreEqual("Khaja", cust.FirstName, StringComparison.OrdinalIgnoreCase);
                Assert.AreEqual("Minhajuddin", cust.LastName, StringComparison.OrdinalIgnoreCase);
            }
            Assert.IsTrue(customers.Count > 0);
        }

        [Test]
        public void CanGetDistinctFirstNames() {
            var firstNames = _repo.GetDistinctCustomerFirstnames();

            foreach (var fn in firstNames) {
                Assert.AreEqual(1, firstNames.Count(x => x == fn));
            }
        }

        [Test]
        public void CAPI_CanGetDistinctFirstNames() {
            var firstNames = _repo.CAPI_GetDistinctCustomerFirstnames();

            foreach (var fn in firstNames) {
                Assert.AreEqual(1, firstNames.Count(x => x == fn));
            }
        }

        [Test]
        public void CanGetCustomersOrderredByLastName() {
            var customers = _repo.GetCustomersOrderedByLastName();
            Customer prevCust = null;
            foreach (var cust in customers) {
                if (prevCust != null) {
                    Assert.GreaterThanOrEqualTo(string.Compare(cust.LastName, prevCust.LastName, true), 0);
                }
                prevCust = cust;
            }
        }
    }
}