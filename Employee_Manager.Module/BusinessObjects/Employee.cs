using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Kpi;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.ExpressApp.Filtering;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace Employee_Manager.Module.BusinessObjects
{
    [DefaultClassOptions]

    [ObjectCaptionFormat("{0:FullName}")]
    [DefaultProperty(nameof(FullName))]
    public class Employee : BaseObject
    {
        public Employee(Session session)
            : base(session) { }

        public IList<DemoTask> DemoTasks { get; set; } = new ObservableCollection<DemoTask>();

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        DateTime birthday;
        string middleName;
        string lastName;
        string firstName;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string FirstName
        {
            get => firstName;
            set => SetPropertyValue(nameof(FirstName), ref firstName, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string LastName
        {
            get => lastName;
            set => SetPropertyValue(nameof(LastName), ref lastName, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string MiddleName
        {
            get => middleName;
            set => SetPropertyValue(nameof(MiddleName), ref middleName, value);
        }

        
        public DateTime Birthday
        {
            get => birthday;
            set => SetPropertyValue(nameof(Birthday), ref birthday, value);
        }


        //When you add a reference property of one entity type to another entity type, you establish the “One” part of the relationship between these entities.
        //In this case it is a relationship between the Department and Employee entity classes.
        public Department Department { get; set; }


        [Browsable(false)]
        public int TitleOfCourtesy_Int { get; set; }

        [NotMapped]
        public TitleOfCourtesy TitleOfCourtesy { get; set; }



        public class EmployeeManagerXpoDataStoreProvider : IXpoDataStoreProvider
        {
        private readonly IDataStore dataStore;

            public EmployeeManagerXpoDataStoreProvider(IDataStore dataStore)
            {
                this.dataStore = dataStore;
            }

            public IDataStore GetDataStore(IDataStore dataStore)
            {
                return dataStore;
            }

            public AutoCreateOption AutoCreateOption => AutoCreateOption.SchemaAlreadyExists;

            public IDataStore CreateUpdatingStore(bool allowUpdateSchema, out IDisposable[] disposableObjects)
            {
                disposableObjects = new IDisposable[] { (IDisposable)dataStore };
                return dataStore;
            }

            public string ConnectionString => ((ISqlDataStore)dataStore).ToString();

            public IDisposable[] CreateWorkingStore(out bool isReadonly)
            {
                var result = new[] { dataStore };
                isReadonly = false;
                return (IDisposable[])result;
            }

            public IDataStore CreateSchemaCheckingStore(out IDisposable[] disposableObjects)
            {
                disposableObjects = new IDisposable[] { (IDisposable)dataStore };
                return dataStore;
            }

            public IDataStore CreateWorkingStore(out IDisposable[] disposableObjects)
            {
                throw new NotImplementedException();
            }
        }

        [SearchMemberOptions(SearchMemberMode.Exclude)]
        public String FullName
        {
            get
            {
                return ObjectFormatter.Format(FullNameFormat, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public String DisplayName
        {
            get
            {
                return FullName;
            }
        }

        public static String FullNameFormat = "{FirstName} {MiddleName} {LastName}";

        [FieldSize(255)]
        public String Email
        {
            get;
            set;
        }

        [RuleRegularExpression(@"(((http|https) \://) [a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3} (:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;amp;%\$#\=~])*)|([a-zA-Z0-9.-]+\.[a-zA-Z] {2,6})", CustomMessageTemplate = @"Invalid ""Web Page Address"" .")]
        public String WebPageAddress
        {
            get;
            set;
        }

        [StringLength(4096)]
        public String Notes
        {
            get;
            set;
        }


    }

    public enum TitleOfCourtesy
    {
        Dr,
        Miss,
        Mr,
        Mrs,
        Ms
    }
}


/**
  *This is C# code for a class called "Employee" which derives from the "BaseObject" class. It represents an employee in an employee management system.

  *The class has a constructor that takes a "Session" object as an argument. The constructor calls the constructor of its base class ("BaseObject") and passes the "Session" object to it.

  *The class also has an overridden "AfterConstruction" method which is called after an object of this class is created.This method is empty in this implementation.

  *The class has three public properties: "FirstName", "LastName", and "MiddleName". Each property has a getter and a setter. 
   The getter gets the current value of the property, and the setter sets a new value and updates the property value using the "SetPropertyValue" method.

  *The class also has an inner class called "EmployeeManagerXpoDataStoreProvider" which implements the "IXpoDataStoreProvider" interface. 
   This inner class is used to provide a data store for this application. 
   It has several methods that implement the "IXpoDataStoreProvider" interface, including "CreateWorkingStore", "CreateUpdatingStore", "CreateSchemaCheckingStore", "GetDataStore", 
   and "ConnectionString".
   These methods provide different types of data stores for different purposes such as creating a schema checking store, creating a working store, creating an updating store, 
   and getting a connection string.

  *Finally, the "Employee" class has two attributes: "DefaultClassOptions" and "Persistent". 
   "DefaultClassOptions" attribute specifies the default options for this class and "Persistent" attribute specifies the name of the persistent class in the database.

  **/