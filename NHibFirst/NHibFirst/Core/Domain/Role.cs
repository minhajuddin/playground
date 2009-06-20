using System.Collections.Generic;
namespace NHibFirst.Core.Domain {
    public class Role {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<User> UsersInRole { get; set; }
    }
}