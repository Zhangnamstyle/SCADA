namespace SCADA_Control_Application
{
    partial class frmSimulation
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.crtData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.trbSp = new System.Windows.Forms.TrackBar();
            this.lblSetpoint = new System.Windows.Forms.Label();
            this.tmrCheck = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.crtData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSp)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // crtData
            // 
            chartArea1.Name = "ChartArea1";
            this.crtData.ChartAreas.Add(chartArea1);
            this.crtData.Dock = System.Windows.Forms.DockStyle.Top;
            this.crtData.Location = new System.Drawing.Point(0, 0);
            this.crtData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.crtData.Name = "crtData";
            this.crtData.Size = new System.Drawing.Size(1403, 666);
            this.crtData.TabIndex = 0;
            this.crtData.Text = "chtData";
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 2000;
            this.tmrUpdate.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(27, 39);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 35);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // trbSp
            // 
            this.trbSp.Location = new System.Drawing.Point(978, 50);
            this.trbSp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trbSp.Name = "trbSp";
            this.trbSp.Size = new System.Drawing.Size(352, 69);
            this.trbSp.TabIndex = 2;
            this.trbSp.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // lblSetpoint
            // 
            this.lblSetpoint.AutoSize = true;
            this.lblSetpoint.Location = new System.Drawing.Point(1128, 12);
            this.lblSetpoint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSetpoint.Name = "lblSetpoint";
            this.lblSetpoint.Size = new System.Drawing.Size(51, 20);
            this.lblSetpoint.TabIndex = 3;
            this.lblSetpoint.Text = "label1";
            // 
            // tmrCheck
            // 
            this.tmrCheck.Interval = 4000;
            this.tmrCheck.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crtData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1403, 653);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnStop);
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Controls.Add(this.trbSp);
            this.panel2.Controls.Add(this.lblSetpoint);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 659);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1403, 101);
            this.panel2.TabIndex = 11;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(160, 39);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(112, 36);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // frmSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 760);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSimulation";
            this.Text = "PC Control System";
            ((System.ComponentModel.ISupportInitialize)(this.crtData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbSp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart crtData;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TrackBar trbSp;
        private System.Windows.Forms.Label lblSetpoint;
        private System.Windows.Forms.Timer tmrCheck;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnStop;
    }
}

