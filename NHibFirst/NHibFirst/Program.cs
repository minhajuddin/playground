using System;
using NHibernate;
using NHibernate.Cfg;
using NHibFirst.Core.Domain;
namespace NHibFirst {
    class Program {

        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory {
            get {
                if (_sessionFactory == null) {
                    _sessionFactory = (new Configuration())
                        .Configure()
                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }


        static void Main(string[] args) {
            using (ISession session = SessionFactory.OpenSession()) {
                //LoadUser(session);
                //SaveUser(session);
                //LoadComplexUser(session);
                //SaveRole(session);
                //LoadUserWithRole(session);
                //LoadRoleWithUser(session);
                //LoadUsersFromRoleInAUser(session);
                //SaveUsersViaRole(session);
                ChangeTheRole(session);
            }
        }

        private static void ChangeTheRole(ISession session) {
            var parent = session.Get<User>(1);
            Print(parent.ToString());
            var role = session.Get<Role>(3);
            Print(role.ToString());
            parent.Role = role;
            Print(parent.ToString());
            session.Flush();
        }

        private static void SaveUsersViaRole(ISession session) {
            var parent = session.Get<User>(1);
            var user = new User { UserName = "Jacky", CreatedBy = parent, FullName = "Jack Welch", CreatedOn = DateTime.Now, LastLogin = DateTime.Now, Role = new Role { Name = "Normal", Description = "The Normal Guy" } };
            session.Save(user);
        }

        private static void LoadUsersFromRoleInAUser(ISession session) {
            Print("loading user");
            var user = session.Load<User>(1);
            Print(user.ToString());
            Print("users in the same role as current user");
            foreach (User temp in user.Role.UsersInRole) {
                Print(temp.ToString());
            }
        }

        private static void LoadRoleWithUser(ISession session) {
            var role = session.Load<Role>(1);

            Print("Printing role info:");
            Print(role.Description);

            Print("Printint the users in this role");

            foreach (User user in role.UsersInRole) {
                Print(user.ToString());
            }
        }

        private static void LoadUserWithRole(ISession session) {
            var user = session.Load<User>(2);
            Print(user.ToString());
            var otherUser = session.Load<User>(1);
            Print(otherUser.ToString());

            var role = session.Load<Role>(1);
            Print("Some role info");
            Print("{0}\n{1}", role.Name, role.Description);
        }

        private static void SaveRole(ISession session) {
            var role = new Role { Name = "Admin", Description = "Administrators stuf" };
            session.Save(role);
            Print("Saved role");
        }

        private static void LoadComplexUser(ISession session) {
            var user = session.Load<User>(2);
            Print("Loading user");
            Print("{0}", user);
            Print("Printing Manager");
            Print("{0}", user.CreatedBy);
        }

        private static void SaveUser(ISession session) {
            var user = new User
                           {
                               FullName = "Khaja Minhajuddin",
                               CreatedBy = null,
                               LastLogin = DateTime.Now,
                               UserName = "minhajuddin"
                           };

            session.Save(user);
        }

        private static void LoadUser(ISession session) {
            var user = session.Load<User>(1);
            Print("{0}", user);
        }

        private static void Print(string stringFormat, params object[] objects) {
            Console.WriteLine(stringFormat, objects);
        }
    }
}
