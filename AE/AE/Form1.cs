using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.DataSourcesFile;
using Microsoft.VisualBasic;
using ESRI.ArcGIS.GeoAnalyst;
using ESRI.ArcGIS.SpatialAnalyst;

namespace AE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mTOCControl = this.axTOCControl1.Object as ITOCControl;
            HitMap = null;
            HitLayer = null;
        }
        public ITOCControl mTOCControl;//toccontrol实例
        public ILayer pMoveLayer;//需要被调整的图层；
        public int toIndex;//将要调整到的目标图层的索引；
        ILayer selLayer;//定义选择图层
        IEnumDataset shpDatasets;
        public class GeoMapLoad
        {
            public static void CopyAndOverwriteMap(AxMapControl axMapControl, AxPageLayoutControl axPageLayoutControl)
            {
                IObjectCopy objectCopy = new ObjectCopyClass();
                object toCopyMap = axMapControl.Map;
                object copiedMap = objectCopy.Copy(toCopyMap);
                object overwriteMap = axPageLayoutControl.ActiveView.FocusMap;
                objectCopy.Overwrite(toCopyMap, ref overwriteMap);
            }
        }

        private void axMapControl1_OnAfterScreenDraw(object sender, IMapControlEvents2_OnAfterScreenDrawEvent e)
        {
            IActiveView pAcv = axPageLayoutControl1.ActiveView.FocusMap as IActiveView;
            IDisplayTransformation displayTransformation = pAcv.ScreenDisplay.DisplayTransformation;
            displayTransformation.VisibleBounds = axMapControl1.Extent;//设置焦点地图的可视范围
            axPageLayoutControl1.ActiveView.Refresh();
            GeoMapLoad.CopyAndOverwriteMap(axMapControl1, axPageLayoutControl1);

        }

        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            GeoMapLoad.CopyAndOverwriteMap(axMapControl1, axPageLayoutControl1);
        }

        private void axMapControl1_OnViewRefreshed(object sender, IMapControlEvents2_OnViewRefreshedEvent e)
        {
            //axTOCControl1.Update();
            //GeoMapLoad.CopyAndOverwriteMap(axMapControl1, axPageLayoutControl1);

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void axPageLayoutControl1_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        {

        }

        private void 专题图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //得到栅格图层对象并调用funColorForRaster_Classify（）方法进行分级设色
            if (axMapControl1.LayerCount > 0)
            {
                IRasterLayer pRasterLayer = null;
                for (int i = 0; i < axMapControl1.LayerCount; i++)
                {
                    if (axMapControl1.get_Layer(i) is IRasterLayer)
                        pRasterLayer = axMapControl1.get_Layer(i) as IRasterLayer;

                }
                if (pRasterLayer == null)
                {
                    MessageBox.Show("当前图层不存在栅格图层");
                    return;
                }
                int number = Convert.ToInt32(Interaction.InputBox("请输入栅格影像分类数量(默认为10)", "字符串", "", 500, 250));
                if (number == 0)
                    number = 10;
                funColorForRaster_Classify(pRasterLayer, number);

            }
            else
            {
                MessageBox.Show("请选择图层");
                return;
            }

        }
        public void funColorForRaster_Classify(IRasterLayer pRasterLayer, int number)
        {
            IRasterClassifyColorRampRenderer pRClassRend = new
            RasterClassifyColorRampRenderer() as IRasterClassifyColorRampRenderer;
            IRasterRenderer pRRend = pRClassRend as IRasterRenderer;
            IRaster pRaster = pRasterLayer.Raster;//栅格图层转换为栅格图
            IRasterBandCollection pRBandCol = pRaster as IRasterBandCollection;
            IRasterBand pRBand = pRBandCol.Item(0);
            if (pRBand.Histogram == null)
            {
                pRBand.ComputeStatsAndHist();
            }
            pRRend.Raster = pRaster;
            pRClassRend.ClassCount = number;//设置分级层次，默认为10
            pRRend.Update();
            //设置初始渐变色和结束渐变色
            MessageBox.Show("请选择初始颜色", "颜色选择", MessageBoxButtons.OK, MessageBoxIcon.Information);
            IRgbColor pFromColor = new RgbColor() as IRgbColor;
            selectColor(pFromColor);
            MessageBox.Show("请选择结束颜色", "颜色选择", MessageBoxButtons.OK, MessageBoxIcon.Information);
            IRgbColor pToColor = new RgbColor() as IRgbColor;
            selectColor(pToColor);
            IAlgorithmicColorRamp colorRamp = new AlgorithmicColorRamp() as
            IAlgorithmicColorRamp;
            colorRamp.Size = 10;
            colorRamp.FromColor = pFromColor;
            colorRamp.ToColor = pToColor;
            bool createColorRamp;
            colorRamp.CreateRamp(out createColorRamp);
            IFillSymbol fillSymbol = new SimpleFillSymbol() as IFillSymbol;
            for (int i = 0; i < pRClassRend.ClassCount; i++)
            {
                fillSymbol.Color = colorRamp.get_Color(i);
                pRClassRend.set_Symbol(i, fillSymbol as ISymbol);
                pRClassRend.set_Label(i,
                pRClassRend.get_Break(i).ToString("0.00"));
            }
            pRasterLayer.Renderer = pRRend;
            IActiveView activeview = this.axMapControl1.ActiveView;
            activeview.ContentsChanged();
            //刷新窗口
            activeview.PartialRefresh(esriViewDrawPhase.esriViewGeography, null,
            null);
        }

        //打开颜色选择对话框 并未IRGB类的三原色赋值
        private void selectColor(IRgbColor selColor)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = Color.Black;  //获取或设置用户所选定的颜色  
            colorDialog.ShowDialog();
            selColor.Red = colorDialog.Color.R;
            selColor.Green = colorDialog.Color.G;
            selColor.Blue = colorDialog.Color.B;
            MessageBox.Show("您选择的各颜色分量值分别为" + "\nR:" + colorDialog.Color.R.ToString()
                + "\nG:" + colorDialog.Color.G.ToString() + "\nB:" + colorDialog.Color.B.ToString());
        }

        public void funColorForRaster_Classify(IRasterLayer pRasterLayer)
        {
            IRasterClassifyColorRampRenderer pRClassRend = new
            RasterClassifyColorRampRenderer() as IRasterClassifyColorRampRenderer;
            IRasterRenderer pRRend = pRClassRend as IRasterRenderer;
            IRaster pRaster = pRasterLayer.Raster;//栅格图
            IRasterBandCollection pRBandCol = pRaster as IRasterBandCollection;
            IRasterBand pRBand = pRBandCol.Item(0);
            if (pRBand.Histogram == null)
            {
                pRBand.ComputeStatsAndHist();
            }
            pRRend.Raster = pRaster;
            pRClassRend.ClassCount = 10;
            pRRend.Update();
            IRgbColor pFromColor = new RgbColor() as IRgbColor;
            pFromColor.Red = 255;
            pFromColor.Green = 0;
            pFromColor.Blue = 0;
            IRgbColor pToColor = new RgbColor() as IRgbColor;
            pToColor.Red = 0;
            pToColor.Green = 0;
            pToColor.Blue = 255;
            IAlgorithmicColorRamp colorRamp = new AlgorithmicColorRamp() as
            IAlgorithmicColorRamp;
            colorRamp.Size = 10;
            colorRamp.FromColor = pFromColor;
            colorRamp.ToColor = pToColor;
            bool createColorRamp;
            colorRamp.CreateRamp(out createColorRamp);
            IFillSymbol fillSymbol = new SimpleFillSymbol() as IFillSymbol;
            for (int i = 0; i < pRClassRend.ClassCount; i++)
            {
                fillSymbol.Color = colorRamp.get_Color(i);
                pRClassRend.set_Symbol(i, fillSymbol as ISymbol);
                pRClassRend.set_Label(i,
                pRClassRend.get_Break(i).ToString("0.00"));
            }
            pRasterLayer.Renderer = pRRend;
            IActiveView activeview = this.axMapControl1.ActiveView;
            activeview.ContentsChanged();
            //刷新窗口
            activeview.PartialRefresh(esriViewDrawPhase.esriViewGeography, null,
            null);
        }

        private void 添加图例ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AxPageLayoutControl axPageLayout = new AxPageLayoutControl();
            this.InsertLegend(axPageLayout);
        }

        public void InsertLegend(AxPageLayoutControl axPageLayout)
        {
            //Get the GraphicsContainer
            IGraphicsContainer graphicsContainer =
            axPageLayoutControl1.GraphicsContainer;
            //Get the MapFrame
            IMapFrame mapFrame =
            (IMapFrame)graphicsContainer.FindFrame(axPageLayoutControl1.ActiveView.FocusMap);
            if (mapFrame == null) return;
            //Create a legend
            UID uID = new UIDClass();
            uID.Value = "esriCarto.Legend";
            IMapSurroundFrame mapSurroundFrame = mapFrame.CreateSurroundFrame(uID, null); if (mapSurroundFrame == null) return;
            if (mapSurroundFrame.MapSurround == null) return;
            mapSurroundFrame.MapSurround.Name = "Legend";
            IEnvelope envelope = new EnvelopeClass();
            envelope.PutCoords(1, 1, 3.4, 2.4);
            IElement element = (IElement)mapSurroundFrame;
            element.Geometry = envelope;
            axPageLayoutControl1.AddElement(element, Type.Missing, Type.Missing,
            "Legend", 0);
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null,
            null);
        }

        private void 加载图像ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 三波段模型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            threeModel tM = new threeModel();
            tM.Visible = true;
            
        }
        public static int num=1;
        private void 加载高光谱文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fullFilePath;
            OpenFileDialog openFile = new OpenFileDialog();
            //openFile.Filter = "数据集|datasets";
            openFile.Multiselect = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fullFilePath = openFile.FileName;
                //获得文件路径
                int index = fullFilePath.LastIndexOf("\\");
                string filePath = fullFilePath.Substring(0, index);
                //获得文件名称
                string fileName = fullFilePath.Substring(index + 1);
                IWorkspaceFactory workspcFac = new RasterWorkspaceFactory();
                IRasterWorkspace rasterWorkspc;
                IRasterDataset rasterDatset = new RasterDatasetClass();
                IRasterLayer rasterLay = new RasterLayerClass();
                rasterWorkspc = workspcFac.OpenFromFile(filePath, 0) as IRasterWorkspace;
                rasterDatset = rasterWorkspc.OpenRasterDataset(fileName);
                rasterLay.CreateFromDataset(rasterDatset);
                //axMapControl1.ClearLayers();
                rasterLay.Name =(num).ToString();
                num++;
                axMapControl1.AddLayer(rasterLay);
                axMapControl1.Refresh();
            }
        }

        private void 加载图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打开选择文件对话框用于选取图形文件
            string fullFilePath;  //存储打开文件的全路径
            //设置OpenFileDialog的属性，使其能打开多种类型文件
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = true;
            openFile.Filter = "shape文件(*.shp)|*.shp";
            openFile.Filter += "|栅格数据(*.jpg,*.bmp,*.tiff)|*.jpg;*.bmp;*.tiff;*.tif;*.img";
            openFile.Title = "打开文件";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fullFilePath = openFile.FileName;
                //获得文件路径
                int index = fullFilePath.LastIndexOf("\\");
                string filePath = fullFilePath.Substring(0, index);
                //获得文件名称
                string fileName = fullFilePath.Substring(index + 1);
                //加载shape文件
                if (openFile.FilterIndex == 1)
                {
                    //打开工作空间工厂
                    IWorkspaceFactory workspcFac = new ShapefileWorkspaceFactory();
                    IFeatureWorkspace featureWorkspc;
                    IFeatureLayer featureLay = new FeatureLayerClass();
                    //打开路径
                    featureWorkspc = workspcFac.OpenFromFile(filePath, 0) as IFeatureWorkspace;
                    //打开类要素
                    featureLay.FeatureClass = featureWorkspc.OpenFeatureClass(fileName);
                    featureLay.Name = fileName;
                    //添加图层
                    axMapControl1.AddLayer(featureLay);
                    axMapControl1.Refresh();

                }
                //加载栅格图像
                else if (openFile.FilterIndex == 2)
                {
                    IWorkspaceFactory workspcFac = new RasterWorkspaceFactory();
                    IRasterWorkspace rasterWorkspc;
                    IRasterDataset rasterDatset = new RasterDatasetClass();
                    IRasterLayer rasterLay = new RasterLayerClass();
                    rasterWorkspc = workspcFac.OpenFromFile(filePath, 0) as IRasterWorkspace;
                    rasterDatset = rasterWorkspc.OpenRasterDataset(fileName);
                    rasterLay.CreateFromDataset(rasterDatset);
                    axMapControl1.ClearLayers();
                    rasterLay.Name = fileName;
                    axMapControl1.AddLayer(rasterLay);
                    axMapControl1.Refresh();
                }
            }
        }


        private void 移除图像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (axMapControl1.LayerCount > 0)
            {
                //清空图层
                try
                {
                    axMapControl1.ClearLayers();
                    IActiveView activeview = this.axMapControl1.ActiveView;
                    activeview.ContentsChanged();
                    //刷新窗口
                    activeview.PartialRefresh(esriViewDrawPhase.esriViewGeography, null,
                    null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                MessageBox.Show("当前图层已经全部移出");
            }
            else
            {
                MessageBox.Show("当前视图已经没有图层");
                return;
            }
        }

        private void 图形输出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //打开输出文件窗口
            ExportMapForm exportPh = new ExportMapForm(axPageLayoutControl1);
            exportPh.Show();
            exportPh.Enabled = true;//设置该窗口可见
        }

        private void 添加指北针ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IActiveView pActiveView = axPageLayoutControl1.PageLayout as IActiveView;
            IMap pMap = pActiveView.FocusMap as IMap;
            IGraphicsContainer pGraphicsContainer = pActiveView as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pMap) as IMapFrame;
            IMapSurround pMapSurround;
            INorthArrow pNorthArrow;
            pNorthArrow = new MarkerNorthArrowClass();
            pMapSurround = pNorthArrow;
            pMapSurround.Name = "NorthArrow";
            //定义UID
            UID uid = new UIDClass();
            uid.Value = "esriCarto.MarkerNorthArrow";
            //定义MapSurroundFrame对象
            IMapSurroundFrame pMapSurroundFrame = pMapFrame.CreateSurroundFrame(uid, null);
            pMapSurroundFrame.MapSurround = pMapSurround;
            IElement pDeletElement = axPageLayoutControl1.FindElementByName("NorthArrow");//获取PageLayout中的图例元素
            if (pDeletElement != null)
            {
                pGraphicsContainer.DeleteElement(pDeletElement);  //如果已经存在指北针，删除已经存在的指北针
            }
            //定义Envelope设置Element摆放的位置
            IEnvelope pEnvelope = new EnvelopeClass();
            pEnvelope.PutCoords(16, 24, 21, 32);
            IElement pElement = pMapSurroundFrame as IElement;
            pElement.Geometry = pEnvelope;
            pGraphicsContainer.AddElement(pElement, 0);
            //刷新axPageLayoutControl1的内容
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void 添加比例尺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IActiveView pActiveView = axPageLayoutControl1.PageLayout as IActiveView;
            IMap pMap = pActiveView.FocusMap as IMap;
            IGraphicsContainer pGraphicsContainer = pActiveView as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pMap) as IMapFrame;
            IMapSurround pMapSurround;
            //设置比例尺样式
            IScaleBar pScaleBar = new ScaleLineClass();
            pScaleBar.Units = esriUnits.esriKilometers;
            pScaleBar.Divisions = 4;
            pScaleBar.Subdivisions = 3;
            pScaleBar.DivisionsBeforeZero = 0;
            pScaleBar.UnitLabel = "km";
            pScaleBar.LabelPosition = esriVertPosEnum.esriBelow;
            pScaleBar.LabelGap = 3.6;
            pScaleBar.LabelFrequency = esriScaleBarFrequency.esriScaleBarDivisionsAndFirstMidpoint;
            pScaleBar.LabelPosition = esriVertPosEnum.esriBelow;
            ITextSymbol pTextsymbol = new TextSymbolClass();
            pTextsymbol.Size = 1;
            stdole.StdFont pFont = new stdole.StdFont();
            pFont.Size = 3;
            pFont.Name = "Arial";
            pTextsymbol.Font = pFont as stdole.IFontDisp;
            pTextsymbol.HorizontalAlignment = esriTextHorizontalAlignment.esriTHALeft;
            pScaleBar.UnitLabelSymbol = pTextsymbol;
            pScaleBar.LabelSymbol = pTextsymbol;
            INumericFormat pNumericFormat = new NumericFormatClass();
            pNumericFormat.AlignmentWidth = 0;
            pNumericFormat.RoundingOption = esriRoundingOptionEnum.esriRoundNumberOfSignificantDigits;
            pNumericFormat.RoundingValue = 0;
            pNumericFormat.UseSeparator = true;
            pNumericFormat.ShowPlusSign = false;
            //定义UID
            pMapSurround = pScaleBar;
            pMapSurround.Name = "ScaleBar";
            UID uid = new UIDClass();
            uid.Value = "esriCarto.ScaleLine";
            //定义MapSurroundFrame对象
            IMapSurroundFrame pMapSurroundFrame = pMapFrame.CreateSurroundFrame(uid, null);
            pMapSurroundFrame.MapSurround = pMapSurround;
            //定义Envelope设置Element摆放的位置
            IEnvelope pEnvelope = new EnvelopeClass();
            pEnvelope.PutCoords(8, 5, 14, 7);
            IElement pElement = pMapSurroundFrame as IElement;
            pElement.Geometry = pEnvelope;
            IElement pDeletElement = axPageLayoutControl1.FindElementByName("ScaleBar");//获取PageLayout中的比例尺元素
            if (pDeletElement != null)
            {
                pGraphicsContainer.DeleteElement(pDeletElement);  //如果已经存在比例尺，删除已经存在的比例尺
            }
            pGraphicsContainer.AddElement(pElement, 0);
            //刷新axPageLayoutControl1的内容
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void 比例尺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteElement("ScaleBar");
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void 图例ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteElement("Legend");
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        private void 指北针ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteElement("NorthArrow");
            axPageLayoutControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        //删除布局视图上的地图元素
        public void deleteElement(string eleName)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("ScaleBar", "比例尺");
            dict.Add("Legend", "图例");
            dict.Add("NorthArrow", "指北针");
            IActiveView pActiveView = axPageLayoutControl1.PageLayout as IActiveView;
            IMap pMap = pActiveView.FocusMap as IMap;
            IGraphicsContainer pGraphicsContainer = pActiveView as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pMap) as IMapFrame;
            IElement pDeletElement = axPageLayoutControl1.FindElementByName(eleName);//获取PageLayout中的图例元素
            if (pDeletElement != null)
            {
                pGraphicsContainer.DeleteElement(pDeletElement);  //如果已经存在指北针，删除已经存在的指北针
            }
            else
            {
                MessageBox.Show("当前不存在" + dict[eleName]);
                return;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < axMapControl1.LayerCount; i++)
            {
                if (axMapControl1.get_Layer(i) == selLayer)
                    axMapControl1.DeleteLayer(i);
            }
            axMapControl1.ActiveView.Refresh();
        }

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (axMapControl1.LayerCount == 0)
                return;
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap map = null;
            ILayer layer = null;
            object other = null;
            object index = null;
            mTOCControl.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
            if (e.button == 1)
            {
                if (item == esriTOCControlItem.esriTOCControlItemLayer)
                {
                    if (layer is IAnnotationSublayer)
                    {
                        return;
                    }
                    else
                    {
                        pMoveLayer = layer;
                    }
                }

            }
            if (e.button == 2)
            {
                //弹出右键菜单   
                if (item == esriTOCControlItem.esriTOCControlItemMap)//判断是否点中map项目
                {
                    contextMenuStrip1.Show(axTOCControl1, e.x, e.y);
                    HitMap = map as IMap;
                }
                if (item == esriTOCControlItem.esriTOCControlItemLayer)
                {
                    contextMenuStrip1.Show(axTOCControl1, e.x, e.y);
                    selLayer = layer;
                    HitLayer = layer;
                }

            }
        }

        private void axTOCControl1_OnMouseUp(object sender, ITOCControlEvents_OnMouseUpEvent e)
        {
            if (e.button == 1)//判断是否为左键点击
            {
                esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap map = null;
                ILayer layer = null;
                object other = null;
                object index = null;
                mTOCControl.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
                IMap pMap = this.axMapControl1.ActiveView.FocusMap;
                if (item == esriTOCControlItem.esriTOCControlItemLayer || layer != null)
                {
                    if (pMoveLayer != null)
                    {
                        ILayer pTempLayer;
                        for (int i = 0; i < pMap.LayerCount; i++)
                        {
                            pTempLayer = pMap.get_Layer(i);
                            if (pTempLayer == layer)
                            {
                                toIndex = i;
                            }
                        }
                        pMap.MoveLayer(pMoveLayer, toIndex);
                        axMapControl1.ActiveView.Refresh();
                        mTOCControl.Update();//更新tocControl空间
                    }
                }
            }
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            textBox1.Text = String.Format("X:" + e.mapX + "\t" + "Y:" + e.mapY);//显示当前鼠标指向的地图坐标
        }

        private void AddShapeLayerItem_Click(object sender, EventArgs e)
        {
            // OpenFileDialog 类用于创建“打开文件”对话框，它是 C#中的标准控件。 
            OpenFileDialog OpenShapeDlg = new OpenFileDialog(); 
            // 设置打开文件的类型过滤规则为：仅打开*.shp 文件。 
            OpenShapeDlg.Filter = "shp files (*.shp)|*.shp"; 
            // 其他参数设置。 
            OpenShapeDlg.FilterIndex = 1; OpenShapeDlg.RestoreDirectory = true; 
            // 显示“打开文件”对话框，返回值为 DialogResult.OK 表示点击了“确定”按钮。 
            if (OpenShapeDlg.ShowDialog() == DialogResult.OK)
            {
                // OpenFileDialog 类的 FileName 属性存储了选中文件的完整路径名， 
                string strWorkspace = System.IO.Path.GetDirectoryName(OpenShapeDlg.FileName);
                // 利用 System.IO 库中 Path 类的 GetFileNameWithoutExtension 方法可以解析出 
                string strLayerName = System.IO.Path.GetFileNameWithoutExtension(OpenShapeDlg.FileName);
                // 实例化一个 ShapefileWorkspaceFactory 组件对象， 
                IWorkspaceFactory wsFactory = new ShapefileWorkspaceFactory();
                // 调用 OpenFromFile 通过目录名方法打开 Shapefile 数据库。 
                IWorkspace shpWorkspace = wsFactory.OpenFromFile(strWorkspace, 0);
                if (shpWorkspace != null)
                {
                    shpDatasets = shpWorkspace.get_Datasets(esriDatasetType.esriDTFeatureClass);
                    // 首先利用 Reset 方法将元素定位器重置到起始位置。 
                    shpDatasets.Reset();
                    // 调用 Next 方法获取其中的第一个数据集对象，并将定位器后移一位 
                    IDataset shpDataset = shpDatasets.Next();
                    // 循环访问 Datasets 中的每一个数据集对象，shpDataset 为 null 表示循环结束。
                    while (shpDataset != null)
                    {
                        if (shpDataset.Name == strLayerName)
                        {
                            IFeatureLayer newLayer = new FeatureLayerClass();
                            newLayer.FeatureClass = shpDataset as IFeatureClass;
                            newLayer.Name = strLayerName;
                            axMapControl1.Map.AddLayer(newLayer);
                            break;
                        }
                        shpDataset = shpDatasets.Next();
                    }
                }
            }
        }

        private void OpenLayerAttribItem_Click(object sender, EventArgs e)
        {
            // 创建“打开属性表”对话框的实例 
            LayerAttrib AttribData = new LayerAttrib();
            // 显示对话框 
            AttribData.Enabled = true;
            AttribData.Show();
            // 在对话框的 DataGridView 控件内显示选中图层的属性字段信息 
            AttribData.ShowFeatureLayerAttrib(HitLayer as IFeatureLayer);
            // 将保存的选中图层变量置为 null，避免以后的操作中出现混乱 
            HitLayer = null;
        }

        private void 比值模型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ratioModel rm = new ratioModel();
            rm.Visible = true;
        }

        private void 三波段栅格反演模型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string outRasterPath = "";
            //try
            //{
            //    //输出路径和名称
            //    int iindx = outRasterPath.LastIndexOf("\\");
            //    //输出raster的名称
            //    string suffixRasterName = (outRasterPath.Substring(iindx + 1));
            //    //输出raster的路径（无名称）
            //    string rasterPath = outRasterPath.Remove(iindx);
            //    //得到raster
            //    IRaster raster = GetRaster(inClipRaster);
            //    //控制地图代数的操作
            //    IMapAlgebraOp mapAlgebraOp = new RasterMapAlgebraOpClass();
            //    //控制raster分析的环境
            //    IRasterAnalysisEnvironment rasterAnalysisEnvironment = default(IRasterAnalysisEnvironment);
            //    rasterAnalysisEnvironment = (IRasterAnalysisEnvironment)mapAlgebraOp;
            //    //设置工作空间
            //    IWorkspaceFactory workspaceFactory = new RasterWorkspaceFactoryClass();
            //    IWorkspace workspace = workspaceFactory.OpenFromFile(rasterPath, 0);//这里应该是输出raster的路径
            //    rasterAnalysisEnvironment.OutWorkspace = workspace;
            //    //在地理数据集中绑定栅格数据
            //    //GeoDataset可以是输入的raster、rasterDataset、RasterBand、RasterDescriptor；clipRaster应该是要修改的栅格数据的名称（string），（这里我的名称是固定的clipRaster）



            //    mapAlgebraOp.BindRaster((IGeoDataset)raster, "clipRaster");
            //    //定义表达式（elevationMode为要减去的数值）不要忘了"[ ]"
            //    string strOut = "[clipRaster] " + " -  " + elevationMode;
            //    //执行表达式
            //    IRaster outRaster = (IRaster)mapAlgebraOp.Execute(strOut);
            //    //保存 
            //    ISaveAs2 saveAs;
            //    saveAs = (ISaveAs2)outRaster;
            //    saveAs.SaveAs(suffixRasterName, workspace, "TIFF");//输出名称(注意：名称中加后缀名，例：test.tif)，工作空间，格式
            //    MessageBox.Show("栅格计算器成功！");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("栅格计算器失败！");
            //    Console.WriteLine(ex.Message);
            //}
        }

        private void iDW空间差值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //用反距离IDW插值生成的栅格图像
            IInterpolationOp pInterpolationOp= new RasterInterpolationOpClass();

            // 输入点图层
            IFeatureClass pFeatureClass;
            IFeatureLayer pFeaturelayer;
            int indexLayer = Convert.ToInt32(Interaction.InputBox("请输入IDW空间插值点图层下标", "字符串", "", 500, 250));
            pFeaturelayer = this.axMapControl1.Map.get_Layer(indexLayer) as IFeatureLayer;
            pFeatureClass = pFeaturelayer.FeatureClass;

            // Define the search radius
            IRasterRadius pRadius= new RasterRadiusClass();
            object maxDistance = Type.Missing;
            pRadius.SetVariable(12, ref maxDistance);

            //Create FeatureClassDescriptor using a value field
            IFeatureClassDescriptor pFCDescriptor= new FeatureClassDescriptorClass();
            string zValue = Interaction.InputBox("请输入特征字段(yelvsuA/FYyelvsuA)", "字符串", "", 500, 250);
            pFCDescriptor.Create(pFeatureClass, null, zValue);

            //set { cellsize for output raster in the environment
            object dCellSize = 113.039027413432;
            IRasterAnalysisEnvironment pEnv= new RasterAnalysis();
            pEnv = pInterpolationOp as IRasterAnalysisEnvironment;
            pEnv.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref dCellSize);
            object objectbarrier = Type.Missing;

            //Perform the interpolation
            IGeoDataset rasDataset= pInterpolationOp.IDW((IGeoDataset)pFCDescriptor, 2, pRadius, ref objectbarrier);
            IRaster pOutRaster= rasDataset as IRaster;

            //Add output into ArcMap as a raster layer
            IRasterLayer pOutRasLayer=new RasterLayerClass();
            pOutRasLayer.CreateFromRaster(pOutRaster);
            this.axMapControl1.AddLayer(pOutRasLayer, 0);
            axMapControl1.ActiveView.Refresh();

            DialogResult dr = MessageBox.Show("插值成功,请选择是否进行分级渲染", "分级渲染选择",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                //用户选择确认的操作（分级渲染）
                IRasterLayer pRasterLayer = null;
                for (int i = 0; i < axMapControl1.LayerCount; i++)
                {
                    if (axMapControl1.get_Layer(i) is IRasterLayer)
                        pRasterLayer = axMapControl1.get_Layer(i) as IRasterLayer;

                }
                if (pRasterLayer == null)
                {
                    MessageBox.Show("当前图层不存在栅格图层");
                    return;
                }
                int number = Convert.ToInt32(Interaction.InputBox("请输入栅格影像分类数量(默认为10)", "字符串", "", 500, 250));
                if (number == 0)
                    number = 10;
                funColorForRaster_Classify(pRasterLayer, number);
                axMapControl1.ActiveView.Refresh();

            }
            else if (dr == DialogResult.Cancel)
            {
                //用户选择取消的操作
                return;

            }
        }

        //裁剪
        private IRaster ShpLayerClipRaster(IFeatureLayer featureLayer, IRaster raster)
        {
            IFeatureLayer pFeaLyr;
            IRasterAnalysisEnvironment pEnv;
            IGeoDataset pTempDS;

            pFeaLyr = featureLayer;
            pTempDS = pFeaLyr.FeatureClass as IGeoDataset;
            IConversionOp pConOp = new RasterConversionOpClass();
            pEnv = pConOp as IRasterAnalysisEnvironment;

            IRasterProps pProp= raster as IRasterProps;
            object cellSize = 0.01;
            pEnv.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref cellSize);
            IRasterConvertHelper rsh = new RasterConvertHelperClass();

            IRaster tempRaster= rsh.ToRaster1(pTempDS, "Grid", pEnv);


            IRaster pOutRaster;
            IExtractionOp pExtrOp = new RasterExtractionOpClass();
            pOutRaster = (IRaster)pExtrOp.Raster((IGeoDataset)raster, (IGeoDataset)tempRaster);

            
            return pOutRaster;
        }

        private void clipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFeatureLayer pFeaturelayer;
            IRasterLayer inRasterlayer;
            int indexLayer = Convert.ToInt32(Interaction.InputBox("请输入裁剪边界的矢量(.shp)图层下标", "字符串", "", 500, 250));
            pFeaturelayer = this.axMapControl1.Map.get_Layer(indexLayer) as IFeatureLayer;

            int indexRater = Convert.ToInt32(Interaction.InputBox("请输入需要裁剪的栅格图层下标", "字符串", "", 500, 250));
            inRasterlayer = this.axMapControl1.Map.get_Layer(indexRater) as IRasterLayer;
            IRaster inRaster = inRasterlayer.Raster;
            IRaster outRaster;
            //outRaster = this.ShpLayerClipRaster(pFeaturelayer, inRaster);//方法1

            IFeatureClass pFeatureClass = pFeaturelayer.FeatureClass;
            IPolygon pPolygon = (pFeatureClass.GetFeature(0)).Shape as IPolygon;
            outRaster = RasterClip(inRasterlayer, pPolygon);//方法2


            //Add output into ArcMap as a raster layer
            IRasterLayer pOutRasLayer = new RasterLayerClass();
            pOutRasLayer.CreateFromRaster(outRaster);
            this.axMapControl1.AddLayer(pOutRasLayer, 0);
            axMapControl1.ActiveView.Refresh();
        }

        private IRaster RasterClip(IRasterLayer pRasterLayer, IPolygon clipGeo)
        {
            if (clipGeo == null) return null;

            IRaster clipRaster = null;

            IRaster pRaster = pRasterLayer.Raster;
            IRasterProps pProps = pRaster as IRasterProps;
            object cellSizeProvider = pProps.MeanCellSize().X;
            IGeoDataset pInputDataset = pRaster as IGeoDataset;
            IExtractionOp pExtractionOp = new RasterExtractionOpClass();
            IRasterAnalysisEnvironment pRasterAnaEnvir = pExtractionOp as IRasterAnalysisEnvironment;
            pRasterAnaEnvir.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref cellSizeProvider);
            object extentProvider = clipGeo.Envelope;
            object snapRasterData = Type.Missing;
            pRasterAnaEnvir.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue, ref extentProvider, ref snapRasterData);
            IGeoDataset pOutputDataset = pExtractionOp.Polygon(pInputDataset, clipGeo as IPolygon, true);

            if (pOutputDataset is IRasterLayer)
            {
                IRasterLayer rasterLayer = pOutputDataset as IRasterLayer;
                clipRaster = rasterLayer.Raster;
            }
            else if (pOutputDataset is IRasterDataset)
            {
                IRasterDataset rasterDataset = pOutputDataset as IRasterDataset;
                clipRaster = rasterDataset.CreateDefaultRaster();
            }
            else if (pOutputDataset is IRaster)
            {
                clipRaster = pOutputDataset as IRaster;
            }

            return clipRaster;
        }

        private void 获取质心ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("sss");
            Console.WriteLine("sss");
        }

        private void 质心迁移ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}
