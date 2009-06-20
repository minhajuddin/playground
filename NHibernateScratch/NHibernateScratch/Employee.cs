namespace NHibernateScratch {
    public class Employee {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Employee Manager { get; set; }

        public override string ToString() {
            return string.Format("ID# {0} \nName:{1}", Id, Name);
            //return string.Format("ID# {0} \nName:{1}\nManager:{2}", Id, Name, Manager != null ? Manager.Name : "NONE");
        }
    }
}