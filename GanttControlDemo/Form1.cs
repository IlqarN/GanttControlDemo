using DevExpress.XtraEditors;
using DevExpress.XtraGantt;
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
        bool isCalc = false;
        bool isReset = false;
        public Form1()
        {
            InitializeComponent();

            ganttControl1.KeyFieldName = "TaskID";
            ganttControl1.ParentFieldName = "ParentID";
            ganttControl1.ChartMappings.TextFieldName = "TaskName";
            ganttControl1.ChartMappings.StartDateFieldName = "StartDate";
            ganttControl1.ChartMappings.FinishDateFieldName = "EndDate";
            ganttControl1.ChartMappings.BaselineStartDateFieldName = "BaseStartDate";
            ganttControl1.ChartMappings.BaselineFinishDateFieldName = "BaseEndDate";
            ganttControl1.ChartMappings.ProgressFieldName = "ProgDate";
            ganttControl1.OptionsView.ShowBaselines = true;

            ganttControl1.DependencyMappings.PredecessorFieldName = "PredecessorID";
            ganttControl1.DependencyMappings.SuccessorFieldName = "SuccessorID";
            ganttControl1.DependencyMappings.TypeFieldName = "DependencyType";
            ganttControl1.DependencyMappings.LagFieldName = "TimeLag";
            ganttControl1.DependencySource = GetDependencies();


        }
        private BindingList<GanttTask> GetGanttTasks()
        {
            return new BindingList<GanttTask>
            {
                new GanttTask { TaskID = 1, ParentID = 0, TaskName = "Project Start1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1),BaseStartDate = DateTime.Now, BaseEndDate = DateTime.Now.AddYears(1)},
                    new GanttTask { TaskID = 2, ParentID = 1, TaskName = "Task 1", StartDate = DateTime.Now.AddMonths(3), EndDate = DateTime.Now.AddMonths(6), BaseStartDate = DateTime.Now.AddMonths(4), BaseEndDate = DateTime.Now.AddMonths(7), Dependencies = new List<int>()  },
                    new GanttTask { TaskID = 3, ParentID = 1, TaskName = "Task 2", StartDate = DateTime.Now.AddMonths(6), EndDate = DateTime.Now.AddMonths(9), BaseStartDate = DateTime.Now.AddMonths(7), BaseEndDate = DateTime.Now.AddMonths(10) , Dependencies = new List<int>() },
                    new GanttTask { TaskID = 4, ParentID = 1, TaskName = "Task 3", StartDate = DateTime.Now.AddMonths(9), EndDate = DateTime.Now.AddMonths(12), BaseStartDate = DateTime.Now.AddMonths(10), BaseEndDate = DateTime.Now.AddMonths(13) , Dependencies = new List<int>() },
                new GanttTask { TaskID = 5, ParentID = 0, TaskName = "Project Start2", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(2), BaseStartDate = DateTime.Now, BaseEndDate = DateTime.Now.AddYears(2) },
                    new GanttTask { TaskID = 6, ParentID = 5, TaskName = "Task 1", StartDate = DateTime.Now.AddMonths(1), EndDate = DateTime.Now.AddMonths(5), BaseStartDate = DateTime.Now.AddMonths(3), BaseEndDate = DateTime.Now.AddMonths(7) , Dependencies = new List<int>() },
                    new GanttTask { TaskID = 7, ParentID = 5, TaskName = "Task 2", StartDate = DateTime.Now.AddMonths(5), EndDate = DateTime.Now.AddMonths(9), BaseStartDate = DateTime.Now.AddMonths(7), BaseEndDate = DateTime.Now.AddMonths(11) , Dependencies = new List<int>() },
                    new GanttTask { TaskID = 8, ParentID = 5, TaskName = "Task 3", StartDate = DateTime.Now.AddMonths(9), EndDate = DateTime.Now.AddMonths(13), BaseStartDate = DateTime.Now.AddMonths(11), BaseEndDate = DateTime.Now.AddMonths(15) , Dependencies = new List<int>() },
                new GanttTask { TaskID = 9, ParentID = 0, TaskName = "Project Start3", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1), BaseStartDate = DateTime.Now, BaseEndDate = DateTime.Now.AddYears(2) },
                    new GanttTask { TaskID = 10, ParentID = 9, TaskName = "Task 1", StartDate = DateTime.Now.AddMonths(2), EndDate = DateTime.Now.AddMonths(4), BaseStartDate = DateTime.Now.AddMonths(3), BaseEndDate = DateTime.Now.AddMonths(5) , Dependencies = new List<int>() },
                    new GanttTask { TaskID = 11, ParentID = 9, TaskName = "Task 2", StartDate = DateTime.Now.AddMonths(4), EndDate = DateTime.Now.AddMonths(6), BaseStartDate = DateTime.Now.AddMonths(5), BaseEndDate = DateTime.Now.AddMonths(7) , Dependencies = new List<int>() },
                    new GanttTask { TaskID = 12, ParentID = 9, TaskName = "Task 3", StartDate = DateTime.Now.AddMonths(6), EndDate = DateTime.Now.AddMonths(8), BaseStartDate = DateTime.Now.AddMonths(7), BaseEndDate = DateTime.Now.AddMonths(9), Dependencies = new List<int>() },
                new GanttTask { TaskID = 13, ParentID = 0, TaskName = "Project Start4", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(4), BaseStartDate = DateTime.Now, BaseEndDate = DateTime.Now.AddYears(5) },
                    new GanttTask { TaskID = 14, ParentID = 13, TaskName = "Task 1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddYears(1), BaseStartDate = DateTime.Now.AddYears(1), BaseEndDate = DateTime.Now.AddYears(2) , Dependencies = new List<int>()},
                    new GanttTask { TaskID = 15, ParentID = 13, TaskName = "Task 2", StartDate = DateTime.Now.AddYears(1), EndDate = DateTime.Now.AddYears(2), BaseStartDate = DateTime.Now.AddYears(2), BaseEndDate = DateTime.Now.AddYears(3) , Dependencies = new List<int>()},
                    new GanttTask { TaskID = 16, ParentID = 13, TaskName = "Task 3", StartDate = DateTime.Now.AddYears(2), EndDate = DateTime.Now.AddYears(3), BaseStartDate = DateTime.Now.AddYears(3), BaseEndDate = DateTime.Now.AddYears(4) , Dependencies = new List<int>()}
            };
        }
        DataTable GetDependencies()
        {
            DataTable table = new DataTable();
            DataColumn predecessor = new DataColumn("PredecessorID", typeof(int));
            DataColumn successor = new DataColumn("SuccessorID", typeof(int));
            DataColumn dependencyType = new DataColumn("DependencyType", typeof(DevExpress.XtraGantt.DependencyType));
            DataColumn lag = new DataColumn("TimeLag", typeof(TimeSpan));
            table.Columns.AddRange(new DataColumn[] { predecessor, successor, dependencyType, lag });
            table.Rows.Add(new object[] { 1, 2, DependencyType.StartToStart, null });
            table.Rows.Add(new object[] { 2, 3, DependencyType.FinishToStart, null });
            table.Rows.Add(new object[] { 3, 4, DependencyType.FinishToStart, null });

            table.Rows.Add(new object[] { 5, 6, DependencyType.StartToStart, null });
            table.Rows.Add(new object[] { 6, 7, DependencyType.FinishToStart, null });
            table.Rows.Add(new object[] { 7, 8, DependencyType.FinishToStart, null });

            table.Rows.Add(new object[] { 9, 10, DependencyType.StartToStart, null });
            table.Rows.Add(new object[] { 10, 11, DependencyType.FinishToStart, null });
            table.Rows.Add(new object[] { 11, 12, DependencyType.FinishToStart, null });

            table.Rows.Add(new object[] { 13, 14, DependencyType.StartToStart, null });
            table.Rows.Add(new object[] { 14, 15, DependencyType.FinishToStart, null });
            table.Rows.Add(new object[] { 15, 16, DependencyType.FinishToStart, null });

            return table;
        }

        private void btnCalc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isCalc = true;
            BindingList<GanttTask> dts = (BindingList<GanttTask>)ganttControl1.DataSource;
            foreach (GanttTask task in dts)
            {
                if (task.ParentID!=0)
                {
                    TimeSpan diference = task.EndDate - task.StartDate;
                    task.BaseEndDate = task.BaseStartDate + diference;
                }
            }
            ganttControl1.DataSource = dts;
            ganttControl1.RefreshDataSource();


        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isReset = true;
            Form1_Load(this,e);
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var tasks = GetGanttTasks();
            if (!isCalc)
            {
                ganttControl1.DataSource = tasks;
            }
            else if (isReset)
            {
                ganttControl1.DataSource = tasks;
            }
            ganttControl1.Columns["StartDate"].OptionsColumn.ReadOnly = false;
            ganttControl1.Columns["StartDate"].OptionsColumn.AllowEdit = true;

            ganttControl1.ExpandAll();

        }

        private void ganttControl1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            //var focusedNode = ganttControl1.FocusedValue;
            // if (focusedNode != null)
            // {
            //     var cellValue = ganttControl1.GetRowCellValue(focusedNode, ganttControl1.FocusedColumn);
            //     MessageBox.Show(cellValue.ToString());
            // }
            ganttControl1.RefreshDataSource();
        }

        private void ganttControl1_CustomDrawTask(object sender, CustomDrawTaskEventArgs e)
        {
            e.Appearance.BackColor = System.Drawing.Color.Red;
            e.Appearance.Options.UseBackColor = true;
        }
    }
}