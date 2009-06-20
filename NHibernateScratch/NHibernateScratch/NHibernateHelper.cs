using NHibernate;
using NHibernate.Cfg;
namespace NHibernateScratch {
    public class NHibernateHelper {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory {
            get {
                if (_sessionFactory == null) {
                    _sessionFactory = (new Configuration())
                                        .Configure()
                                        .AddAssembly(typeof(Employee).Assembly)
                                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession() {
            return SessionFactory.OpenSession();
        }
    }
}