
namespace GanttControlDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnCalc = new DevExpress.XtraBars.BarButtonItem();
            this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ganttControl1 = new DevExpress.XtraGantt.GanttControl();
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ganttControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainRibbonControl
            // 
            this.mainRibbonControl.ExpandCollapseItem.Id = 0;
            this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.mainRibbonControl.SearchEditItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiSaveAndNew,
            this.bbiReset,
            this.bbiDelete,
            this.bbiClose,
            this.btnCalc});
            this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
            this.mainRibbonControl.MaxItemId = 11;
            this.mainRibbonControl.Name = "mainRibbonControl";
            this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
            this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonControl.Size = new System.Drawing.Size(798, 158);
            this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Save";
            this.bbiSave.Id = 2;
            this.bbiSave.ImageOptions.ImageUri.Uri = "Save";
            this.bbiSave.Name = "bbiSave";
            // 
            // bbiSaveAndClose
            // 
            this.bbiSaveAndClose.Caption = "Save And Close";
            this.bbiSaveAndClose.Id = 3;
            this.bbiSaveAndClose.ImageOptions.ImageUri.Uri = "SaveAndClose";
            this.bbiSaveAndClose.Name = "bbiSaveAndClose";
            // 
            // bbiSaveAndNew
            // 
            this.bbiSaveAndNew.Caption = "Save And New";
            this.bbiSaveAndNew.Id = 4;
            this.bbiSaveAndNew.ImageOptions.ImageUri.Uri = "SaveAndNew";
            this.bbiSaveAndNew.Name = "bbiSaveAndNew";
            // 
            // bbiReset
            // 
            this.bbiReset.Caption = "Reset Changes";
            this.bbiReset.Id = 5;
            this.bbiReset.ImageOptions.ImageUri.Uri = "Reset";
            this.bbiReset.Name = "bbiReset";
            this.bbiReset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiReset_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Delete";
            this.bbiDelete.Id = 6;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Id = 7;
            this.bbiClose.ImageOptions.ImageUri.Uri = "Close";
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // btnCalc
            // 
            this.btnCalc.Caption = "Calculate";
            this.btnCalc.Id = 10;
            this.btnCalc.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCalc.ImageOptions.Image")));
            this.btnCalc.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCalc.ImageOptions.LargeImage")));
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCalc_ItemClick);
            // 
            // mainRibbonPage
            // 
            this.mainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mainRibbonPageGroup});
            this.mainRibbonPage.MergeOrder = 0;
            this.mainRibbonPage.Name = "mainRibbonPage";
            this.mainRibbonPage.Text = "Home";
            // 
            // mainRibbonPageGroup
            // 
            this.mainRibbonPageGroup.AllowTextClipping = false;
            this.mainRibbonPageGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.mainRibbonPageGroup.ItemLinks.Add(this.btnCalc);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiReset);
            this.mainRibbonPageGroup.ItemLinks.Add(this.bbiClose);
            this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
            this.mainRibbonPageGroup.Text = "Tasks";
            // 
            // ganttControl1
            // 
            this.ganttControl1.Appearance.CriticalPathTask.BackColor = System.Drawing.Color.Black;
            this.ganttControl1.Appearance.CriticalPathTask.BaselineColor = System.Drawing.Color.Red;
            this.ganttControl1.Appearance.CriticalPathTask.BorderColor = System.Drawing.Color.Black;
            this.ganttControl1.Appearance.CriticalPathTask.ForeColor = System.Drawing.Color.Black;
            this.ganttControl1.Appearance.Milestone.BaselineColor = System.Drawing.Color.Red;
            this.ganttControl1.Appearance.SummaryTask.BaselineColor = System.Drawing.Color.Red;
            this.ganttControl1.Appearance.Task.BaselineColor = System.Drawing.Color.Red;
            this.ganttControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ganttControl1.Location = new System.Drawing.Point(0, 158);
            this.ganttControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ganttControl1.MenuManager = this.mainRibbonControl;
            this.ganttControl1.MinWidth = 17;
            this.ganttControl1.Name = "ganttControl1";
            this.ganttControl1.OptionsBehavior.UpdateDependentTaskProgress = DevExpress.Utils.DefaultBoolean.True;
            this.ganttControl1.OptionsSplitter.OverlayResizeZoneThickness = 5;
            this.ganttControl1.OptionsSplitter.SplitterThickness = 5;
            this.ganttControl1.OptionsView.ShowBaselines = true;
            this.ganttControl1.OptionsView.ShowIndentAsRowStyle = true;
            this.ganttControl1.OptionsView.ShowTreeLines = DevExpress.Utils.DefaultBoolean.True;
            this.ganttControl1.Size = new System.Drawing.Size(798, 441);
            this.ganttControl1.SplitterPosition = 500;
            this.ganttControl1.TabIndex = 1;
            this.ganttControl1.TreeLevelWidth = 15;
            this.ganttControl1.CustomDrawTask += new DevExpress.XtraGantt.CustomDrawTaskEventHandler(this.ganttControl1_CustomDrawTask);
            this.ganttControl1.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.ganttControl1_CellValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(798, 599);
            this.Controls.Add(this.ganttControl1);
            this.Controls.Add(this.mainRibbonControl);
            this.Name = "Form1";
            this.Ribbon = this.mainRibbonControl;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ganttControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem bbiReset;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraGantt.GanttControl ganttControl1;
        private DevExpress.XtraBars.BarButtonItem btnCalc;
    }
}