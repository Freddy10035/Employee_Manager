using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Employee_Manager.Module.BusinessObjects;

namespace Employee_Manager.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ClearContactTasksController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public ClearContactTasksController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.

            // Activate the Controller only in the Detail View
            TargetViewType = ViewType.DetailView;

            // specify the target object type that can use the controller
            TargetObjectType = typeof(Employee);


            SimpleAction clearTasksAction = new SimpleAction(this, "ClearTaskAction", PredefinedCategory.View) 
            { 
                // specify the Action's button caption
                Caption = "Clear Tasks", 
                // specify the Action's confirmation message
                ConfirmationMessage = "Are you sure you want to clear all tasks?", 
                // specify the icon of the Action's button in the interface
                ImageName = "Action_Clear" 
            };
            // this event fires when a user clicks the Action's button
            clearTasksAction.Execute += ClearTasksAction_Execute;
            
         }

        private void ClearTasksAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            while (((Employee)View.CurrentObject).DemoTasks.Count > 0)
            {
                ((Employee)View.CurrentObject).DemoTasks.Remove(((Employee)View.CurrentObject).DemoTasks[0]);
                ObjectSpace.SetModified(View.CurrentObject, View.ObjectTypeInfo.FindMember(nameof(Employee.DemoTasks)));
                
            }


        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }


    }
}
