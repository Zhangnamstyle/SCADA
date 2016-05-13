namespace Alarm_Application
{
    partial class frmAlarmLog
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
            this.dgvAlarmLog = new System.Windows.Forms.DataGridView();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmLog)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlarmLog
            // 
            this.dgvAlarmLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlarmLog.Location = new System.Drawing.Point(-1, 0);
            this.dgvAlarmLog.Name = "dgvAlarmLog";
            this.dgvAlarmLog.Size = new System.Drawing.Size(1029, 476);
            this.dgvAlarmLog.TabIndex = 0;
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 5000;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // frmAlarmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 472);
            this.Controls.Add(this.dgvAlarmLog);
            this.Name = "frmAlarmLog";
            this.Text = "Alarm History";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAlarmLog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlarmLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlarmLog;
        private System.Windows.Forms.Timer tmrUpdate;
    }
}