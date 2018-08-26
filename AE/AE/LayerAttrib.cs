using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;

namespace AE
{
    public partial class LayerAttrib : Form
    {
        public LayerAttrib()
        {
            InitializeComponent();
        }
        int nSpatialSearchMode;
        string strFieldName;
        public void ShowFeatureLayerAttrib(IFeatureLayer layer)
        {
            if (layer != null)
            {
                // 将目标图层显示在对话框的 MapControl 控件窗口中 
                axMapControl1.ClearLayers();
                axMapControl1.AddLayer(layer);
                // 创建一个DataTable 对象用于显示图层要素的属性表         
                DataTable FeatureTable = new DataTable(layer.Name);
                // 获取矢量要素图层包含的要素类         
                IFeatureClass fcLayer = layer.FeatureClass;
                // 获取要素类中包含的属性字段总数         
                int nFieldCount = fcLayer.Fields.FieldCount;
                // 分别按照每一个属性字段信息在 DataTable 对象中创建相应的列         
                for (int i = 0; i < nFieldCount; i++)
                {
                    // 创建一个新的列（用于添加到 DataTable 对象中）
                    DataColumn Field = new DataColumn();
                    // 列名设置为属性字段的名称                       
                    Field.ColumnName = fcLayer.Fields.get_Field(i).Name;
                    // 根据属性字段值的类型设置 DataTable 对象中相应列的值类型             
                    switch (fcLayer.Fields.get_Field(i).Type)
                    {
                        // 利用 switch…case…结构将新列的值类型与要素类属性字段的值类型一一对应                     
                        case esriFieldType.esriFieldTypeOID: Field.DataType = System.Type.GetType("System.Int32");
                            break;
                        case esriFieldType.esriFieldTypeGeometry:
                            Field.DataType = System.Type.GetType("System.String");
                            break;
                        case esriFieldType.esriFieldTypeInteger:
                            Field.DataType = System.Type.GetType("System.Int32");
                            break;
                        case esriFieldType.esriFieldTypeSingle:
                            Field.DataType = System.Type.GetType("System.Int32");
                            break;
                        case esriFieldType.esriFieldTypeSmallInteger:
                            Field.DataType = System.Type.GetType("System.Int32");
                            break;
                        case esriFieldType.esriFieldTypeString:
                            Field.DataType = System.Type.GetType("System.String");
                            break;
                        case esriFieldType.esriFieldTypeDouble:
                            Field.DataType = System.Type.GetType("System.Double");
                            break;
                    }
                    // 将创建的新列加入到 DataTable 对象中 
                    FeatureTable.Columns.Add(Field);
                }
                // 将 DataTable 对象作为 DataGridView 控件的数据源         
                dataGridView1.DataSource = FeatureTable;
                // ShowFeatures 函数在 DataGridView 控件中显示所有要素的属性数据         
                ShowFeatures(layer, null, false);
            }
            else
            {
                dataGridView1.Columns.Clear();
            }
        }

