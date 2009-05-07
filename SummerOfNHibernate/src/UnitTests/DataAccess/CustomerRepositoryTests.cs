using MbUnit.Framework;
using Core.DataAccess;

namespace UnitTests.DataAccess {
    [TestFixture]
    public class CustomerRepositoryTests {
        [Test]
        public void GetCustomerByIdReturnsACustomer() {
            var repo = new CustomerRepository();
            var customer = repo.GetCustomerById(1);
            Assert.IsNotNull(customer);
            Assert.AreEqual(1, customer.ID);
        }
    }
}