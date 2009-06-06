﻿

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SubSonic.DataProviders;
using SubSonic.Linq;
using SubSonic;
using SubSonic.Schema;
using System.Data;
using SubSonic.Extensions;
using SubSonic.Query;
using SubSonic.Linq.Structure;
using System.Linq.Expressions;

namespace Subsonic.Web.Models{
	public partial class DB:IQuerySurface{

        private DB() { }
        static DB _db;
        public static DB CreateDB() {
            if (_db == null) {
                _db = new DB();
                _db.Init();
            }
            return _db;
        }
	
	    public static void CloseDB(){
	        _db=null;
	    }
        public IDataProvider DataProvider = ProviderFactory.GetProvider("Chinook");
        public  DbQueryProvider provider;

        public ITable FindByPrimaryKey(string pkName){
            return DataProvider.Tables.SingleOrDefault(x => x.PrimaryKey.Name.Equals(pkName, StringComparison.InvariantCultureIgnoreCase));
        }

        public Query<T> GetQuery<T>() {
            return new Query<T>(provider);
        }
        public ITable FindTable(string tableName) {
            return DataProvider.FindTable(tableName);
        }
        
        public ITable FindTableByClassName(string tableName) {
            return DataProvider.FindTableByClassName(tableName);
        }
        
        public IDataProvider Provider {
            get {
                return DataProvider;
            }
        }
        public DbQueryProvider QueryProvider {
            get {
                return provider;
            }
        }
        BatchQuery _batch=null;
        public void Queue<T>(IQueryable<T> qry){
            if(_batch==null)
                _batch=new BatchQuery(Provider,QueryProvider);
            _batch.Queue(qry);
        }
        
        public void Queue(ISqlQuery qry){
            if(_batch==null)
                _batch=new BatchQuery(Provider,QueryProvider);
            _batch.Queue(qry);
        }     
        
        public IDataReader ExecuteBatch(){
            if(_batch==null)
                throw new InvalidOperationException("There's nothing in the queue");
            else
                return _batch.ExecuteReader();
        }
			
		public Query<Album> Albums{ get; set; }
		public Query<Track> Tracks{ get; set; }
		public Query<Customer> Customers{ get; set; }
		public Query<Employee> Employees{ get; set; }
		public Query<Invoice> Invoices{ get; set; }
		public Query<InvoiceLine> InvoiceLines{ get; set; }
		public Query<Genre> Genres{ get; set; }
		public Query<MediaType> MediaTypes{ get; set; }
		public Query<Artist> Artists{ get; set; }

			
	
