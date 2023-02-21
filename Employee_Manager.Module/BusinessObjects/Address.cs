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

namespace Employee_Manager.Module.BusinessObjects
{
   // [DefaultClassOptions]
    [DefaultProperty(nameof(FullAddress))]
    public class Address : BaseObject
    { 
        public Address(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private String defaultFullAddressFormat = "{Country}; {StateProvince}; {City}; {Street}; {ZipPostal}";


        string country;
        string zipPostal;
        string stateProvince;
        string city;
        string street;

        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Street
        {
            get => street;
            set => SetPropertyValue(nameof(Street), ref street, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string City
        {
            get => city;
            set => SetPropertyValue(nameof(City), ref city, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string StateProvince
        {
            get => stateProvince;
            set => SetPropertyValue(nameof(StateProvince), ref stateProvince, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string ZipPostal
        {
            get => zipPostal;
            set => SetPropertyValue(nameof(ZipPostal), ref zipPostal, value);
        }

        
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Country
        {
            get => country;
            set => SetPropertyValue(nameof(Country), ref country, value);
        }

        public String FullAddress
        {
            get
            {
                return ObjectFormatter.Format(defaultFullAddressFormat, this, EmptyEntriesMode.RemoveDelimiterWhenEntryIsEmpty); 
            }
        }
    }
}