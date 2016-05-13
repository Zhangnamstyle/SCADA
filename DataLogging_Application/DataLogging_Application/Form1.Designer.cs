namespace DataLogging_Application
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnRead = new System.Windows.Forms.Button();
            this.txtBxOpcVal = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(24, 52);
            this.btnRead.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(112, 35);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "Start";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBxOpcVal
            // 
            this.txtBxOpcVal.Location = new System.Drawing.Point(187, 52);
            this.txtBxOpcVal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBxOpcVal.Multiline = true;
            this.txtBxOpcVal.Name = "txtBxOpcVal";
            this.txtBxOpcVal.Size = new System.Drawing.Size(331, 130);
            this.txtBxOpcVal.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 378);
            this.Controls.Add(this.txtBxOpcVal);
            this.Controls.Add(this.btnRead);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox txtBxOpcVal;
        private System.Windows.Forms.Timer timer1;
    }
}