		#region Aggregates and SubSonic Queries
	    public Select SelectColumns(params string[] columns){
	        return new Select(DataProvider, columns);
	    }
	    public Select Select {
			get{
				return new Select(DataProvider);
            }
        }
	    public Insert Insert {
			get{
				return new Insert(DataProvider);
            }
        }        
        public Update<T> Update<T>() where T:new(){
            return new Update<T>(DataProvider);
        }
        public SqlQuery Delete<T>(Expression<Func<T,bool>> column) where T:new(){
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            SqlQuery result = new Delete<T>(DataProvider);
            result = result.From<T>();
            SubSonic.Query.Constraint c = lamda.ParseConstraint();
            result.Constraints.Add(c);
            return result;
        }
        public SqlQuery Max<T>(Expression<Func<T,object>> column){
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            string colName = lamda.ParseObjectValue();
            string objectName=typeof(T).Name;
            string tableName = this.DataProvider.FindTableByClassName(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Max)).From(tableName);
        }
        public SqlQuery Min<T>(Expression<Func<T,object>> column){
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            string colName = lamda.ParseObjectValue();
            string objectName=typeof(T).Name;
            string tableName = this.DataProvider.FindTableByClassName(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Min)).From(tableName);
        }
        public SqlQuery Sum<T>(Expression<Func<T,object>> column){
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            string colName = lamda.ParseObjectValue();
            string objectName=typeof(T).Name;
            string tableName = this.DataProvider.FindTableByClassName(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Sum)).From(tableName);
        }
        public SqlQuery Avg<T>(Expression<Func<T,object>> column){
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            string colName = lamda.ParseObjectValue();
            string objectName=typeof(T).Name;
            string tableName = this.DataProvider.FindTableByClassName(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Avg)).From(tableName);
        }
        public SqlQuery Count<T>(Expression<Func<T,object>> column){
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            string colName = lamda.ParseObjectValue();
            string objectName=typeof(T).Name;
            string tableName = this.DataProvider.FindTableByClassName(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Count)).From(tableName);
        }
        public SqlQuery Variance<T>(Expression<Func<T,object>> column){
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            string colName = lamda.ParseObjectValue();
            string objectName=typeof(T).Name;
            string tableName = this.DataProvider.FindTableByClassName(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.Var)).From(tableName);
        }
        public SqlQuery StandardDeviation<T>(Expression<Func<T,object>> column){
            System.Linq.Expressions.LambdaExpression lamda = column as System.Linq.Expressions.LambdaExpression;
            string colName = lamda.ParseObjectValue();
            string objectName=typeof(T).Name;
            string tableName = this.DataProvider.FindTableByClassName(objectName).Name;
            return new Select(DataProvider, new Aggregate(colName, AggregateFunction.StDev)).From(tableName);
        }
        
        #endregion

		void Init(){
			this.provider = new DbQueryProvider(DataProvider);
			
			#region Query Defs
			this.Albums =new Query<Album>(this.provider);
			this.Tracks =new Query<Track>(this.provider);
			this.Customers =new Query<Customer>(this.provider);
			this.Employees =new Query<Employee>(this.provider);
			this.Invoices =new Query<Invoice>(this.provider);
			this.InvoiceLines =new Query<InvoiceLine>(this.provider);
			this.Genres =new Query<Genre>(this.provider);
			this.MediaTypes =new Query<MediaType>(this.provider);
			this.Artists =new Query<Artist>(this.provider);
			
			#endregion
			
			

			#region Schemas
			
			//********************Album********************
			//PK=AlbumId
			ITable AlbumSchema=new DatabaseTable("Album",DataProvider);
			AlbumSchema.ClassName="Album";
			
			IColumn AlbumAlbumId=new DatabaseColumn("AlbumId",AlbumSchema);
			AlbumAlbumId.IsPrimaryKey=true;
			AlbumAlbumId.DataType=DbType.Int32;
			AlbumAlbumId.IsNullable=false;
			AlbumAlbumId.AutoIncrement=true;
			AlbumAlbumId.IsForeignKey=true;
			AlbumSchema.Columns.Add(AlbumAlbumId);		
			
			IColumn AlbumTitle=new DatabaseColumn("Title",AlbumSchema);
			AlbumTitle.DataType=DbType.String;
			AlbumTitle.IsNullable=false;
			AlbumTitle.AutoIncrement=false;
			AlbumTitle.IsForeignKey=false;
			AlbumSchema.Columns.Add(AlbumTitle);		
			
			IColumn AlbumArtistId=new DatabaseColumn("ArtistId",AlbumSchema);
			AlbumArtistId.DataType=DbType.Int32;
			AlbumArtistId.IsNullable=false;
			AlbumArtistId.AutoIncrement=false;
			AlbumArtistId.IsForeignKey=true;
			AlbumSchema.Columns.Add(AlbumArtistId);		
			DataProvider.Tables.Add(AlbumSchema);
			
			//********************Track********************
			//PK=TrackId
			ITable TrackSchema=new DatabaseTable("Track",DataProvider);
			TrackSchema.ClassName="Track";
			
			IColumn TrackTrackId=new DatabaseColumn("TrackId",TrackSchema);
			TrackTrackId.IsPrimaryKey=true;
			TrackTrackId.DataType=DbType.Int32;
			TrackTrackId.IsNullable=false;
			TrackTrackId.AutoIncrement=true;
			TrackTrackId.IsForeignKey=true;
			TrackSchema.Columns.Add(TrackTrackId);		
			
			IColumn TrackName=new DatabaseColumn("Name",TrackSchema);
			TrackName.DataType=DbType.String;
			TrackName.IsNullable=false;
			TrackName.AutoIncrement=false;
			TrackName.IsForeignKey=false;
			TrackSchema.Columns.Add(TrackName);		
			
			IColumn TrackAlbumId=new DatabaseColumn("AlbumId",TrackSchema);
			TrackAlbumId.DataType=DbType.Int32;
			TrackAlbumId.IsNullable=true;
			TrackAlbumId.AutoIncrement=false;
			TrackAlbumId.IsForeignKey=true;
			TrackSchema.Columns.Add(TrackAlbumId);		
			
			IColumn TrackMediaTypeId=new DatabaseColumn("MediaTypeId",TrackSchema);
			TrackMediaTypeId.DataType=DbType.Int32;
			TrackMediaTypeId.IsNullable=false;
			TrackMediaTypeId.AutoIncrement=false;
			TrackMediaTypeId.IsForeignKey=true;
			TrackSchema.Columns.Add(TrackMediaTypeId);		
			
			IColumn TrackGenreId=new DatabaseColumn("GenreId",TrackSchema);
			TrackGenreId.DataType=DbType.Int32;
			TrackGenreId.IsNullable=true;
			TrackGenreId.AutoIncrement=false;
			TrackGenreId.IsForeignKey=true;
			TrackSchema.Columns.Add(TrackGenreId);		
			
			IColumn TrackComposer=new DatabaseColumn("Composer",TrackSchema);
			TrackComposer.DataType=DbType.String;
			TrackComposer.IsNullable=true;
			TrackComposer.AutoIncrement=false;
			TrackComposer.IsForeignKey=false;
			TrackSchema.Columns.Add(TrackComposer);		
			
			IColumn TrackMilliseconds=new DatabaseColumn("Milliseconds",TrackSchema);
			TrackMilliseconds.DataType=DbType.Int32;
			TrackMilliseconds.IsNullable=false;
			TrackMilliseconds.AutoIncrement=false;
			TrackMilliseconds.IsForeignKey=false;
			TrackSchema.Columns.Add(TrackMilliseconds);		
			
			IColumn TrackBytes=new DatabaseColumn("Bytes",TrackSchema);
			TrackBytes.DataType=DbType.Int32;
			TrackBytes.IsNullable=true;
			TrackBytes.AutoIncrement=false;
			TrackBytes.IsForeignKey=false;
			TrackSchema.Columns.Add(TrackBytes);		
			
			IColumn TrackUnitPrice=new DatabaseColumn("UnitPrice",TrackSchema);
			TrackUnitPrice.DataType=DbType.Decimal;
			TrackUnitPrice.IsNullable=false;
			TrackUnitPrice.AutoIncrement=false;
			TrackUnitPrice.IsForeignKey=false;
			TrackSchema.Columns.Add(TrackUnitPrice);		
			DataProvider.Tables.Add(TrackSchema);
			
			//********************Customer********************
			//PK=CustomerId
			ITable CustomerSchema=new DatabaseTable("Customer",DataProvider);
			CustomerSchema.ClassName="Customer";
			
			IColumn CustomerCustomerId=new DatabaseColumn("CustomerId",CustomerSchema);
			CustomerCustomerId.IsPrimaryKey=true;
			CustomerCustomerId.DataType=DbType.Int32;
			CustomerCustomerId.IsNullable=false;
			CustomerCustomerId.AutoIncrement=true;
			CustomerCustomerId.IsForeignKey=true;
			CustomerSchema.Columns.Add(CustomerCustomerId);		
			
			IColumn CustomerFirstName=new DatabaseColumn("FirstName",CustomerSchema);
			CustomerFirstName.DataType=DbType.String;
			CustomerFirstName.IsNullable=false;
			CustomerFirstName.AutoIncrement=false;
			CustomerFirstName.IsForeignKey=false;
			CustomerSchema.Columns.Add(CustomerFirstName);		
			
			IColumn CustomerLastName=new DatabaseColumn("LastName",CustomerSchema);
			CustomerLastName.DataType=DbType.String;
			CustomerLastName.IsNullable=false;
			CustomerLastName.AutoIncrement=false;
			CustomerLastName.IsForeignKey=false;
			CustomerSchema.Columns.Add(CustomerLastName);		
			
			IColumn CustomerCompany=new DatabaseColumn("Company",CustomerSchema);
			CustomerCompany.DataType=DbType.String;
			CustomerCompany.IsNullable=true;
			CustomerCompany.AutoIncrement=false;
			CustomerCompany.IsForeignKey=false;
			CustomerSchema.Columns.Add(CustomerCompany);		
			
			IColumn CustomerAddress=new DatabaseColumn("Address",CustomerSchema);
			CustomerAddress.DataType=DbType.String;
			CustomerAddress.IsNullable=true;
			CustomerAddress.AutoIncrement=false;
			CustomerAddress.IsForeignKey=false;
			CustomerSchema.Columns.Add(CustomerAddress);		
			
			IColumn CustomerCity=new DatabaseColumn("City",CustomerSchema);
			CustomerCity.DataType=DbType.String;
			CustomerCity.IsNullable=true;
			CustomerCity.AutoIncrement=false;
			CustomerCity.IsForeignKey=false;
			CustomerSchema.Columns.Add(CustomerCity);		
			
			IColumn CustomerState=new DatabaseColumn("State",CustomerSchema);
			CustomerState.DataType=DbType.String;
			CustomerState.IsNullable=true;
			CustomerState.AutoIncrement=false;
			CustomerState.IsForeignKey=false;
			CustomerSchema.Columns.Add(CustomerState);		
			
			IColumn CustomerCountry=new DatabaseColumn("Country",CustomerSchema);
			CustomerCountry.DataType=DbType.String;
			CustomerCountry.IsNullable=true;
			CustomerCountry.AutoIncrement=false;
			CustomerCountry.IsForeignKey=false;
			CustomerSchema.Columns.Add(CustomerCountry);		
			
			IColumn CustomerPostalCode=new DatabaseColumn("PostalCode",CustomerSchema);
			CustomerPostalCode.DataType=DbType.String;
			CustomerPostalCode.IsNullable=true;
			CustomerPostalCode.AutoIncrement=false;
			CustomerPostalCode.IsForeignKey=false;
			CustomerSchema.Columns.Add(CustomerPostalCode);		
			
			IColumn CustomerPhone=new DatabaseColumn("Phone",CustomerSchema);
			CustomerPhone.DataType=DbType.String;
			CustomerPhone.IsNullable=true;
			CustomerPhone.AutoIncrement=false;
			CustomerPhone.IsForeignKey=false;
			CustomerSchema.Columns.Add(CustomerPhone);		
			
			IColumn CustomerFax=new DatabaseColumn("Fax",CustomerSchema);
			CustomerFax.DataType=DbType.String;
			CustomerFax.IsNullable=true;
			CustomerFax.AutoIncrement=false;
			CustomerFax.IsForeignKey=false;
			CustomerSchema.Columns.Add(CustomerFax);		
			
			IColumn CustomerEmail=new DatabaseColumn("Email",CustomerSchema);
			CustomerEmail.DataType=DbType.String;
			CustomerEmail.IsNullable=false;
			CustomerEmail.AutoIncrement=false;
			CustomerEmail.IsForeignKey=false;
			CustomerSchema.Columns.Add(CustomerEmail);		
			DataProvider.Tables.Add(CustomerSchema);
			
			//********************Employee********************
			//PK=EmployeeId
			ITable EmployeeSchema=new DatabaseTable("Employee",DataProvider);
			EmployeeSchema.ClassName="Employee";
			
			IColumn EmployeeEmployeeId=new DatabaseColumn("EmployeeId",EmployeeSchema);
			EmployeeEmployeeId.IsPrimaryKey=true;
			EmployeeEmployeeId.DataType=DbType.Int32;
			EmployeeEmployeeId.IsNullable=false;
			EmployeeEmployeeId.AutoIncrement=true;
			EmployeeEmployeeId.IsForeignKey=true;
			EmployeeSchema.Columns.Add(EmployeeEmployeeId);		
			
			IColumn EmployeeLastName=new DatabaseColumn("LastName",EmployeeSchema);
			EmployeeLastName.DataType=DbType.String;
			EmployeeLastName.IsNullable=false;
			EmployeeLastName.AutoIncrement=false;
			EmployeeLastName.IsForeignKey=false;
			EmployeeSchema.Columns.Add(EmployeeLastName);		
			
			IColumn EmployeeFirstName=new DatabaseColumn("FirstName",EmployeeSchema);
			EmployeeFirstName.DataType=DbType.String;
			EmployeeFirstName.IsNullable=false;
			EmployeeFirstName.AutoIncrement=false;
			EmployeeFirstName.IsForeignKey=false;
			EmployeeSchema.Columns.Add(EmployeeFirstName);		
			
			IColumn EmployeeTitle=new DatabaseColumn("Title",EmployeeSchema);
			EmployeeTitle.DataType=DbType.String;
			EmployeeTitle.IsNullable=true;
			EmployeeTitle.AutoIncrement=false;
			EmployeeTitle.IsForeignKey=false;
			EmployeeSchema.Columns.Add(EmployeeTitle);		
			
			IColumn EmployeeReportsTo=new DatabaseColumn("ReportsTo",EmployeeSchema);
			EmployeeReportsTo.DataType=DbType.Int32;
			EmployeeReportsTo.IsNullable=true;
			EmployeeReportsTo.AutoIncrement=false;
			EmployeeReportsTo.IsForeignKey=true;
			EmployeeSchema.Columns.Add(EmployeeReportsTo);		
			
			IColumn EmployeeBirthDate=new DatabaseColumn("BirthDate",EmployeeSchema);
			EmployeeBirthDate.DataType=DbType.DateTime;
			EmployeeBirthDate.IsNullable=true;
			EmployeeBirthDate.AutoIncrement=false;
			EmployeeBirthDate.IsForeignKey=false;
			EmployeeSchema.Columns.Add(EmployeeBirthDate);		
			
			IColumn EmployeeHireDate=new DatabaseColumn("HireDate",EmployeeSchema);
			EmployeeHireDate.DataType=DbType.DateTime;
			EmployeeHireDate.IsNullable=true;
			EmployeeHireDate.AutoIncrement=false;
			EmployeeHireDate.IsForeignKey=false;
			EmployeeSchema.Columns.Add(EmployeeHireDate);		
			
			IColumn EmployeeAddress=new DatabaseColumn("Address",EmployeeSchema);
			EmployeeAddress.DataType=DbType.String;
			EmployeeAddress.IsNullable=true;
			EmployeeAddress.AutoIncrement=false;
			EmployeeAddress.IsForeignKey=false;
			EmployeeSchema.Columns.Add(EmployeeAddress);		
			
			IColumn EmployeeCity=new DatabaseColumn("City",EmployeeSchema);
			EmployeeCity.DataType=DbType.String;
			EmployeeCity.IsNullable=true;
			EmployeeCity.AutoIncrement=false;
			EmployeeCity.IsForeignKey=false;
			EmployeeSchema.Columns.Add(EmployeeCity);		
			
			IColumn EmployeeState=new DatabaseColumn("State",EmployeeSchema);
			EmployeeState.DataType=DbType.String;
			EmployeeState.IsNullable=true;
			EmployeeState.AutoIncrement=false;
			EmployeeState.IsForeignKey=false;
			EmployeeSchema.Columns.Add(EmployeeState);		
			
			IColumn EmployeeCountry=new DatabaseColumn("Country",EmployeeSchema);
			EmployeeCountry.DataType=DbType.String;
			EmployeeCountry.IsNullable=true;
			EmployeeCountry.AutoIncrement=false;
			EmployeeCountry.IsForeignKey=false;
			EmployeeSchema.Columns.Add(EmployeeCountry);		
			
			IColumn EmployeePostalCode=new DatabaseColumn("PostalCode",EmployeeSchema);
			EmployeePostalCode.DataType=DbType.String;
			EmployeePostalCode.IsNullable=true;
			EmployeePostalCode.AutoIncrement=false;
			EmployeePostalCode.IsForeignKey=false;
			EmployeeSchema.Columns.Add(EmployeePostalCode);		
			
			IColumn EmployeePhone=new DatabaseColumn("Phone",EmployeeSchema);
			EmployeePhone.DataType=DbType.String;
			EmployeePhone.IsNullable=true;
			EmployeePhone.AutoIncrement=false;
			EmployeePhone.IsForeignKey=false;
			EmployeeSchema.Columns.Add(EmployeePhone);		
			
			IColumn EmployeeFax=new DatabaseColumn("Fax",EmployeeSchema);
			EmployeeFax.DataType=DbType.String;
			EmployeeFax.IsNullable=true;
			EmployeeFax.AutoIncrement=false;
			EmployeeFax.IsForeignKey=false;
			EmployeeSchema.Columns.Add(EmployeeFax);		
			
			IColumn EmployeeEmail=new DatabaseColumn("Email",EmployeeSchema);
			EmployeeEmail.DataType=DbType.String;
			EmployeeEmail.IsNullable=true;
			EmployeeEmail.AutoIncrement=false;
			EmployeeEmail.IsForeignKey=false;
			EmployeeSchema.Columns.Add(EmployeeEmail);		
			DataProvider.Tables.Add(EmployeeSchema);
			
			//********************Invoice********************
			//PK=InvoiceId
			ITable InvoiceSchema=new DatabaseTable("Invoice",DataProvider);
			InvoiceSchema.ClassName="Invoice";
			
			IColumn InvoiceInvoiceId=new DatabaseColumn("InvoiceId",InvoiceSchema);
			InvoiceInvoiceId.IsPrimaryKey=true;
			InvoiceInvoiceId.DataType=DbType.Int32;
			InvoiceInvoiceId.IsNullable=false;
			InvoiceInvoiceId.AutoIncrement=true;
			InvoiceInvoiceId.IsForeignKey=true;
			InvoiceSchema.Columns.Add(InvoiceInvoiceId);		
			
			IColumn InvoiceCustomerId=new DatabaseColumn("CustomerId",InvoiceSchema);
			InvoiceCustomerId.DataType=DbType.Int32;
			InvoiceCustomerId.IsNullable=false;
			InvoiceCustomerId.AutoIncrement=false;
			InvoiceCustomerId.IsForeignKey=true;
			InvoiceSchema.Columns.Add(InvoiceCustomerId);		
			
			IColumn InvoiceEmployeeId=new DatabaseColumn("EmployeeId",InvoiceSchema);
			InvoiceEmployeeId.DataType=DbType.Int32;
			InvoiceEmployeeId.IsNullable=true;
			InvoiceEmployeeId.AutoIncrement=false;
			InvoiceEmployeeId.IsForeignKey=true;
			InvoiceSchema.Columns.Add(InvoiceEmployeeId);		
			
			IColumn InvoiceInvoiceDate=new DatabaseColumn("InvoiceDate",InvoiceSchema);
			InvoiceInvoiceDate.DataType=DbType.DateTime;
			InvoiceInvoiceDate.IsNullable=false;
			InvoiceInvoiceDate.AutoIncrement=false;
			InvoiceInvoiceDate.IsForeignKey=false;
			InvoiceSchema.Columns.Add(InvoiceInvoiceDate);		
			
			IColumn InvoiceBillingAddress=new DatabaseColumn("BillingAddress",InvoiceSchema);
			InvoiceBillingAddress.DataType=DbType.String;
			InvoiceBillingAddress.IsNullable=true;
			InvoiceBillingAddress.AutoIncrement=false;
			InvoiceBillingAddress.IsForeignKey=false;
			InvoiceSchema.Columns.Add(InvoiceBillingAddress);		
			
			IColumn InvoiceBillingCity=new DatabaseColumn("BillingCity",InvoiceSchema);
			InvoiceBillingCity.DataType=DbType.String;
			InvoiceBillingCity.IsNullable=true;
			InvoiceBillingCity.AutoIncrement=false;
			InvoiceBillingCity.IsForeignKey=false;
			InvoiceSchema.Columns.Add(InvoiceBillingCity);		
			
			IColumn InvoiceBillingState=new DatabaseColumn("BillingState",InvoiceSchema);
			InvoiceBillingState.DataType=DbType.String;
			InvoiceBillingState.IsNullable=true;
			InvoiceBillingState.AutoIncrement=false;
			InvoiceBillingState.IsForeignKey=false;
			InvoiceSchema.Columns.Add(InvoiceBillingState);		
			
			IColumn InvoiceBillingCountry=new DatabaseColumn("BillingCountry",InvoiceSchema);
			InvoiceBillingCountry.DataType=DbType.String;
			InvoiceBillingCountry.IsNullable=true;
			InvoiceBillingCountry.AutoIncrement=false;
			InvoiceBillingCountry.IsForeignKey=false;
			InvoiceSchema.Columns.Add(InvoiceBillingCountry);		
			
			IColumn InvoiceBillingPostalCode=new DatabaseColumn("BillingPostalCode",InvoiceSchema);
			InvoiceBillingPostalCode.DataType=DbType.String;
			InvoiceBillingPostalCode.IsNullable=true;
			InvoiceBillingPostalCode.AutoIncrement=false;
			InvoiceBillingPostalCode.IsForeignKey=false;
			InvoiceSchema.Columns.Add(InvoiceBillingPostalCode);		
			DataProvider.Tables.Add(InvoiceSchema);
			
			//********************InvoiceLine********************
			//PK=InvoiceLineId
			ITable InvoiceLineSchema=new DatabaseTable("InvoiceLine",DataProvider);
			InvoiceLineSchema.ClassName="InvoiceLine";
			
			IColumn InvoiceLineInvoiceLineId=new DatabaseColumn("InvoiceLineId",InvoiceLineSchema);
			InvoiceLineInvoiceLineId.IsPrimaryKey=true;
			InvoiceLineInvoiceLineId.DataType=DbType.Int32;
			InvoiceLineInvoiceLineId.IsNullable=false;
			InvoiceLineInvoiceLineId.AutoIncrement=true;
			InvoiceLineInvoiceLineId.IsForeignKey=false;
			InvoiceLineSchema.Columns.Add(InvoiceLineInvoiceLineId);		
			
			IColumn InvoiceLineInvoiceId=new DatabaseColumn("InvoiceId",InvoiceLineSchema);
			InvoiceLineInvoiceId.DataType=DbType.Int32;
			InvoiceLineInvoiceId.IsNullable=false;
			InvoiceLineInvoiceId.AutoIncrement=false;
			InvoiceLineInvoiceId.IsForeignKey=true;
			InvoiceLineSchema.Columns.Add(InvoiceLineInvoiceId);		
			
			IColumn InvoiceLineTrackId=new DatabaseColumn("TrackId",InvoiceLineSchema);
			InvoiceLineTrackId.DataType=DbType.Int32;
			InvoiceLineTrackId.IsNullable=false;
			InvoiceLineTrackId.AutoIncrement=false;
			InvoiceLineTrackId.IsForeignKey=true;
			InvoiceLineSchema.Columns.Add(InvoiceLineTrackId);		
			
			IColumn InvoiceLineUnitPrice=new DatabaseColumn("UnitPrice",InvoiceLineSchema);
			InvoiceLineUnitPrice.DataType=DbType.Decimal;
			InvoiceLineUnitPrice.IsNullable=false;
			InvoiceLineUnitPrice.AutoIncrement=false;
			InvoiceLineUnitPrice.IsForeignKey=false;
			InvoiceLineSchema.Columns.Add(InvoiceLineUnitPrice);		
			
			IColumn InvoiceLineQuantity=new DatabaseColumn("Quantity",InvoiceLineSchema);
			InvoiceLineQuantity.DataType=DbType.Decimal;
			InvoiceLineQuantity.IsNullable=false;
			InvoiceLineQuantity.AutoIncrement=false;
			InvoiceLineQuantity.IsForeignKey=false;
			InvoiceLineSchema.Columns.Add(InvoiceLineQuantity);		
			DataProvider.Tables.Add(InvoiceLineSchema);
			
			//********************Genre********************
			//PK=GenreId
			ITable GenreSchema=new DatabaseTable("Genre",DataProvider);
			GenreSchema.ClassName="Genre";
			
			IColumn GenreGenreId=new DatabaseColumn("GenreId",GenreSchema);
			GenreGenreId.IsPrimaryKey=true;
			GenreGenreId.DataType=DbType.Int32;
			GenreGenreId.IsNullable=false;
			GenreGenreId.AutoIncrement=true;
			GenreGenreId.IsForeignKey=true;
			GenreSchema.Columns.Add(GenreGenreId);		
			
			IColumn GenreName=new DatabaseColumn("Name",GenreSchema);
			GenreName.DataType=DbType.String;
			GenreName.IsNullable=true;
			GenreName.AutoIncrement=false;
			GenreName.IsForeignKey=false;
			GenreSchema.Columns.Add(GenreName);		
			DataProvider.Tables.Add(GenreSchema);
			
			//********************MediaType********************
			//PK=MediaTypeId
			ITable MediaTypeSchema=new DatabaseTable("MediaType",DataProvider);
			MediaTypeSchema.ClassName="MediaType";
			
			IColumn MediaTypeMediaTypeId=new DatabaseColumn("MediaTypeId",MediaTypeSchema);
			MediaTypeMediaTypeId.IsPrimaryKey=true;
			MediaTypeMediaTypeId.DataType=DbType.Int32;
			MediaTypeMediaTypeId.IsNullable=false;
			MediaTypeMediaTypeId.AutoIncrement=true;
			MediaTypeMediaTypeId.IsForeignKey=true;
			MediaTypeSchema.Columns.Add(MediaTypeMediaTypeId);		
			
			IColumn MediaTypeName=new DatabaseColumn("Name",MediaTypeSchema);
			MediaTypeName.DataType=DbType.String;
			MediaTypeName.IsNullable=true;
			MediaTypeName.AutoIncrement=false;
			MediaTypeName.IsForeignKey=false;
			MediaTypeSchema.Columns.Add(MediaTypeName);		
			DataProvider.Tables.Add(MediaTypeSchema);
			
			//********************Artist********************
			//PK=ArtistId
			ITable ArtistSchema=new DatabaseTable("Artist",DataProvider);
			ArtistSchema.ClassName="Artist";
			
			IColumn ArtistArtistId=new DatabaseColumn("ArtistId",ArtistSchema);
			ArtistArtistId.IsPrimaryKey=true;
			ArtistArtistId.DataType=DbType.Int32;
			ArtistArtistId.IsNullable=false;
			ArtistArtistId.AutoIncrement=true;
			ArtistArtistId.IsForeignKey=true;
			ArtistSchema.Columns.Add(ArtistArtistId);		
			
			IColumn ArtistName=new DatabaseColumn("Name",ArtistSchema);
			ArtistName.DataType=DbType.String;
			ArtistName.IsNullable=true;
			ArtistName.AutoIncrement=false;
			ArtistName.IsForeignKey=false;
			ArtistSchema.Columns.Add(ArtistName);		
			DataProvider.Tables.Add(ArtistSchema);
	
			#endregion
		}
		

	}
}