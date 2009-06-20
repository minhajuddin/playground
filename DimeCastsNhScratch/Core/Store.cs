namespace DimeCastsNhScratch.Core {
    public class Store {
        public virtual int StorieID { get; set; }
        public virtual string Name { get; set; }
        public virtual string AccountingCode { get; set; }

        public override string ToString() {
            return string.Format("\t#{0}\n\t{1}\n\t{2}", StorieID, Name, AccountingCode);
        }
    }
}