using System;
using DimeCastsNhScratch.Core;
using NHibernate;
using NHibernate.Cfg;

namespace DimeCastsNhScratch {
    class Program {
        static void Main(string[] args) {
            RunSample();
        }

        private static void RunSample() {
            var cfg = new Configuration();
            cfg.AddAssembly(typeof(Customer).Assembly);

            using (ISessionFactory factory = cfg.BuildSessionFactory()) {
                SaveLoadAndDeleteExample(factory);
            }
        }

        private static void SaveLoadAndDeleteExample(ISessionFactory factory) {
            int bobId;
            using (ISession session = factory.OpenSession()) {
                Customer bob = ObjectMother.Customer();
                Print("Saving Customer ..");
                session.Save(bob);
                session.Flush();

                bobId = bob.CustomerID;
            }

            using (ISession session = factory.OpenSession()) {
                Print("Loading Customer");
                Customer bob = session.Load<Customer>(bobId);
                Print(bob.ToString());
                Print("Loading Customer (again, but should be a cache hit)");

                bob = session.Load<Customer>(bobId);
                Print(bob.ToString());
                Print("Delete the customer");
                session.Delete(bob);
                session.Flush();
            }

            using (ISession session = factory.OpenSession()) {
                Print("Try to load it again");

                try {
                    Customer bob = session.Load<Customer>(bobId);
                    Print("This should not execute " + bob);
                } catch (ObjectNotFoundException ex) {
                    Print("Customer 'Bob' was successfully deleted");
                }
            }
        }

        private static void Print(string input) {
            Console.WriteLine("*** {0}", input);
        }
    }

    public static class ObjectMother {
        public static Customer Customer() {
            return new Customer { FirstName = "Bob", LastName = "Par" };
        }
    }
}
