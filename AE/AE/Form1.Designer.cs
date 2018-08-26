using ESRI.ArcGIS.Carto;
namespace AE
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axPageLayoutControl1 = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.加载图像ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.加载图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.移除图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图形输出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按属性查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.按位置查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.分级设色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.获取质心ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.质心迁移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.反演模型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.三波段模型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.比值模型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.三波段栅格反演模型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间插值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDW空间差值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.clipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.制作统计图表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.添加shpe图层ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看属性表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axLicenseControl2 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(4, 5);
            this.axMapControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(1240, 617);
            this.axMapControl1.TabIndex = 0;
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            this.axMapControl1.OnViewRefreshed += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnViewRefreshedEventHandler(this.axMapControl1_OnViewRefreshed);
            this.axMapControl1.OnAfterScreenDraw += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnAfterScreenDrawEventHandler(this.axMapControl1_OnAfterScreenDraw);
            this.axMapControl1.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.axMapControl1_OnMapReplaced);
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(11, 26);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(1100, 28);
            this.axToolbarControl1.TabIndex = 2;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(597, -14);
            this.axLicenseControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 3;
            // 
            // axPageLayoutControl1
            // 
            this.axPageLayoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axPageLayoutControl1.Location = new System.Drawing.Point(6, 6);
            this.axPageLayoutControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.axPageLayoutControl1.Name = "axPageLayoutControl1";
            this.axPageLayoutControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPageLayoutControl1.OcxState")));
            this.axPageLayoutControl1.Size = new System.Drawing.Size(1843, 901);
            this.axPageLayoutControl1.TabIndex = 4;
            this.axPageLayoutControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IPageLayoutControlEvents_Ax_OnMouseDownEventHandler(this.axPageLayoutControl1_OnMouseDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 5);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1256, 659);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.axMapControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1248, 627);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "地图";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(882, 578);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(354, 28);
            this.textBox1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.axPageLayoutControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1248, 627);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "布局";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载图像ToolStripMenuItem1,
            this.查询ToolStripMenuItem,
            this.分级设色ToolStripMenuItem,
            this.反演模型ToolStripMenuItem,
            this.空间插值ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.统计ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1533, 32);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 加载图像ToolStripMenuItem1
            // 
            this.加载图像ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.加载图像ToolStripMenuItem,
            this.移除图像ToolStripMenuItem,
            this.加载文件ToolStripMenuItem,
            this.图形输出ToolStripMenuItem});
            this.加载图像ToolStripMenuItem1.Name = "加载图像ToolStripMenuItem1";
            this.加载图像ToolStripMenuItem1.Size = new System.Drawing.Size(58, 28);
            this.加载图像ToolStripMenuItem1.Text = "图像";
            this.加载图像ToolStripMenuItem1.Click += new System.EventHandler(this.加载图像ToolStripMenuItem1_Click);
            // 
            // 加载图像ToolStripMenuItem
            // 
            this.加载图像ToolStripMenuItem.Name = "加载图像ToolStripMenuItem";
            this.加载图像ToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.加载图像ToolStripMenuItem.Text = "加载图像";
            this.加载图像ToolStripMenuItem.Click += new System.EventHandler(this.加载图像ToolStripMenuItem_Click);
            // 
            // 移除图像ToolStripMenuItem
            // 
            this.移除图像ToolStripMenuItem.Name = "移除图像ToolStripMenuItem";
            this.移除图像ToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.移除图像ToolStripMenuItem.Text = "移除图像";
            this.移除图像ToolStripMenuItem.Click += new System.EventHandler(this.移除图像ToolStripMenuItem_Click);
            // 
            // 加载文件ToolStripMenuItem
            // 
            this.加载文件ToolStripMenuItem.Name = "加载文件ToolStripMenuItem";
            this.加载文件ToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.加载文件ToolStripMenuItem.Text = "加载高光谱文件";
            this.加载文件ToolStripMenuItem.Click += new System.EventHandler(this.加载高光谱文件ToolStripMenuItem_Click);
            // 
            // 图形输出ToolStripMenuItem
            // 
            this.图形输出ToolStripMenuItem.Name = "图形输出ToolStripMenuItem";
            this.图形输出ToolStripMenuItem.Size = new System.Drawing.Size(206, 28);
            this.图形输出ToolStripMenuItem.Text = "图形输出";
            this.图形输出ToolStripMenuItem.Click += new System.EventHandler(this.图形输出ToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.按属性查询ToolStripMenuItem,
            this.按位置查询ToolStripMenuItem});
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.查询ToolStripMenuItem.Text = "查询";
            // 
            // 按属性查询ToolStripMenuItem
            // 
            this.按属性查询ToolStripMenuItem.Name = "按属性查询ToolStripMenuItem";
            this.按属性查询ToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.按属性查询ToolStripMenuItem.Text = "按属性查询";
            // 
            // 按位置查询ToolStripMenuItem
            // 
            this.按位置查询ToolStripMenuItem.Name = "按位置查询ToolStripMenuItem";
            this.按位置查询ToolStripMenuItem.Size = new System.Drawing.Size(170, 28);
            this.按位置查询ToolStripMenuItem.Text = "按位置查询";
            // 
            // 分级设色ToolStripMenuItem
            // 
            this.分级设色ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.获取质心ToolStripMenuItem,
            this.质心迁移ToolStripMenuItem});
            this.分级设色ToolStripMenuItem.Name = "分级设色ToolStripMenuItem";
            this.分级设色ToolStripMenuItem.Size = new System.Drawing.Size(112, 28);
            this.分级设色ToolStripMenuItem.Text = "质心迁移图";
            // 
            // 获取质心ToolStripMenuItem
            // 
            this.获取质心ToolStripMenuItem.Name = "获取质心ToolStripMenuItem";
            this.获取质心ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.获取质心ToolStripMenuItem.Text = "获取质心";
            this.获取质心ToolStripMenuItem.Click += new System.EventHandler(this.获取质心ToolStripMenuItem_Click);
            // 
            // 质心迁移ToolStripMenuItem
            // 
            this.质心迁移ToolStripMenuItem.Name = "质心迁移ToolStripMenuItem";
            this.质心迁移ToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.质心迁移ToolStripMenuItem.Text = "质心迁移";
            this.质心迁移ToolStripMenuItem.Click += new System.EventHandler(this.质心迁移ToolStripMenuItem_Click);
            // 
            // 反演模型ToolStripMenuItem
            // 
            this.反演模型ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.三波段模型ToolStripMenuItem,
            this.比值模型ToolStripMenuItem,
            this.三波段栅格反演模型ToolStripMenuItem});
            this.反演模型ToolStripMenuItem.Name = "反演模型ToolStripMenuItem";
            this.反演模型ToolStripMenuItem.Size = new System.Drawing.Size(94, 28);
            this.反演模型ToolStripMenuItem.Text = "反演模型";
            // 
            // 三波段模型ToolStripMenuItem
            // 
            this.三波段模型ToolStripMenuItem.Name = "三波段模型ToolStripMenuItem";
            this.三波段模型ToolStripMenuItem.Size = new System.Drawing.Size(242, 28);
            this.三波段模型ToolStripMenuItem.Text = "三波段模型";
            this.三波段模型ToolStripMenuItem.Click += new System.EventHandler(this.三波段模型ToolStripMenuItem_Click);
            // 
            // 比值模型ToolStripMenuItem
            // 
            this.比值模型ToolStripMenuItem.Name = "比值模型ToolStripMenuItem";
            this.比值模型ToolStripMenuItem.Size = new System.Drawing.Size(242, 28);
            this.比值模型ToolStripMenuItem.Text = "比值模型";
            this.比值模型ToolStripMenuItem.Click += new System.EventHandler(this.比值模型ToolStripMenuItem_Click);
            // 
            // 三波段栅格反演模型ToolStripMenuItem
            // 
            this.三波段栅格反演模型ToolStripMenuItem.Name = "三波段栅格反演模型ToolStripMenuItem";
            this.三波段栅格反演模型ToolStripMenuItem.Size = new System.Drawing.Size(242, 28);
            this.三波段栅格反演模型ToolStripMenuItem.Text = "三波段栅格反演模型";
            this.三波段栅格反演模型ToolStripMenuItem.Click += new System.EventHandler(this.三波段栅格反演模型ToolStripMenuItem_Click);
            // 
            // 空间插值ToolStripMenuItem
            // 
            this.空间插值ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iDW空间差值ToolStripMenuItem});
            this.空间插值ToolStripMenuItem.Name = "空间插值ToolStripMenuItem";
            this.空间插值ToolStripMenuItem.Size = new System.Drawing.Size(94, 28);
            this.空间插值ToolStripMenuItem.Text = "空间插值";
            // 
            // iDW空间差值ToolStripMenuItem
            // 
            this.iDW空间差值ToolStripMenuItem.Name = "iDW空间差值ToolStripMenuItem";
            this.iDW空间差值ToolStripMenuItem.Size = new System.Drawing.Size(189, 28);
            this.iDW空间差值ToolStripMenuItem.Text = "IDW空间差值";
            this.iDW空间差值ToolStripMenuItem.Click += new System.EventHandler(this.iDW空间差值ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clipToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(58, 28);
            this.toolStripMenuItem2.Text = "裁剪";
            // 
            // clipToolStripMenuItem
            // 
            this.clipToolStripMenuItem.Name = "clipToolStripMenuItem";
            this.clipToolStripMenuItem.Size = new System.Drawing.Size(114, 28);
            this.clipToolStripMenuItem.Text = "Clip";
            this.clipToolStripMenuItem.Click += new System.EventHandler(this.clipToolStripMenuItem_Click);
            // 
            // 统计ToolStripMenuItem
            // 
            this.统计ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.制作统计图表ToolStripMenuItem});
            this.统计ToolStripMenuItem.Name = "统计ToolStripMenuItem";
            this.统计ToolStripMenuItem.Size = new System.Drawing.Size(58, 28);
            this.统计ToolStripMenuItem.Text = "统计";
            // 
            // 制作统计图表ToolStripMenuItem
            // 
            this.制作统计图表ToolStripMenuItem.Name = "制作统计图表ToolStripMenuItem";
            this.制作统计图表ToolStripMenuItem.Size = new System.Drawing.Size(188, 28);
            this.制作统计图表ToolStripMenuItem.Text = "制作统计图表";
            this.制作统计图表ToolStripMenuItem.Click += new System.EventHandler(this.制作统计图表ToolStripMenuItem_Click);
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.axTOCControl1.Location = new System.Drawing.Point(3, 7);
            this.axTOCControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(461, 979);
            this.axTOCControl1.TabIndex = 8;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            this.axTOCControl1.OnMouseUp += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseUpEventHandler(this.axTOCControl1_OnMouseUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(18, 103);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.axTOCControl1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1619, 667);
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.添加shpe图层ToolStripMenuItem,
            this.查看属性表ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(194, 88);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(193, 28);
            this.toolStripMenuItem1.Text = "删除";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 添加shpe图层ToolStripMenuItem
            // 
            this.添加shpe图层ToolStripMenuItem.Name = "添加shpe图层ToolStripMenuItem";
            this.添加shpe图层ToolStripMenuItem.Size = new System.Drawing.Size(193, 28);
            this.添加shpe图层ToolStripMenuItem.Text = "添加shpe图层";
            this.添加shpe图层ToolStripMenuItem.Click += new System.EventHandler(this.AddShapeLayerItem_Click);
            // 
            // 查看属性表ToolStripMenuItem
            // 
            this.查看属性表ToolStripMenuItem.Name = "查看属性表ToolStripMenuItem";
            this.查看属性表ToolStripMenuItem.Size = new System.Drawing.Size(193, 28);
            this.查看属性表ToolStripMenuItem.Text = "查看属性表";
            this.查看属性表ToolStripMenuItem.Click += new System.EventHandler(this.OpenLayerAttribItem_Click);
            // 
            // axLicenseControl2
            // 
            this.axLicenseControl2.Enabled = true;
            this.axLicenseControl2.Location = new System.Drawing.Point(752, 22);
            this.axLicenseControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.axLicenseControl2.Name = "axLicenseControl2";
            this.axLicenseControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl2.OcxState")));
            this.axLicenseControl2.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl2.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 821);
            this.Controls.Add(this.axLicenseControl2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axToolbarControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axPageLayoutControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl axPageLayoutControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 加载图像ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 分级设色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 反演模型ToolStripMenuItem;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem 加载图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 移除图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按属性查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 按位置查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 三波段模型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 比值模型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图形输出ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TextBox textBox1;
        private ILayer HitLayer;
        private IMap HitMap;
        private System.Windows.Forms.ToolStripMenuItem 添加shpe图层ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看属性表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 三波段栅格反演模型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间插值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iDW空间差值ToolStripMenuItem;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 获取质心ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 质心迁移ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 制作统计图表ToolStripMenuItem;
    }
}

