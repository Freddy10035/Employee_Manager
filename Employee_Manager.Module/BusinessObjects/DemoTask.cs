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
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;

namespace Employee_Manager.Module.BusinessObjects
{
    [DefaultClassOptions]

    [ModelDefault("Caption", "Task")]
    public class DemoTask : BaseObject
    {
        public DemoTask(Session session)
            : base(session)
        {
        }
        // in XPO we set the default value of the Priority property in the AfterConstruction method rather than in the Override method which is not supported by the XPO but the Entity Framework.
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
            Priority = Priority.Normal;
        }

        /*public override void OnCreated()
        {
            Priority = Priority.Normal;
        }*/


        // private Employee _assignedTo;
        /*[Association("Employee-DemoTask")]
        public Employee AssignedTo
        {
            get;
            set;
        }
        */

        [Action(ToolTip = "Postpone the task to the next day", Caption = "Postpone")]

        // Shifts the task due date to the next day.
        public void Postpone()
        {
            if (DueDate == DateTime.MinValue)
            {
                DueDate= DateTime.Now;
            }

            DueDate = DueDate + TimeSpan.FromDays(1);
        }

        int percentCompleted;
        DateTime startDate;
        DateTime dueDate;
        string description;
        string subject;
        DateTime? dateCompleted;

        public DateTime? DateCompleted
        {
            get => dateCompleted;
            set => SetPropertyValue(nameof(DateCompleted), ref dateCompleted, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Subject
        {
            get => subject;
            set => SetPropertyValue(nameof(Subject), ref subject, value);
        }


        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }


        public DateTime DueDate
        {
            get => dueDate;
            set => SetPropertyValue(nameof(DueDate), ref dueDate, value);
        }


        public DateTime StartDate
        {
            get => startDate;
            set => SetPropertyValue(nameof(StartDate), ref startDate, value);
        }

        
        public int PercentCompleted
        {
            get => percentCompleted;
            set => SetPropertyValue(nameof(PercentCompleted), ref percentCompleted, value);
        }

        private TaskStatus status;
        public TaskStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                if (isLoaded)
                {
                    if (value == TaskStatus.Completed)
                    {
                        DateCompleted = DateTime.Now;
                    }
                    else
                    {
                        DateCompleted = null;
                    }
                }
            }
        }
        public Priority Priority
        {
            get;
            set;
        }

        [Action(ImageName = "State_Task_Completed")]
        public void MarkCompleted()
        {
            Status = TaskStatus.Completed;
        }

        private bool isLoaded = false;
        protected override void OnLoaded()
        {
            //base.OnLoaded();
            isLoaded = true;
        }

        public IList<Employee> Employees { get; set; } = new ObservableCollection<Employee>(); 
    
    }

    
    public enum TaskStatus
    {
        [ImageName("State_task_NotStarted")]
        NotStarted,
        [ImageName("State_Task_InProgress")]
        InProgress,
        [ImageName("State_Task_WaitingForSomeoneElse")]
        WaitingForSomeoneElse,
        [ImageName("State_Task_Deferred")]
        Deferred,
        [ImageName("State_task_completed")]
        Completed
    }

    public enum Priority
    {
        [ImageName("State_Priority_Low")]
        Low = 0,
        [ImageName("State_Priority_Normal")]
        Normal = 1,
        [ImageName("State_Priority_High")]
        High = 2
    }

}