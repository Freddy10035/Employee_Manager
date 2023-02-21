using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Employee_Manager.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Title))]
    
    public class Department : BaseObject
    {
        public Department(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        string office;
        string title;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Title
        {
            get => title;
            set => SetPropertyValue(nameof(Title), ref title, value);
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Office
        {
            get => office;
            set => SetPropertyValue(nameof(Office), ref office, value);
        }


        //This way, you implement the “Many” part of the relationship between the Department object and the Employee object.
        public IList<Employee> Employee { get; set; } = new ObservableCollection<Employee>();

    }
}