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
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Employee_Manager.Module.BusinessObjects
{
    [DefaultClassOptions]
    

    public class Payment : BaseObject
    {
        public Payment(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        
        double hours;
        double rate;

        [ModelDefault("DisplayFormat", "{0:c}")]
        public double Rate
        {
            get => rate;
            set => SetPropertyValue(nameof(Rate), ref rate, value);
        }

        
        public double Hours
        {
            get => hours;
            set => SetPropertyValue(nameof(Hours), ref hours, value);
        }

        [NotMapped]
        [ModelDefault("DisplayFormat", "{0:c}")]
        public double Amount
        {
            get
            {
                return Rate * Hours;
            }
        }

    }

}