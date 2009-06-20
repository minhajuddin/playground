using System;
using System.Collections.Generic;
namespace DimeCastsNhScratch.Core {
    public class Customer {
        private DateTime _createdDate = DateTime.Now;
        private IList<Order> _orders = new List<Order>();

        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Order> Orders {
            get { return _orders; }
            set { _orders = value; }
        }

        public Store Store { get; set; }
        public DateTime CreatedDate {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
    }

    public class Order {
    }
}