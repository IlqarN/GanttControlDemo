using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GanttControlDemo
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public class GanttTask
        {
            public int TaskID { get; set; }
            public int ParentID { get; set; }
            public string TaskName { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public DateTime BaseStartDate { get; set; }
            public DateTime BaseEndDate { get; set; }
            public List<int> Dependencies { get; set; }
        }

        public Form1()
        {
            InitializeComponent();

            ganttControl1.KeyFieldName = "TaskID";
            ganttControl1.ParentFieldName = "ParentID";
            ganttControl1.ChartMappings.TextFieldName = "TaskName";
            ganttControl1.ChartMappings.StartDateFieldName = "StartDate";
            ganttControl1.ChartMappings.FinishDateFieldName = "EndDate";
            ganttControl1.ChartMappings.BaselineStartDateFieldName = "StartDate";
            ganttControl1.ChartMappings.BaselineFinishDateFieldName = "EndDate";
            ganttControl1.OptionsView.ShowBaselines = true;

        }
        private List<GanttTask> GetGanttTasks()
        {
            return new List<GanttTask>
            {
                new GanttTask { TaskID = 1, ParentID = 0, TaskName = "Project Start1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(3),BaseStartDate = DateTime.Now, BaseEndDate = DateTime.Now.AddYears(3)},
                    new GanttTask { TaskID = 2, ParentID = 1, TaskName = "Task 1", StartDate = DateTime.Now.AddMonths(3), EndDate = DateTime.Now.AddMonths(6), BaseStartDate = DateTime.Now.AddMonths(4), BaseEndDate = DateTime.Now.AddMonths(7), Dependencies = new List<int>()  },
                    new GanttTask { TaskID = 3, ParentID = 1, TaskName = "Task 2", StartDate = DateTime.Now.AddMonths(7), EndDate = DateTime.Now.AddMonths(10), BaseStartDate = DateTime.Now.AddMonths(8), BaseEndDate = DateTime.Now.AddMonths(11) , Dependencies = new List<int>() },
                    new GanttTask { TaskID = 4, ParentID = 1, TaskName = "Task 3", StartDate = DateTime.Now.AddMonths(11), EndDate = DateTime.Now.AddMonths(14), BaseStartDate = DateTime.Now.AddMonths(12), BaseEndDate = DateTime.Now.AddMonths(15) , Dependencies = new List<int>() },
                new GanttTask { TaskID = 5, ParentID = 0, TaskName = "Project Start2", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(3), BaseStartDate = DateTime.Now, BaseEndDate = DateTime.Now.AddYears(3) },
                    new GanttTask { TaskID = 6, ParentID = 5, TaskName = "Task 1", StartDate = DateTime.Now.AddMonths(1), EndDate = DateTime.Now.AddMonths(5), BaseStartDate = DateTime.Now.AddMonths(3), BaseEndDate = DateTime.Now.AddMonths(7) , Dependencies = new List<int>() },
                    new GanttTask { TaskID = 7, ParentID = 5, TaskName = "Task 2", StartDate = DateTime.Now.AddMonths(6), EndDate = DateTime.Now.AddMonths(10), BaseStartDate = DateTime.Now.AddMonths(12), BaseEndDate = DateTime.Now.AddMonths(13) , Dependencies = new List<int>() },
                    new GanttTask { TaskID = 8, ParentID = 5, TaskName = "Task 3", StartDate = DateTime.Now.AddMonths(11), EndDate = DateTime.Now.AddMonths(15), BaseStartDate = DateTime.Now.AddMonths(17), BaseEndDate = DateTime.Now.AddMonths(22) , Dependencies = new List<int>() },
                new GanttTask { TaskID = 9, ParentID = 0, TaskName = "Project Start3", StartDate = DateTime.Now, EndDate = DateTime.Now.AddDays(1), BaseStartDate = DateTime.Now, BaseEndDate = DateTime.Now.AddYears(2) },
                    new GanttTask { TaskID = 10, ParentID = 9, TaskName = "Task 1", StartDate = DateTime.Now.AddMonths(2), EndDate = DateTime.Now.AddMonths(4), BaseStartDate = DateTime.Now.AddMonths(3), BaseEndDate = DateTime.Now.AddMonths(5) , Dependencies = new List<int>() },
                    new GanttTask { TaskID = 11, ParentID = 9, TaskName = "Task 2", StartDate = DateTime.Now.AddMonths(5), EndDate = DateTime.Now.AddMonths(7), BaseStartDate = DateTime.Now.AddMonths(6), BaseEndDate = DateTime.Now.AddMonths(8) , Dependencies = new List<int>() },
                    new GanttTask { TaskID = 12, ParentID = 9, TaskName = "Task 3", StartDate = DateTime.Now.AddMonths(8), EndDate = DateTime.Now.AddMonths(10), BaseStartDate = DateTime.Now.AddMonths(9), BaseEndDate = DateTime.Now.AddMonths(11), Dependencies = new List<int>() },
                new GanttTask { TaskID = 13, ParentID = 0, TaskName = "Project Start4", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(4), BaseStartDate = DateTime.Now, BaseEndDate = DateTime.Now.AddMonths(5) },
                    new GanttTask { TaskID = 14, ParentID = 13, TaskName = "Task 1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1), BaseStartDate = DateTime.Now.AddMonths(1), BaseEndDate = DateTime.Now.AddMonths(2) , Dependencies = new List<int>()},
                    new GanttTask { TaskID = 15, ParentID = 13, TaskName = "Task 2", StartDate = DateTime.Now.AddYears(1), EndDate = DateTime.Now.AddYears(2), BaseStartDate = DateTime.Now.AddYears(2), BaseEndDate = DateTime.Now.AddYears(3) , Dependencies = new List<int>()},
                    new GanttTask { TaskID = 16, ParentID = 13, TaskName = "Task 3", StartDate = DateTime.Now.AddYears(2), EndDate = DateTime.Now.AddYears(3), BaseStartDate = DateTime.Now.AddYears(3), BaseEndDate = DateTime.Now.AddYears(4) , Dependencies = new List<int>()}
            };
        }

        private void btnCalc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form1_Load(this,e);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var tasks = GetGanttTasks();
            ganttControl1.DataSource = tasks;
            tasks.Find(t => t.TaskID == 3).Dependencies.Add(2); 

        }
    }
}