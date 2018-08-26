namespace AE
{
    partial class outData
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.selectFile = new System.Windows.Forms.Button();
            this.BrowserPathTextBox = new System.Windows.Forms.TextBox();
            this.exportBT = new System.Windows.Forms.Button();
            this.txt = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 353);
            this.panel1.TabIndex = 0;
            // 
            // selectFile
            // 
            this.selectFile.Location = new System.Drawing.Point(430, 371);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(31, 23);
            this.selectFile.TabIndex = 1;
            this.selectFile.Text = "...";
            this.selectFile.UseVisualStyleBackColor = true;
            this.selectFile.Click += new System.EventHandler(this.selectFile_Click);
            // 
            // BrowserPathTextBox
            // 
            this.BrowserPathTextBox.Location = new System.Drawing.Point(127, 373);
            this.BrowserPathTextBox.Name = "BrowserPathTextBox";
            this.BrowserPathTextBox.Size = new System.Drawing.Size(297, 21);
            this.BrowserPathTextBox.TabIndex = 2;
            // 
            // exportBT
            // 
            this.exportBT.Location = new System.Drawing.Point(498, 371);
            this.exportBT.Name = "exportBT";
            this.exportBT.Size = new System.Drawing.Size(75, 23);
            this.exportBT.TabIndex = 3;
            this.exportBT.Text = "输出";
            this.exportBT.UseVisualStyleBackColor = true;
            this.exportBT.Click += new System.EventHandler(this.exportBT_Click);
            // 
            // txt
            // 
            this.txt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt.Location = new System.Drawing.Point(0, 0);
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt.Size = new System.Drawing.Size(699, 353);
            this.txt.TabIndex = 0;
            // 
            // outData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 406);
            this.Controls.Add(this.exportBT);
            this.Controls.Add(this.BrowserPathTextBox);
            this.Controls.Add(this.selectFile);
            this.Controls.Add(this.panel1);
            this.Name = "outData";
            this.Text = "报表输出";
            this.Load += new System.EventHandler(this.outData_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button selectFile;
        private System.Windows.Forms.TextBox BrowserPathTextBox;
        private System.Windows.Forms.Button exportBT;
        private System.Windows.Forms.TextBox txt;
    }
}