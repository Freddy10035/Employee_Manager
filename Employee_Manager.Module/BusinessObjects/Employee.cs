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
using System.Security.AccessControl;

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

        /*[DevExpress.Xpo.Association("Employee-DemoTask")]
        public XPCollection<DemoTask> Tasks
        {
            get
            {
                return GetCollection<DemoTask>(nameof(DemoTasks));
            }
        }*/


        /* Employee employee = ObjectSpace.GetObjectByKey<Employee>(employee);
         DemoTask task = new DemoTask(Session);  

         // add the task to the employee's list
         employee.Employees.Add(task);

         // save changes to both objects 
         ObjectSpace.CommitChanges();*/


        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private const string V = "{FirstName} {MiddleName} {LastName}";
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



        /**
         * Big bug with the following code
         *
         * [DataSourceProperty("Department.Employees", DataSourcePropertyIsNullMode.SelectAll), DataSourceCriteria("Position.Title = 'Manager'")]
            public Employee Manager { get; set; }
        */


        public Address Address { get; set; }

        //The Employee class now exposes the Position reference property.
        //This way, you effectively create a “One-to-Many” relationship between these entity classes.
        public Position Position { get; set; }


        //When you add a reference property of one entity type to another entity type, you establish the “One” part of the relationship between these entities.
        //In this case it is a relationship between the Department and Employee entity classes.
        public Department Department { get; set; }


        [Browsable(false)]
        public int TitleOfCourtesy_Int { get; set; }

        [NotMapped]
        public TitleOfCourtesy TitleOfCourtesy { get; set; }

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

        public static String FullNameFormat = V;

        [FieldSize(255)]
        public String Email
        {
            get;
            set;
        }
        /**
         * Big bug here!!
         */

        [RuleRegularExpression(@"(((http|https)\://)[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})", CustomMessageTemplate = @"Invalid ""Web Page Address"".")]
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
