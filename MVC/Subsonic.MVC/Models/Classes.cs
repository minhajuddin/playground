

using System;
using SubSonic.Linq;
using System.Linq;
using System.ComponentModel;


namespace Subsonic.Web.Models{

    /// <summary>
    /// A class which represents the Album table in the Chinook Database.
    /// This class is queryable through Chinook.DB.Album
    /// </summary>
	public partial class Album: INotifyPropertyChanging, INotifyPropertyChanged {
	    public Album(){
	        OnCreated();
	    }
	
        public string KeyName (){
            return "AlbumId";
        }
        public int KeyValue (){
            return _AlbumId;
        }
		int _AlbumId;
		public int AlbumId { 
		    get{
		        return _AlbumId;
		    } 
		    set{
		        this.OnAlbumIdChanging(value);
                this.SendPropertyChanging();
                this._AlbumId = value;
                this.SendPropertyChanged("AlbumId");
                this.OnAlbumIdChanged();
		    }
		}
		
        public string DescriptorValue(){
            return this.Title;
        }
        public string DescriptorColumn() {
            return "Title";
        }
        public override string ToString(){
            return this.Title;
        }
        public static string GetDescriptorColumn() {
            return "Title";
        }
		string _Title;
		public string Title { 
		    get{
		        return _Title;
		    } 
		    set{
		        this.OnTitleChanging(value);
                this.SendPropertyChanging();
                this._Title = value;
                this.SendPropertyChanged("Title");
                this.OnTitleChanged();
		    }
		}
		
		int _ArtistId;
		public int ArtistId { 
		    get{
		        return _ArtistId;
		    } 
		    set{
		        this.OnArtistIdChanging(value);
                this.SendPropertyChanging();
                this._ArtistId = value;
                this.SendPropertyChanged("ArtistId");
                this.OnArtistIdChanged();
		    }
		}
		


        #region Extensibility Hooks
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnAlbumIdChanging(int value);
        partial void OnAlbumIdChanged();
        partial void OnTitleChanging(string value);
        partial void OnTitleChanged();
        partial void OnArtistIdChanging(int value);
        partial void OnArtistIdChanged();
       
        #endregion


        #region Foriegn Keys
      
