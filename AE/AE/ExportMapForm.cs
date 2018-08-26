using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;


namespace AE
{
    public partial class ExportMapForm : Form
    {
        AxPageLayoutControl m_Map;//新建axPageLayoutControl变量
        public ExportMapForm(AxPageLayoutControl m_Map)
        {
            InitializeComponent();
            this.m_Map = m_Map;//通过参数传递将主界面的axPageLayoutControl传递给m_Map
            this.Text = "图层输出";

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //创建保存文件对话框的实例
            SaveFileDialog SaveFile = new SaveFileDialog();
            //根据掩码文本框对对话框初始化
            switch (comboBox1.SelectedIndex)
            {     
                case 0:
                    SaveFile.Filter = "bmp文件(*.bmp)|*.bmp";
                    SaveFile.Title = "保存bmb文件";
                    break;
                case 1:
                    SaveFile.Filter = "emf文件(*.emf)|*.emf";
                    SaveFile.Title = "保存emp文件";
                    break;
                case 2:
                    SaveFile.Filter = "gif文件(*.gif)|*.gif";
                    SaveFile.Title = "保存gif文件";
                    break;
                case 3:
                    SaveFile.Filter = "jpg文件(*.jpeg)|*.jpeg";
                    SaveFile.Title = "保存jpg文件";
                    break;
                case 4:
                    SaveFile.Filter = "PNG文件(*.png)|*.png";
                    SaveFile.Title = "保存png文件";
                    break;
                case 5:
                    SaveFile.Filter = "TIFF文件(*.TIFF)|*.TIFF";
                    SaveFile.Title = "保存tiff文件";
                    break;
                case 6:
                    SaveFile.Filter = "PDF文件(*.PDF)|*.pdf";
                    SaveFile.Title = "保存pdf文件";
                    break;
            }
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                //打开保存文件对话框 并选择路径和文件名
                SaveFile.AddExtension = true;//设置为自动补充文件扩展名
                IExport pExport;
                switch (comboBox1.SelectedIndex)//根据掩码文本框的索引值穿件不同的pExport实例并调用Export方法
                {
                    case 0:
                        pExport = new ExportBMPClass();
                        Export(pExport, SaveFile.FileName);
                        break;
                    case 1:
                        pExport = new ExportEMFClass();
                        Export(pExport, SaveFile.FileName);
                        break;
                    case 2:
                        pExport = new ExportGIFClass();
                        Export(pExport, SaveFile.FileName);
                        break;
                    case 3:
                        pExport = new ExportJPEGClass();
                        Export(pExport, SaveFile.FileName);
                        break;
                    case 4:
                        pExport = new ExportPNGClass();
                        Export(pExport, SaveFile.FileName);
                        break;
                    case 5:
                        pExport = new ExportTIFFClass();
                        Export(pExport, SaveFile.FileName);
                        break;
                    case 6:
                        pExport = new ExportPDFClass();
                        Export(pExport, SaveFile.FileName);
                        break;

                }
               
            }
            
        }
        //输出文件
        public void Export(IExport pExport,string path)
        {
            IActiveView pActiveView;
            IEnvelope pPixelBoundsEnv;
            int iOutputResolution;
            int iScreenResolution;
            int hdc;
            pActiveView = m_Map.ActiveView;
            pExport.ExportFileName =path ;
            iScreenResolution = 96;
            iOutputResolution = 300;
            pExport.Resolution = iOutputResolution;
            tagRECT pExportFrame;
            pExportFrame = pActiveView.ExportFrame;
            tagRECT exportRECT;
            exportRECT.left = 0;
            exportRECT.top = 0;
            exportRECT.right = pActiveView.ExportFrame.right * (iOutputResolution / iScreenResolution);
            exportRECT.bottom = pActiveView.ExportFrame.bottom * (iOutputResolution / iScreenResolution);
            pPixelBoundsEnv = new EnvelopeClass();
            pPixelBoundsEnv.PutCoords(exportRECT.left, exportRECT.top, exportRECT.right, exportRECT.bottom);
            pExport.PixelBounds = pPixelBoundsEnv;
            hdc = pExport.StartExporting();
            pActiveView.Output(hdc, (int)pExport.Resolution, ref exportRECT, null, null);
            pExport.FinishExporting();
            pExport.Cleanup();
            MessageBox.Show("输出文件完成");
        }

        private void ExportMapForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