        public void ShowFeatures(IFeatureLayer featurelayer, IQueryFilter condition, bool drawshape)
        {
            if (featurelayer != null)
            {
                // 获取矢量要素图层关联的要素类 
                IFeatureClass featureclass = featurelayer.FeatureClass;
                //定义一个 IFeatureCursor 变量用于获取查询结果         
                IFeatureCursor cursor = null;
                // 此处使用的 try…catch…语法用于捕获异常          
                try
                {
                    cursor = featureclass.Search(condition, false);
                }
                catch (Exception)
                {
                    // 如果 Search 方法产生了异常，将查询结果集游标置为null 
                    cursor = null;
                }
                if (cursor != null)
                {
                    // 第一次地图重绘请求             
                    axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, Type.Missing, Type.Missing);
                    IFeatureSelection fselection = featurelayer as IFeatureSelection;
                    //清空原先的选择集 
                    fselection.Clear();
                    // 获取 DataGridView 控件中的数据表             
                    DataTable FeatureTable = (DataTable)dataGridView1.DataSource;
                    // 清空表中原有的行             
                    FeatureTable.Rows.Clear();
                    // 通过游标获取要素查询结果集中的第一个要素 
                    IFeature feature = cursor.NextFeature();
                    // 循环获取每一个要素，直到游标到达结果集的结束位             
                    while (feature != null)
                    {
                        // 如果需要高亮显示查询结果，将查询到的要素加入选择集 
                        if (drawshape) fselection.Add(feature);
                        // 创建一个新的行在 DataGridView 的数据表中添加数据 
                        DataRow FeatureRec = FeatureTable.NewRow();
                        int nFieldCount = feature.Fields.FieldCount;
                        //依次读取矢量要素的每一个字段值 
                        for (int i = 0; i < nFieldCount; i++)
                        {                
                            // 转换矢量要素的各个属性值 ，并将值写入新建数据行的对应列中                                       
                            switch (feature.Fields.get_Field(i).Type)
                            {
                                //注意：第一个 FID 字段的值类型为 OID 类型 
                                case esriFieldType.esriFieldTypeOID: FeatureRec[feature.Fields.get_Field(i).Name] 
                                    = Convert.ToInt32(feature.get_Value(i));
                                    break;
                                case esriFieldType.esriFieldTypeInteger: FeatureRec[feature.Fields.get_Field(i).Name] 
                                    = Convert.ToInt32(feature.get_Value(i));
                                    break;
                                case esriFieldType.esriFieldTypeString: FeatureRec[feature.Fields.get_Field(i).Name] 
                                    = feature.get_Value(i).ToString();
                                    break;
                                case esriFieldType.esriFieldTypeDouble: FeatureRec[feature.Fields.get_Field(i).Name] 
                                    = Convert.ToDouble(feature.get_Value(i));
                                    break;
                            }
                        }
                        //将填充了数据的新行加入到 DataGridView 的数据表中 
                        FeatureTable.Rows.Add(FeatureRec);
                        // 获取下一个要素                 
                        feature = cursor.NextFeature();
                    }
                    //第二次调用地图重绘，执行高亮显示。             
                    if (drawshape)
                        axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, Type.Missing, Type.Missing);
                }
            }
        }

        private void btAttribSearch_Click(object sender, EventArgs e)
        {
            // 该图层就是用于数据操作的目标图层。 
            IFeatureLayer fLayer = axMapControl1.get_Layer(0) as IFeatureLayer;
            if (fLayer != null)
            {
                //创建一个 QueryFilter 组件对象         
                IQueryFilter filter = new QueryFilterClass();
                // 设置 WhereClause         
                filter.WhereClause = txtWhereClause.Text;
                // 调用 ShowFeatures 方法进行查询和显示，在 ShowFeatures 方法中使用的 try…catch…语法进行异常处理                       
                ShowFeatures(fLayer, filter, true);
            }
        }

        private void btBoxSearch_Click(object sender, EventArgs e)
        {
            // 自定义“= 1”表示“框选”状态 
            nSpatialSearchMode = 1;
        }
        private void axMapControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            // 为了程序的拓展性，选择 switch…case…结构判断操作模式 
            switch (nSpatialSearchMode)
            {
                case 1:
                    // 矩形框选模式 ， 通过鼠标拖动创建矩形框    
                    IEnvelope box = axMapControl1.TrackRectangle();
                    // 获取空间查询的目标图层 
                    IFeatureLayer fLayer = axMapControl1.get_Layer(0) as IFeatureLayer;
                    if (fLayer != null)
                    {
                        // 创建一个 SpatialFilter 组件对象 
                        ISpatialFilter filter = new SpatialFilterClass();
                        // 设置属性过滤条件             
                        filter.WhereClause = txtWhereClause.Text;
                        // 设置空间查询的参考几何体为鼠标拖出的矩形框             
                        filter.Geometry = box;
                        // 设置空间关系（本例中是相交关系） 
                        filter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                        // 利用 ShowFeatures 方法查询并显示矢量要素             
                        ShowFeatures(fLayer, filter, true);
                    }
                    // 退出“框选”模式         
                    nSpatialSearchMode = -1;
                    break;
            }
        }

    }
}
