namespace GraphSample
{
    partial class MainForm
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

        private void SavePosition()
        {
            Properties.Settings.Default.WindowSize = this.Size;
            Properties.Settings.Default.WindowLocation = this.Location;
            Properties.Settings.Default.Save();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StatisticsList = new System.Windows.Forms.ListView();
            this.columnPid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statsTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // StatisticsList
            // 
            this.StatisticsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatisticsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPid,
            this.columnCount});
            this.StatisticsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatisticsList.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatisticsList.FullRowSelect = true;
            this.StatisticsList.GridLines = true;
            this.StatisticsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.StatisticsList.HideSelection = false;
            this.StatisticsList.Location = new System.Drawing.Point(0, 0);
            this.StatisticsList.MultiSelect = false;
            this.StatisticsList.Name = "StatisticsList";
            this.StatisticsList.ShowGroups = false;
            this.StatisticsList.Size = new System.Drawing.Size(284, 262);
            this.StatisticsList.TabIndex = 0;
            this.StatisticsList.UseCompatibleStateImageBehavior = false;
            this.StatisticsList.View = System.Windows.Forms.View.Details;
            
            // 
            // columnPid
            // 
            this.columnPid.Text = "PID";
            this.columnPid.Width = 79;
            // 
            // columnCount
            // 
            this.columnCount.Text = "Count";
            this.columnCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnCount.Width = 181;
            // 
            // statsTimer
            // 
            this.statsTimer.Interval = 1000;
            this.statsTimer.Tick += new System.EventHandler(this.statsTimer_Tick);
            // 
            // MainForm
            // 
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Location = Properties.Settings.Default.WindowLocation;
            this.Size = Properties.Settings.Default.WindowSize;
            this.Controls.Add(this.StatisticsList);
            this.Name = "MainForm";
            this.Text = "Graph Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView StatisticsList;
        private System.Windows.Forms.ColumnHeader columnPid;
        private System.Windows.Forms.ColumnHeader columnCount;
        private System.Windows.Forms.Timer statsTimer;
        
    }
}

