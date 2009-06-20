using System;
using NHibernate;
namespace NHibernateScratch {
    public class Program {
        public static void Main() {
            Employee emp = new Employee() { Name = "Khaja Minhajuddin" };

            //using (var session = NHibernateHelper.OpenSession()) {
            //    //using (ITransaction tx = session.BeginTransaction()) {
            //    session.Save(emp);
            //    //session.Flush();
            //    //}
            //}

            //using (var session = NHibernateHelper.OpenSession()) {
            //    var employee = session.Load<Employee>(9);
            //}

            //using (var session = NHibernateHelper.OpenSession()) {
            //    var employee = session.Load<Employee>(9);
            //    Print("Loaded the employee");
            //    Print(employee.ToString());
            //    Print("Printed the employee");

            //    Print(employee.Manager.ToString());
            //    Print("Printed Manager's info");
            //}
            //Print("Added an employee with an Id " + emp.Id);
            //AddEmployeeWithManager();
            //PrintJackysBosses();
            UpdateJacky();
            Print("done");
        }

        private static void Print(string input) {
            Console.WriteLine("****** {0}", input);
        }

        private static void AddEmployeeWithManager() {
            using (var session = NHibernateHelper.OpenSession()) {
                Employee super = session.Load<Employee>(9);
                Employee manager = new Employee { Name = "Super-Boss", Manager = super };
                Employee emp = new Employee() { Name = "Jack Welch", Manager = manager };

                session.Save(emp);
            }
        }

        private static void PrintJackysBosses() {
            using (var session = NHibernateHelper.OpenSession()) {
                var emp = session.Load<Employee>(11);
                while (emp.Manager != null) {
                    Print(emp.ToString());
                    emp = emp.Manager;
                }
            }
        }

        private static void UpdateJacky() {
            using (ISession session = NHibernateHelper.OpenSession()) {
                using (ITransaction tx = session.BeginTransaction()) {
                    var emp = session.Load<Employee>(11);
                    emp.Name = "Jacky \"The Hairy\"";
                    //Print(emp.ToString());
                    //session.SaveOrUpdate(emp);
                    tx.Commit();
                }

            }
        }
    }
}