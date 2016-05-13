namespace SCADA_Control_Application
{
    partial class frmHIL
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
            this.tmrCheck = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.crtData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtData)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrCheck
            // 
            this.tmrCheck.Interval = 2000;
            this.tmrCheck.Tick += new System.EventHandler(this.tmrCheck_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crtData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1403, 677);
            this.panel1.TabIndex = 0;
            // 
            // crtData
            // 
            chartArea1.Name = "ChartArea1";
            this.crtData.ChartAreas.Add(chartArea1);
            this.crtData.Dock = System.Windows.Forms.DockStyle.Top;
            this.crtData.Location = new System.Drawing.Point(0, 0);
            this.crtData.Name = "crtData";
            this.crtData.Size = new System.Drawing.Size(1403, 656);
            this.crtData.TabIndex = 0;
            this.crtData.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnStop);
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 657);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1403, 103);
            this.panel2.TabIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(150, 37);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(112, 36);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(17, 37);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 35);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 4000;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // frmHIL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 760);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmHIL";
            this.Text = "HIL";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.crtData)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrCheck;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer tmrUpdate;
    }
}