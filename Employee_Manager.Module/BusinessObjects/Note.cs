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
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Employee_Manager.Module.BusinessObjects;


[DefaultProperty(nameof(Text))]
[ImageName("BO_Note")]

public class Note : BaseObject
{ 
    public Note(Session session)
        : base(session)
    {
    }

    [DevExpress.ExpressApp.Data.Key, Browsable(false)]
    [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
    public Guid ID { get; set; }
    public String Author { get; set; }
    public DateTime? DateTime { get; set; }

    [FieldSize(FieldSizeAttribute.Unlimited)]
    public String Text { get; set; }



    public override void AfterConstruction()
    {
        base.AfterConstruction();
        // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    }
   
}