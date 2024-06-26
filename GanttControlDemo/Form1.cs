﻿using DevExpress.XtraEditors;
using DevExpress.XtraGantt;
using DevExpress.XtraGantt.Data;
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
            public int Progress { get; set; }
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
            ganttControl1.ChartMappings.ProgressFieldName = "Progress";
            ganttControl1.OptionsView.ShowBaselines = true;

            ganttControl1.DependencyMappings.PredecessorFieldName = "PredecessorID";
            ganttControl1.DependencyMappings.SuccessorFieldName = "SuccessorID";
            ganttControl1.DependencyMappings.TypeFieldName = "DependencyType";
            ganttControl1.DependencyMappings.LagFieldName = "TimeLag";
            ganttControl1.DependencySource = GetDependencies();


        }
        private BindingList<GanttTask> GetGanttTasks()
        {
            var tasks = new BindingList<GanttTask>();
            DateTime now = DateTime.Now;
            // Project Start1
            tasks.Add(new GanttTask { TaskID = 1, ParentID = 0, TaskName = "Project Start1", StartDate = now, EndDate = now.AddYears(1), BaseStartDate = now, BaseEndDate = now.AddYears(1) });
            tasks.Add(new GanttTask { TaskID = 2, ParentID = 1, TaskName = "Task 1", StartDate = now, EndDate = now.AddMonths(6), BaseStartDate = now.AddMonths(4), BaseEndDate = now.AddMonths(7) });
            tasks.Add(new GanttTask { TaskID = 3, ParentID = 1, TaskName = "Task 2", StartDate = now.AddMonths(6), EndDate = now.AddMonths(9), BaseStartDate = now.AddMonths(7), BaseEndDate = now.AddMonths(10) });
            tasks.Add(new GanttTask { TaskID = 4, ParentID = 1, TaskName = "Task 3", StartDate = now.AddMonths(9), EndDate = now.AddMonths(12), BaseStartDate = now.AddMonths(10), BaseEndDate = now.AddMonths(13) });

            // Project Start2
            tasks.Add(new GanttTask { TaskID = 5, ParentID = 0, TaskName = "Project Start2", StartDate = now, EndDate = now.AddYears(2), BaseStartDate = now, BaseEndDate = now.AddYears(2) });
            tasks.Add(new GanttTask { TaskID = 6, ParentID = 5, TaskName = "Task 1", StartDate = now.AddMonths(1), EndDate = now.AddMonths(5), BaseStartDate = now.AddMonths(3), BaseEndDate = now.AddMonths(7) });
            tasks.Add(new GanttTask { TaskID = 7, ParentID = 5, TaskName = "Task 2", StartDate = now.AddMonths(5), EndDate = now.AddMonths(9), BaseStartDate = now.AddMonths(7), BaseEndDate = now.AddMonths(11) });
            tasks.Add(new GanttTask { TaskID = 8, ParentID = 5, TaskName = "Task 3", StartDate = now.AddMonths(9), EndDate = now.AddMonths(13), BaseStartDate = now.AddMonths(11), BaseEndDate = now.AddMonths(15) });

            // Project Start3
            tasks.Add(new GanttTask { TaskID = 9, ParentID = 0, TaskName = "Project Start3", StartDate = now, EndDate = now.AddYears(1), BaseStartDate = now, BaseEndDate = now.AddYears(2) });
            tasks.Add(new GanttTask { TaskID = 10, ParentID = 9, TaskName = "Task 1", StartDate = now.AddMonths(2), EndDate = now.AddMonths(4), BaseStartDate = now.AddMonths(3), BaseEndDate = now.AddMonths(5) });
            tasks.Add(new GanttTask { TaskID = 11, ParentID = 9, TaskName = "Task 2", StartDate = now.AddMonths(4), EndDate = now.AddMonths(6), BaseStartDate = now.AddMonths(5), BaseEndDate = now.AddMonths(7) });
            tasks.Add(new GanttTask { TaskID = 12, ParentID = 9, TaskName = "Task 3", StartDate = now.AddMonths(6), EndDate = now.AddMonths(8), BaseStartDate = now.AddMonths(7), BaseEndDate = now.AddMonths(9) });

            // Project Start4
            tasks.Add(new GanttTask { TaskID = 13, ParentID = 0, TaskName = "Project Start4", StartDate = now, EndDate = now.AddYears(4), BaseStartDate = now, BaseEndDate = now.AddYears(5) });
            tasks.Add(new GanttTask { TaskID = 14, ParentID = 13, TaskName = "Task 1", StartDate = now, EndDate = now.AddYears(1), BaseStartDate = now.AddYears(1), BaseEndDate = now.AddYears(2) });
            tasks.Add(new GanttTask { TaskID = 15, ParentID = 13, TaskName = "Task 2", StartDate = now.AddYears(1), EndDate = now.AddYears(2), BaseStartDate = now.AddYears(2), BaseEndDate = now.AddYears(3) });
            tasks.Add(new GanttTask { TaskID = 16, ParentID = 13, TaskName = "Task 3", StartDate = now.AddYears(2), EndDate = now.AddYears(3), BaseStartDate = now.AddYears(3), BaseEndDate = now.AddYears(4) });

            //for (int i = 18; i < 10000; i++)
            //{
            //    tasks.Add(new GanttTask { TaskID = i, ParentID = 0, TaskName = "Project Start1", StartDate = now, EndDate = now.AddYears(1), BaseStartDate = now, BaseEndDate = now.AddYears(1) });
            //}
            return tasks;
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

        private void CalcProgress()
        {
            BindingList<GanttTask> dts = (BindingList<GanttTask>)ganttControl1.DataSource;
            foreach (GanttTask task in dts)
            {
                if (task.ParentID != 0 && task.StartDate < DateTime.Now.AddMonths(3))
                {
                    if (DateTime.Now.AddMonths(3) > task.StartDate)
                    {
                        TimeSpan diferenceSE = task.EndDate - task.StartDate;
                        TimeSpan diferenceSN = DateTime.Now.AddMonths(3) - task.StartDate;
                        decimal progress = Convert.ToDecimal(diferenceSN.TotalDays / diferenceSE.TotalDays);
                        if (progress <= 0)
                        {
                            task.Progress = 0;
                        }
                        else
                        {
                            task.Progress = Convert.ToInt32(progress * 100);
                        }
                    }
                }
            }
            ganttControl1.DataSource = dts;
            ganttControl1.RefreshDataSource();
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
            CalcProgress();
            ganttControl1.ExpandAll();

        }

        private void ganttControl1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            CalcProgress();
            ganttControl1.RefreshDataSource();
        }

        private void ganttControl1_CustomDrawTask(object sender, CustomDrawTaskEventArgs e)
        {
            e.Appearance.BackColor = System.Drawing.Color.Red;
            e.Appearance.Options.UseBackColor = true;
        }
    }
}