        public IQueryable<Artist> Artists {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.Artists
                       where items.ArtistId == _ArtistId
                       select items;
            }
        }

      
        public IQueryable<Track> Tracks {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.Tracks
                       where items.AlbumId == _AlbumId
                       select items;
            }
        }

        
        #endregion

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging() {
            if ((this.PropertyChanging != null)) {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName) {
            if ((this.PropertyChanged != null)) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
	}

    /// <summary>
    /// A class which represents the Track table in the Chinook Database.
    /// This class is queryable through Chinook.DB.Track
    /// </summary>
	public partial class Track: INotifyPropertyChanging, INotifyPropertyChanged {
	    public Track(){
	        OnCreated();
	    }
	
        public string KeyName (){
            return "TrackId";
        }
        public int KeyValue (){
            return _TrackId;
        }
		int _TrackId;
		public int TrackId { 
		    get{
		        return _TrackId;
		    } 
		    set{
		        this.OnTrackIdChanging(value);
                this.SendPropertyChanging();
                this._TrackId = value;
                this.SendPropertyChanged("TrackId");
                this.OnTrackIdChanged();
		    }
		}
		
        public string DescriptorValue(){
            return this.Name;
        }
        public string DescriptorColumn() {
            return "Name";
        }
        public override string ToString(){
            return this.Name;
        }
        public static string GetDescriptorColumn() {
            return "Name";
        }
		string _Name;
		public string Name { 
		    get{
		        return _Name;
		    } 
		    set{
		        this.OnNameChanging(value);
                this.SendPropertyChanging();
                this._Name = value;
                this.SendPropertyChanged("Name");
                this.OnNameChanged();
		    }
		}
		
		int _AlbumId;
		public int AlbumId { 
		    get{
		        return _AlbumId;
		    } 
		    set{
		        this.OnAlbumIdChanging(value);
                this.SendPropertyChanging();
                this._AlbumId = value;
                this.SendPropertyChanged("AlbumId");
                this.OnAlbumIdChanged();
		    }
		}
		
		int _MediaTypeId;
		public int MediaTypeId { 
		    get{
		        return _MediaTypeId;
		    } 
		    set{
		        this.OnMediaTypeIdChanging(value);
                this.SendPropertyChanging();
                this._MediaTypeId = value;
                this.SendPropertyChanged("MediaTypeId");
                this.OnMediaTypeIdChanged();
		    }
		}
		
		int _GenreId;
		public int GenreId { 
		    get{
		        return _GenreId;
		    } 
		    set{
		        this.OnGenreIdChanging(value);
                this.SendPropertyChanging();
                this._GenreId = value;
                this.SendPropertyChanged("GenreId");
                this.OnGenreIdChanged();
		    }
		}
		
		string _Composer;
		public string Composer { 
		    get{
		        return _Composer;
		    } 
		    set{
		        this.OnComposerChanging(value);
                this.SendPropertyChanging();
                this._Composer = value;
                this.SendPropertyChanged("Composer");
                this.OnComposerChanged();
		    }
		}
		
		int _Milliseconds;
		public int Milliseconds { 
		    get{
		        return _Milliseconds;
		    } 
		    set{
		        this.OnMillisecondsChanging(value);
                this.SendPropertyChanging();
                this._Milliseconds = value;
                this.SendPropertyChanged("Milliseconds");
                this.OnMillisecondsChanged();
		    }
		}
		
		int _Bytes;
		public int Bytes { 
		    get{
		        return _Bytes;
		    } 
		    set{
		        this.OnBytesChanging(value);
                this.SendPropertyChanging();
                this._Bytes = value;
                this.SendPropertyChanged("Bytes");
                this.OnBytesChanged();
		    }
		}
		
		decimal _UnitPrice;
		public decimal UnitPrice { 
		    get{
		        return _UnitPrice;
		    } 
		    set{
		        this.OnUnitPriceChanging(value);
                this.SendPropertyChanging();
                this._UnitPrice = value;
                this.SendPropertyChanged("UnitPrice");
                this.OnUnitPriceChanged();
		    }
		}
		


        #region Extensibility Hooks
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnTrackIdChanging(int value);
        partial void OnTrackIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnAlbumIdChanging(int value);
        partial void OnAlbumIdChanged();
        partial void OnMediaTypeIdChanging(int value);
        partial void OnMediaTypeIdChanged();
        partial void OnGenreIdChanging(int value);
        partial void OnGenreIdChanged();
        partial void OnComposerChanging(string value);
        partial void OnComposerChanged();
        partial void OnMillisecondsChanging(int value);
        partial void OnMillisecondsChanged();
        partial void OnBytesChanging(int value);
        partial void OnBytesChanged();
        partial void OnUnitPriceChanging(decimal value);
        partial void OnUnitPriceChanged();
       
        #endregion


        #region Foriegn Keys
      
        public IQueryable<InvoiceLine> InvoiceLines {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.InvoiceLines
                       where items.TrackId == _TrackId
                       select items;
            }
        }

      
        public IQueryable<Album> Albums {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.Albums
                       where items.AlbumId == _AlbumId
                       select items;
            }
        }

      
        public IQueryable<Genre> Genres {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.Genres
                       where items.GenreId == _GenreId
                       select items;
            }
        }

      
        public IQueryable<MediaType> MediaTypes {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.MediaTypes
                       where items.MediaTypeId == _MediaTypeId
                       select items;
            }
        }

        
        #endregion

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging() {
            if ((this.PropertyChanging != null)) {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName) {
            if ((this.PropertyChanged != null)) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
	}

    /// <summary>
    /// A class which represents the Customer table in the Chinook Database.
    /// This class is queryable through Chinook.DB.Customer
    /// </summary>
	public partial class Customer: INotifyPropertyChanging, INotifyPropertyChanged {
	    public Customer(){
	        OnCreated();
	    }
	
        public string KeyName (){
            return "CustomerId";
        }
        public int KeyValue (){
            return _CustomerId;
        }
		int _CustomerId;
		public int CustomerId { 
		    get{
		        return _CustomerId;
		    } 
		    set{
		        this.OnCustomerIdChanging(value);
                this.SendPropertyChanging();
                this._CustomerId = value;
                this.SendPropertyChanged("CustomerId");
                this.OnCustomerIdChanged();
		    }
		}
		
        public string DescriptorValue(){
            return this.FirstName;
        }
        public string DescriptorColumn() {
            return "FirstName";
        }
        public override string ToString(){
            return this.FirstName;
        }
        public static string GetDescriptorColumn() {
            return "FirstName";
        }
		string _FirstName;
		public string FirstName { 
		    get{
		        return _FirstName;
		    } 
		    set{
		        this.OnFirstNameChanging(value);
                this.SendPropertyChanging();
                this._FirstName = value;
                this.SendPropertyChanged("FirstName");
                this.OnFirstNameChanged();
		    }
		}
		
		string _LastName;
		public string LastName { 
		    get{
		        return _LastName;
		    } 
		    set{
		        this.OnLastNameChanging(value);
                this.SendPropertyChanging();
                this._LastName = value;
                this.SendPropertyChanged("LastName");
                this.OnLastNameChanged();
		    }
		}
		
		string _Company;
		public string Company { 
		    get{
		        return _Company;
		    } 
		    set{
		        this.OnCompanyChanging(value);
                this.SendPropertyChanging();
                this._Company = value;
                this.SendPropertyChanged("Company");
                this.OnCompanyChanged();
		    }
		}
		
		string _Address;
		public string Address { 
		    get{
		        return _Address;
		    } 
		    set{
		        this.OnAddressChanging(value);
                this.SendPropertyChanging();
                this._Address = value;
                this.SendPropertyChanged("Address");
                this.OnAddressChanged();
		    }
		}
		
		string _City;
		public string City { 
		    get{
		        return _City;
		    } 
		    set{
		        this.OnCityChanging(value);
                this.SendPropertyChanging();
                this._City = value;
                this.SendPropertyChanged("City");
                this.OnCityChanged();
		    }
		}
		
		string _State;
		public string State { 
		    get{
		        return _State;
		    } 
		    set{
		        this.OnStateChanging(value);
                this.SendPropertyChanging();
                this._State = value;
                this.SendPropertyChanged("State");
                this.OnStateChanged();
		    }
		}
		
		string _Country;
		public string Country { 
		    get{
		        return _Country;
		    } 
		    set{
		        this.OnCountryChanging(value);
                this.SendPropertyChanging();
                this._Country = value;
                this.SendPropertyChanged("Country");
                this.OnCountryChanged();
		    }
		}
		
		string _PostalCode;
		public string PostalCode { 
		    get{
		        return _PostalCode;
		    } 
		    set{
		        this.OnPostalCodeChanging(value);
                this.SendPropertyChanging();
                this._PostalCode = value;
                this.SendPropertyChanged("PostalCode");
                this.OnPostalCodeChanged();
		    }
		}
		
		string _Phone;
		public string Phone { 
		    get{
		        return _Phone;
		    } 
		    set{
		        this.OnPhoneChanging(value);
                this.SendPropertyChanging();
                this._Phone = value;
                this.SendPropertyChanged("Phone");
                this.OnPhoneChanged();
		    }
		}
		
		string _Fax;
		public string Fax { 
		    get{
		        return _Fax;
		    } 
		    set{
		        this.OnFaxChanging(value);
                this.SendPropertyChanging();
                this._Fax = value;
                this.SendPropertyChanged("Fax");
                this.OnFaxChanged();
		    }
		}
		
		string _Email;
		public string Email { 
		    get{
		        return _Email;
		    } 
		    set{
		        this.OnEmailChanging(value);
                this.SendPropertyChanging();
                this._Email = value;
                this.SendPropertyChanged("Email");
                this.OnEmailChanged();
		    }
		}
		


        #region Extensibility Hooks
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnCustomerIdChanging(int value);
        partial void OnCustomerIdChanged();
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
        partial void OnCompanyChanging(string value);
        partial void OnCompanyChanged();
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
        partial void OnCityChanging(string value);
        partial void OnCityChanged();
        partial void OnStateChanging(string value);
        partial void OnStateChanged();
        partial void OnCountryChanging(string value);
        partial void OnCountryChanged();
        partial void OnPostalCodeChanging(string value);
        partial void OnPostalCodeChanged();
        partial void OnPhoneChanging(string value);
        partial void OnPhoneChanged();
        partial void OnFaxChanging(string value);
        partial void OnFaxChanged();
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
       
        #endregion


        #region Foriegn Keys
      
        public IQueryable<Invoice> Invoices {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.Invoices
                       where items.CustomerId == _CustomerId
                       select items;
            }
        }

        
        #endregion

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging() {
            if ((this.PropertyChanging != null)) {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName) {
            if ((this.PropertyChanged != null)) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
	}

    /// <summary>
    /// A class which represents the Employee table in the Chinook Database.
    /// This class is queryable through Chinook.DB.Employee
    /// </summary>
	public partial class Employee: INotifyPropertyChanging, INotifyPropertyChanged {
	    public Employee(){
	        OnCreated();
	    }
	
        public string KeyName (){
            return "EmployeeId";
        }
        public int KeyValue (){
            return _EmployeeId;
        }
		int _EmployeeId;
		public int EmployeeId { 
		    get{
		        return _EmployeeId;
		    } 
		    set{
		        this.OnEmployeeIdChanging(value);
                this.SendPropertyChanging();
                this._EmployeeId = value;
                this.SendPropertyChanged("EmployeeId");
                this.OnEmployeeIdChanged();
		    }
		}
		
        public string DescriptorValue(){
            return this.LastName;
        }
        public string DescriptorColumn() {
            return "LastName";
        }
        public override string ToString(){
            return this.LastName;
        }
        public static string GetDescriptorColumn() {
            return "LastName";
        }
		string _LastName;
		public string LastName { 
		    get{
		        return _LastName;
		    } 
		    set{
		        this.OnLastNameChanging(value);
                this.SendPropertyChanging();
                this._LastName = value;
                this.SendPropertyChanged("LastName");
                this.OnLastNameChanged();
		    }
		}
		
		string _FirstName;
		public string FirstName { 
		    get{
		        return _FirstName;
		    } 
		    set{
		        this.OnFirstNameChanging(value);
                this.SendPropertyChanging();
                this._FirstName = value;
                this.SendPropertyChanged("FirstName");
                this.OnFirstNameChanged();
		    }
		}
		
		string _Title;
		public string Title { 
		    get{
		        return _Title;
		    } 
		    set{
		        this.OnTitleChanging(value);
                this.SendPropertyChanging();
                this._Title = value;
                this.SendPropertyChanged("Title");
                this.OnTitleChanged();
		    }
		}
		
		int _ReportsTo;
		public int ReportsTo { 
		    get{
		        return _ReportsTo;
		    } 
		    set{
		        this.OnReportsToChanging(value);
                this.SendPropertyChanging();
                this._ReportsTo = value;
                this.SendPropertyChanged("ReportsTo");
                this.OnReportsToChanged();
		    }
		}
		
		DateTime _BirthDate;
		public DateTime BirthDate { 
		    get{
		        return _BirthDate;
		    } 
		    set{
		        this.OnBirthDateChanging(value);
                this.SendPropertyChanging();
                this._BirthDate = value;
                this.SendPropertyChanged("BirthDate");
                this.OnBirthDateChanged();
		    }
		}
		
		DateTime _HireDate;
		public DateTime HireDate { 
		    get{
		        return _HireDate;
		    } 
		    set{
		        this.OnHireDateChanging(value);
                this.SendPropertyChanging();
                this._HireDate = value;
                this.SendPropertyChanged("HireDate");
                this.OnHireDateChanged();
		    }
		}
		
		string _Address;
		public string Address { 
		    get{
		        return _Address;
		    } 
		    set{
		        this.OnAddressChanging(value);
                this.SendPropertyChanging();
                this._Address = value;
                this.SendPropertyChanged("Address");
                this.OnAddressChanged();
		    }
		}
		
		string _City;
		public string City { 
		    get{
		        return _City;
		    } 
		    set{
		        this.OnCityChanging(value);
                this.SendPropertyChanging();
                this._City = value;
                this.SendPropertyChanged("City");
                this.OnCityChanged();
		    }
		}
		
		string _State;
		public string State { 
		    get{
		        return _State;
		    } 
		    set{
		        this.OnStateChanging(value);
                this.SendPropertyChanging();
                this._State = value;
                this.SendPropertyChanged("State");
                this.OnStateChanged();
		    }
		}
		
		string _Country;
		public string Country { 
		    get{
		        return _Country;
		    } 
		    set{
		        this.OnCountryChanging(value);
                this.SendPropertyChanging();
                this._Country = value;
                this.SendPropertyChanged("Country");
                this.OnCountryChanged();
		    }
		}
		
		string _PostalCode;
		public string PostalCode { 
		    get{
		        return _PostalCode;
		    } 
		    set{
		        this.OnPostalCodeChanging(value);
                this.SendPropertyChanging();
                this._PostalCode = value;
                this.SendPropertyChanged("PostalCode");
                this.OnPostalCodeChanged();
		    }
		}
		
		string _Phone;
		public string Phone { 
		    get{
		        return _Phone;
		    } 
		    set{
		        this.OnPhoneChanging(value);
                this.SendPropertyChanging();
                this._Phone = value;
                this.SendPropertyChanged("Phone");
                this.OnPhoneChanged();
		    }
		}
		
		string _Fax;
		public string Fax { 
		    get{
		        return _Fax;
		    } 
		    set{
		        this.OnFaxChanging(value);
                this.SendPropertyChanging();
                this._Fax = value;
                this.SendPropertyChanged("Fax");
                this.OnFaxChanged();
		    }
		}
		
		string _Email;
		public string Email { 
		    get{
		        return _Email;
		    } 
		    set{
		        this.OnEmailChanging(value);
                this.SendPropertyChanging();
                this._Email = value;
                this.SendPropertyChanged("Email");
                this.OnEmailChanged();
		    }
		}
		


        #region Extensibility Hooks
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnEmployeeIdChanging(int value);
        partial void OnEmployeeIdChanged();
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
        partial void OnTitleChanging(string value);
        partial void OnTitleChanged();
        partial void OnReportsToChanging(int value);
        partial void OnReportsToChanged();
        partial void OnBirthDateChanging(DateTime value);
        partial void OnBirthDateChanged();
        partial void OnHireDateChanging(DateTime value);
        partial void OnHireDateChanged();
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
        partial void OnCityChanging(string value);
        partial void OnCityChanged();
        partial void OnStateChanging(string value);
        partial void OnStateChanged();
        partial void OnCountryChanging(string value);
        partial void OnCountryChanged();
        partial void OnPostalCodeChanging(string value);
        partial void OnPostalCodeChanged();
        partial void OnPhoneChanging(string value);
        partial void OnPhoneChanged();
        partial void OnFaxChanging(string value);
        partial void OnFaxChanged();
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
       
        #endregion


        #region Foriegn Keys
      
        public IQueryable<Employee> Employees {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.Employees
                       where items.EmployeeId == _ReportsTo
                       select items;
            }
        }

      
        public IQueryable<Invoice> Invoices {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.Invoices
                       where items.EmployeeId == _EmployeeId
                       select items;
            }
        }

        
        #endregion

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging() {
            if ((this.PropertyChanging != null)) {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName) {
            if ((this.PropertyChanged != null)) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
	}

    /// <summary>
    /// A class which represents the Invoice table in the Chinook Database.
    /// This class is queryable through Chinook.DB.Invoice
    /// </summary>
	public partial class Invoice: INotifyPropertyChanging, INotifyPropertyChanged {
	    public Invoice(){
	        OnCreated();
	    }
	
        public string KeyName (){
            return "InvoiceId";
        }
        public int KeyValue (){
            return _InvoiceId;
        }
		int _InvoiceId;
		public int InvoiceId { 
		    get{
		        return _InvoiceId;
		    } 
		    set{
		        this.OnInvoiceIdChanging(value);
                this.SendPropertyChanging();
                this._InvoiceId = value;
                this.SendPropertyChanged("InvoiceId");
                this.OnInvoiceIdChanged();
		    }
		}
		
		int _CustomerId;
		public int CustomerId { 
		    get{
		        return _CustomerId;
		    } 
		    set{
		        this.OnCustomerIdChanging(value);
                this.SendPropertyChanging();
                this._CustomerId = value;
                this.SendPropertyChanged("CustomerId");
                this.OnCustomerIdChanged();
		    }
		}
		
		int _EmployeeId;
		public int EmployeeId { 
		    get{
		        return _EmployeeId;
		    } 
		    set{
		        this.OnEmployeeIdChanging(value);
                this.SendPropertyChanging();
                this._EmployeeId = value;
                this.SendPropertyChanged("EmployeeId");
                this.OnEmployeeIdChanged();
		    }
		}
		
		DateTime _InvoiceDate;
		public DateTime InvoiceDate { 
		    get{
		        return _InvoiceDate;
		    } 
		    set{
		        this.OnInvoiceDateChanging(value);
                this.SendPropertyChanging();
                this._InvoiceDate = value;
                this.SendPropertyChanged("InvoiceDate");
                this.OnInvoiceDateChanged();
		    }
		}
		
        public string DescriptorValue(){
            return this.BillingAddress;
        }
        public string DescriptorColumn() {
            return "BillingAddress";
        }
        public override string ToString(){
            return this.BillingAddress;
        }
        public static string GetDescriptorColumn() {
            return "BillingAddress";
        }
		string _BillingAddress;
		public string BillingAddress { 
		    get{
		        return _BillingAddress;
		    } 
		    set{
		        this.OnBillingAddressChanging(value);
                this.SendPropertyChanging();
                this._BillingAddress = value;
                this.SendPropertyChanged("BillingAddress");
                this.OnBillingAddressChanged();
		    }
		}
		
		string _BillingCity;
		public string BillingCity { 
		    get{
		        return _BillingCity;
		    } 
		    set{
		        this.OnBillingCityChanging(value);
                this.SendPropertyChanging();
                this._BillingCity = value;
                this.SendPropertyChanged("BillingCity");
                this.OnBillingCityChanged();
		    }
		}
		
		string _BillingState;
		public string BillingState { 
		    get{
		        return _BillingState;
		    } 
		    set{
		        this.OnBillingStateChanging(value);
                this.SendPropertyChanging();
                this._BillingState = value;
                this.SendPropertyChanged("BillingState");
                this.OnBillingStateChanged();
		    }
		}
		
		string _BillingCountry;
		public string BillingCountry { 
		    get{
		        return _BillingCountry;
		    } 
		    set{
		        this.OnBillingCountryChanging(value);
                this.SendPropertyChanging();
                this._BillingCountry = value;
                this.SendPropertyChanged("BillingCountry");
                this.OnBillingCountryChanged();
		    }
		}
		
		string _BillingPostalCode;
		public string BillingPostalCode { 
		    get{
		        return _BillingPostalCode;
		    } 
		    set{
		        this.OnBillingPostalCodeChanging(value);
                this.SendPropertyChanging();
                this._BillingPostalCode = value;
                this.SendPropertyChanged("BillingPostalCode");
                this.OnBillingPostalCodeChanged();
		    }
		}
		


        #region Extensibility Hooks
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnInvoiceIdChanging(int value);
        partial void OnInvoiceIdChanged();
        partial void OnCustomerIdChanging(int value);
        partial void OnCustomerIdChanged();
        partial void OnEmployeeIdChanging(int value);
        partial void OnEmployeeIdChanged();
        partial void OnInvoiceDateChanging(DateTime value);
        partial void OnInvoiceDateChanged();
        partial void OnBillingAddressChanging(string value);
        partial void OnBillingAddressChanged();
        partial void OnBillingCityChanging(string value);
        partial void OnBillingCityChanged();
        partial void OnBillingStateChanging(string value);
        partial void OnBillingStateChanged();
        partial void OnBillingCountryChanging(string value);
        partial void OnBillingCountryChanged();
        partial void OnBillingPostalCodeChanging(string value);
        partial void OnBillingPostalCodeChanged();
       
        #endregion


        #region Foriegn Keys
      
        public IQueryable<Customer> Customers {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.Customers
                       where items.CustomerId == _CustomerId
                       select items;
            }
        }

      
        public IQueryable<Employee> Employees {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.Employees
                       where items.EmployeeId == _EmployeeId
                       select items;
            }
        }

      
        public IQueryable<InvoiceLine> InvoiceLines {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.InvoiceLines
                       where items.InvoiceId == _InvoiceId
                       select items;
            }
        }

        
        #endregion

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging() {
            if ((this.PropertyChanging != null)) {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName) {
            if ((this.PropertyChanged != null)) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
	}

    /// <summary>
    /// A class which represents the InvoiceLine table in the Chinook Database.
    /// This class is queryable through Chinook.DB.InvoiceLine
    /// </summary>
	public partial class InvoiceLine: INotifyPropertyChanging, INotifyPropertyChanged {
	    public InvoiceLine(){
	        OnCreated();
	    }
	
        public string KeyName (){
            return "InvoiceLineId";
        }
        public int KeyValue (){
            return _InvoiceLineId;
        }
		int _InvoiceLineId;
		public int InvoiceLineId { 
		    get{
		        return _InvoiceLineId;
		    } 
		    set{
		        this.OnInvoiceLineIdChanging(value);
                this.SendPropertyChanging();
                this._InvoiceLineId = value;
                this.SendPropertyChanged("InvoiceLineId");
                this.OnInvoiceLineIdChanged();
		    }
		}
		
		int _InvoiceId;
		public int InvoiceId { 
		    get{
		        return _InvoiceId;
		    } 
		    set{
		        this.OnInvoiceIdChanging(value);
                this.SendPropertyChanging();
                this._InvoiceId = value;
                this.SendPropertyChanged("InvoiceId");
                this.OnInvoiceIdChanged();
		    }
		}
		
		int _TrackId;
		public int TrackId { 
		    get{
		        return _TrackId;
		    } 
		    set{
		        this.OnTrackIdChanging(value);
                this.SendPropertyChanging();
                this._TrackId = value;
                this.SendPropertyChanged("TrackId");
                this.OnTrackIdChanged();
		    }
		}
		
		decimal _UnitPrice;
		public decimal UnitPrice { 
		    get{
		        return _UnitPrice;
		    } 
		    set{
		        this.OnUnitPriceChanging(value);
                this.SendPropertyChanging();
                this._UnitPrice = value;
                this.SendPropertyChanged("UnitPrice");
                this.OnUnitPriceChanged();
		    }
		}
		
		decimal _Quantity;
		public decimal Quantity { 
		    get{
		        return _Quantity;
		    } 
		    set{
		        this.OnQuantityChanging(value);
                this.SendPropertyChanging();
                this._Quantity = value;
                this.SendPropertyChanged("Quantity");
                this.OnQuantityChanged();
		    }
		}
		


        #region Extensibility Hooks
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnInvoiceLineIdChanging(int value);
        partial void OnInvoiceLineIdChanged();
        partial void OnInvoiceIdChanging(int value);
        partial void OnInvoiceIdChanged();
        partial void OnTrackIdChanging(int value);
        partial void OnTrackIdChanged();
        partial void OnUnitPriceChanging(decimal value);
        partial void OnUnitPriceChanged();
        partial void OnQuantityChanging(decimal value);
        partial void OnQuantityChanged();
       
        #endregion


        #region Foriegn Keys
      
        public IQueryable<Invoice> Invoices {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.Invoices
                       where items.InvoiceId == _InvoiceId
                       select items;
            }
        }

      
        public IQueryable<Track> Tracks {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.Tracks
                       where items.TrackId == _TrackId
                       select items;
            }
        }

        
        #endregion

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging() {
            if ((this.PropertyChanging != null)) {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName) {
            if ((this.PropertyChanged != null)) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
	}

    /// <summary>
    /// A class which represents the Genre table in the Chinook Database.
    /// This class is queryable through Chinook.DB.Genre
    /// </summary>
	public partial class Genre: INotifyPropertyChanging, INotifyPropertyChanged {
	    public Genre(){
	        OnCreated();
	    }
	
        public string KeyName (){
            return "GenreId";
        }
        public int KeyValue (){
            return _GenreId;
        }
		int _GenreId;
		public int GenreId { 
		    get{
		        return _GenreId;
		    } 
		    set{
		        this.OnGenreIdChanging(value);
                this.SendPropertyChanging();
                this._GenreId = value;
                this.SendPropertyChanged("GenreId");
                this.OnGenreIdChanged();
		    }
		}
		
        public string DescriptorValue(){
            return this.Name;
        }
        public string DescriptorColumn() {
            return "Name";
        }
        public override string ToString(){
            return this.Name;
        }
        public static string GetDescriptorColumn() {
            return "Name";
        }
		string _Name;
		public string Name { 
		    get{
		        return _Name;
		    } 
		    set{
		        this.OnNameChanging(value);
                this.SendPropertyChanging();
                this._Name = value;
                this.SendPropertyChanged("Name");
                this.OnNameChanged();
		    }
		}
		


        #region Extensibility Hooks
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnGenreIdChanging(int value);
        partial void OnGenreIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
       
        #endregion


        #region Foriegn Keys
      
        public IQueryable<Track> Tracks {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.Tracks
                       where items.GenreId == _GenreId
                       select items;
            }
        }

        
        #endregion

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging() {
            if ((this.PropertyChanging != null)) {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName) {
            if ((this.PropertyChanged != null)) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
	}

    /// <summary>
    /// A class which represents the MediaType table in the Chinook Database.
    /// This class is queryable through Chinook.DB.MediaType
    /// </summary>
	public partial class MediaType: INotifyPropertyChanging, INotifyPropertyChanged {
	    public MediaType(){
	        OnCreated();
	    }
	
        public string KeyName (){
            return "MediaTypeId";
        }
        public int KeyValue (){
            return _MediaTypeId;
        }
		int _MediaTypeId;
		public int MediaTypeId { 
		    get{
		        return _MediaTypeId;
		    } 
		    set{
		        this.OnMediaTypeIdChanging(value);
                this.SendPropertyChanging();
                this._MediaTypeId = value;
                this.SendPropertyChanged("MediaTypeId");
                this.OnMediaTypeIdChanged();
		    }
		}
		
        public string DescriptorValue(){
            return this.Name;
        }
        public string DescriptorColumn() {
            return "Name";
        }
        public override string ToString(){
            return this.Name;
        }
        public static string GetDescriptorColumn() {
            return "Name";
        }
		string _Name;
		public string Name { 
		    get{
		        return _Name;
		    } 
		    set{
		        this.OnNameChanging(value);
                this.SendPropertyChanging();
                this._Name = value;
                this.SendPropertyChanged("Name");
                this.OnNameChanged();
		    }
		}
		


        #region Extensibility Hooks
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnMediaTypeIdChanging(int value);
        partial void OnMediaTypeIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
       
        #endregion


        #region Foriegn Keys
      
        public IQueryable<Track> Tracks {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.Tracks
                       where items.MediaTypeId == _MediaTypeId
                       select items;
            }
        }

        
        #endregion

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging() {
            if ((this.PropertyChanging != null)) {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName) {
            if ((this.PropertyChanged != null)) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
	}

    /// <summary>
    /// A class which represents the Artist table in the Chinook Database.
    /// This class is queryable through Chinook.DB.Artist
    /// </summary>
	public partial class Artist: INotifyPropertyChanging, INotifyPropertyChanged {
	    public Artist(){
	        OnCreated();
	    }
	
        public string KeyName (){
            return "ArtistId";
        }
        public int KeyValue (){
            return _ArtistId;
        }
		int _ArtistId;
		public int ArtistId { 
		    get{
		        return _ArtistId;
		    } 
		    set{
		        this.OnArtistIdChanging(value);
                this.SendPropertyChanging();
                this._ArtistId = value;
                this.SendPropertyChanged("ArtistId");
                this.OnArtistIdChanged();
		    }
		}
		
        public string DescriptorValue(){
            return this.Name;
        }
        public string DescriptorColumn() {
            return "Name";
        }
        public override string ToString(){
            return this.Name;
        }
        public static string GetDescriptorColumn() {
            return "Name";
        }
		string _Name;
		public string Name { 
		    get{
		        return _Name;
		    } 
		    set{
		        this.OnNameChanging(value);
                this.SendPropertyChanging();
                this._Name = value;
                this.SendPropertyChanged("Name");
                this.OnNameChanged();
		    }
		}
		


        #region Extensibility Hooks
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnArtistIdChanging(int value);
        partial void OnArtistIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
       
        #endregion


        #region Foriegn Keys
      
        public IQueryable<Album> Albums {
            get{
                
                Subsonic.Web.Models.DB _db =DB.CreateDB();
                return from items in _db.Albums
                       where items.ArtistId == _ArtistId
                       select items;
            }
        }

        
        #endregion

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanging() {
            if ((this.PropertyChanging != null)) {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName) {
            if ((this.PropertyChanged != null)) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
	}

}
