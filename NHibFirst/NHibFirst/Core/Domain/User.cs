using System;
namespace NHibFirst.Core.Domain {
    public class User {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string FullName { get; set; }
        public virtual DateTime LastLogin { get; set; }
        private DateTime _createdOn = DateTime.Now;

        public virtual Role Role { get; set; }

        public virtual DateTime CreatedOn {
            get { return _createdOn; }
            set { _createdOn = value; }
        }

        public virtual User CreatedBy { get; set; }

        public override string ToString() {
            return string.Format("\t#{0}\n\tUserName:{1}\n\tName:{2}\n\tRole:{3}",
                                 Id, UserName, FullName,
                                 Role == null ? "NONE" : Role.Name);
        }
    }
}