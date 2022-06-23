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
            SaveSettings();
        }

        private void SaveAddress()
        {
            Properties.Settings.Default.IP_address = textBox_IP.Text;
            Properties.Settings.Default.Port_address = System.UInt16.Parse(textBox_Port.Text);
            SaveSettings();
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }

        private void SaveTextAlpha()
        {
            Properties.Settings.Default.alpha_Text = (ushort)alpha_Numeric.Value;
            SaveSettings();
        }

        private void SaveTextPositionX()
        {
            Properties.Settings.Default.positionX_Text = (ushort)positionX_Numeric.Value;
            SaveSettings();
        }

        private void SaveTextPositionY()
        {
            Properties.Settings.Default.positionY_Text = (ushort)positionY_Numeric.Value;
            SaveSettings();
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
            this.columnBPS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statsTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.positionX_Numeric = new System.Windows.Forms.NumericUpDown();
            this.alpha_Numeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.positionY_Numeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.positionX_Numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alpha_Numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionY_Numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // StatisticsList
            // 
            this.StatisticsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPid,
            this.columnCount,
            this.columnBPS,
            this.columnSize});
            this.StatisticsList.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatisticsList.FullRowSelect = true;
            this.StatisticsList.GridLines = true;
            this.StatisticsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.StatisticsList.HideSelection = false;
            this.StatisticsList.Location = new System.Drawing.Point(0, 97);
            this.StatisticsList.MultiSelect = false;
            this.StatisticsList.Name = "StatisticsList";
            this.StatisticsList.ShowGroups = false;
            this.StatisticsList.Size = new System.Drawing.Size(485, 153);
            this.StatisticsList.TabIndex = 0;
            this.StatisticsList.UseCompatibleStateImageBehavior = false;
            this.StatisticsList.View = System.Windows.Forms.View.Details;
            // 
            // columnPid
            // 
            this.columnPid.Text = "PID";
            this.columnPid.Width = 70;
            // 
            // columnCount
            // 
            this.columnCount.Text = "Count";
            this.columnCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnCount.Width = 110;
            // 
            // columnBPS
            // 
            this.columnBPS.Text = "Bitrate, MBPS";
            this.columnBPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnBPS.Width = 150;
            // 
            // columnSize
            // 
            this.columnSize.Text = "Renderer Size";
            this.columnSize.Width = 150;
            // 
            // statsTimer
            // 
            this.statsTimer.Interval = 1000;
            this.statsTimer.Tick += new System.EventHandler(this.statsTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(296, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP: ";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(334, 12);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(138, 20);
            this.textBox_IP.TabIndex = 2;
            this.textBox_IP.Text = global::GraphSample.Properties.Settings.Default.IP_address;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(286, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(334, 38);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(138, 20);
            this.textBox_Port.TabIndex = 4;
            this.textBox_Port.Text = "1234";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonConnect.Location = new System.Drawing.Point(334, 64);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(138, 27);
            this.buttonConnect.TabIndex = 5;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // positionX_Numeric
            // 
            this.positionX_Numeric.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.positionX_Numeric.Location = new System.Drawing.Point(102, 36);
            this.positionX_Numeric.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.positionX_Numeric.Name = "positionX_Numeric";
            this.positionX_Numeric.Size = new System.Drawing.Size(40, 20);
            this.positionX_Numeric.TabIndex = 6;
            this.positionX_Numeric.Value = global::GraphSample.Properties.Settings.Default.positionX_Text;
            this.positionX_Numeric.ValueChanged += new System.EventHandler(this.positionX_Numeric_ValueChanged);
            // 
            // alpha_Numeric
            // 
            this.alpha_Numeric.Location = new System.Drawing.Point(102, 12);
            this.alpha_Numeric.Name = "alpha_Numeric";
            this.alpha_Numeric.Size = new System.Drawing.Size(40, 20);
            this.alpha_Numeric.TabIndex = 7;
            this.alpha_Numeric.Value = global::GraphSample.Properties.Settings.Default.alpha_Text;
            this.alpha_Numeric.ValueChanged += new System.EventHandler(this.alpha_Numeric_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Alpha: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Position x: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Position y: ";
            // 
            // positionY_Numeric
            // 
            this.positionY_Numeric.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.positionY_Numeric.Location = new System.Drawing.Point(102, 62);
            this.positionY_Numeric.Maximum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.positionY_Numeric.Name = "positionY_Numeric";
            this.positionY_Numeric.Size = new System.Drawing.Size(40, 20);
            this.positionY_Numeric.TabIndex = 11;
            this.positionY_Numeric.Value = global::GraphSample.Properties.Settings.Default.positionY_Text;
            this.positionY_Numeric.ValueChanged += new System.EventHandler(this.positionY_Numeric_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 251);
            this.Controls.Add(this.positionY_Numeric);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.alpha_Numeric);
            this.Controls.Add(this.positionX_Numeric);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatisticsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Graph Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.positionX_Numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alpha_Numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionY_Numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader columnPid;
        private System.Windows.Forms.ColumnHeader columnBPS;
        private System.Windows.Forms.ColumnHeader columnCount;
        private System.Windows.Forms.Timer statsTimer;
        private System.Windows.Forms.ListView StatisticsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ColumnHeader columnSize;
        private System.Windows.Forms.NumericUpDown positionX_Numeric;
        private System.Windows.Forms.NumericUpDown alpha_Numeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown positionY_Numeric;
    }
}

