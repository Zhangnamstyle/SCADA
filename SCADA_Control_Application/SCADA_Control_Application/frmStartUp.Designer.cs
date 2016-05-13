namespace SCADA_Control_Application
{
    partial class frmStartUp
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbLog = new System.Windows.Forms.RadioButton();
            this.rdbHil = new System.Windows.Forms.RadioButton();
            this.rdbSim = new System.Windows.Forms.RadioButton();
            this.txtDevName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(34, 378);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(356, 54);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbLog);
            this.groupBox1.Controls.Add(this.rdbHil);
            this.groupBox1.Controls.Add(this.rdbSim);
            this.groupBox1.Location = new System.Drawing.Point(34, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 263);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Mode";
            // 
            // rdbLog
            // 
            this.rdbLog.AutoSize = true;
            this.rdbLog.Location = new System.Drawing.Point(43, 196);
            this.rdbLog.Name = "rdbLog";
            this.rdbLog.Size = new System.Drawing.Size(171, 24);
            this.rdbLog.TabIndex = 2;
            this.rdbLog.TabStop = true;
            this.rdbLog.Text = "Fuji Control System";
            this.rdbLog.UseVisualStyleBackColor = true;
            // 
            // rdbHil
            // 
            this.rdbHil.AutoSize = true;
            this.rdbHil.Location = new System.Drawing.Point(43, 131);
            this.rdbHil.Name = "rdbHil";
            this.rdbHil.Size = new System.Drawing.Size(161, 24);
            this.rdbHil.TabIndex = 1;
            this.rdbHil.TabStop = true;
            this.rdbHil.Text = "Hardware In Loop";
            this.rdbHil.UseVisualStyleBackColor = true;
            // 
            // rdbSim
            // 
            this.rdbSim.AutoSize = true;
            this.rdbSim.Location = new System.Drawing.Point(43, 73);
            this.rdbSim.Name = "rdbSim";
            this.rdbSim.Size = new System.Drawing.Size(167, 24);
            this.rdbSim.TabIndex = 0;
            this.rdbSim.TabStop = true;
            this.rdbSim.Text = "PC Control System";
            this.rdbSim.UseVisualStyleBackColor = true;
            // 
            // txtDevName
            // 
            this.txtDevName.Location = new System.Drawing.Point(34, 328);
            this.txtDevName.Name = "txtDevName";
            this.txtDevName.Size = new System.Drawing.Size(114, 26);
            this.txtDevName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Choose NI Device Name IF (HIL OR FUJI MODE)";
            // 
            // frmStartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 454);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDevName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSubmit);
            this.Name = "frmStartUp";
            this.Text = "Control Application";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbLog;
        private System.Windows.Forms.RadioButton rdbHil;
        private System.Windows.Forms.RadioButton rdbSim;
        private System.Windows.Forms.TextBox txtDevName;
        private System.Windows.Forms.Label label1;
    }
}