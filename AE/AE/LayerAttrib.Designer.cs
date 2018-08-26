namespace AE
{
    partial class LayerAttrib
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayerAttrib));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWhereClause = new System.Windows.Forms.TextBox();
            this.btAttribSearch = new System.Windows.Forms.Button();
            this.btBoxSearch = new System.Windows.Forms.Button();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 14);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(520, 302);
            this.dataGridView1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(23, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "属性过滤条件：";
            // 
            // txtWhereClause
            // 
            this.txtWhereClause.Location = new System.Drawing.Point(173, 351);
            this.txtWhereClause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtWhereClause.Name = "txtWhereClause";
            this.txtWhereClause.Size = new System.Drawing.Size(151, 25);
            this.txtWhereClause.TabIndex = 6;
            //this.txtWhereClause.TextChanged += new System.EventHandler(this.txtWhereClause_TextChanged);
            // 
            // btAttribSearch
            // 
            this.btAttribSearch.Location = new System.Drawing.Point(331, 349);
            this.btAttribSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btAttribSearch.Name = "btAttribSearch";
            this.btAttribSearch.Size = new System.Drawing.Size(91, 28);
            this.btAttribSearch.TabIndex = 8;
            this.btAttribSearch.Text = "查询";
            this.btAttribSearch.UseVisualStyleBackColor = true;
            this.btAttribSearch.Click += new System.EventHandler(this.btAttribSearch_Click);
            // 
            // btBoxSearch
            // 
            this.btBoxSearch.Location = new System.Drawing.Point(427, 350);
            this.btBoxSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btBoxSearch.Name = "btBoxSearch";
            this.btBoxSearch.Size = new System.Drawing.Size(91, 28);
            this.btBoxSearch.TabIndex = 9;
            this.btBoxSearch.Text = "框选";
            this.btBoxSearch.UseVisualStyleBackColor = true;
            this.btBoxSearch.Click += new System.EventHandler(this.btBoxSearch_Click);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(951, 25);
            this.axLicenseControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 10;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(449, 360);
            this.axMapControl1.TabIndex = 11;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.axMapControl1);
            this.panel1.Location = new System.Drawing.Point(565, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 360);
            this.panel1.TabIndex = 12;
            // 
            // LayerAttrib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 411);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.btBoxSearch);
            this.Controls.Add(this.btAttribSearch);
            this.Controls.Add(this.txtWhereClause);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LayerAttrib";
            this.Text = "属性表";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWhereClause;
        private System.Windows.Forms.Button btAttribSearch;
        private System.Windows.Forms.Button btBoxSearch;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.Panel panel1;
    }
}