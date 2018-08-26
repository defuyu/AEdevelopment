using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AE
{
    public partial class outData : Form
    {
        public outData()
        {
            InitializeComponent();
        }

        //声明
        string filePath;
        

        //选择文件路径
        private void selectFile_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.BrowserPathTextBox.Text = folderBrowserDialog.SelectedPath;
                filePath = folderBrowserDialog.SelectedPath;
            }     
        }

        private void exportBT_Click(object sender, EventArgs e)
        {
            if (BrowserPathTextBox.Text.Equals(""))
                MessageBox.Show("请选择路径！");
            else {
                FileStream fs1 = new FileStream(filePath+"/out.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs1);
                sw.Write(txt.Text);
                sw.Close();
                MessageBox.Show("输出成功！");
            }
        }

        private void outData_Load(object sender, EventArgs e)
        {
            if (threeModel.mrk)
            {
                txt.Text = "三波段模型\r\n线性回归方程为：Y=" + threeModel.K + "X+" + threeModel.B + ",pearson相关系数为:" +
                     threeModel.p + "\tspearman相关系数为:" + threeModel.q + "\r\n";
                txt.AppendText("\r\n");

                //输出样本集
                txt.AppendText("回归方程的样本集为:\r\n");
                for (int i = 0; i < threeModel.dcount.Columns.Count; i++)
                    txt.AppendText(threeModel.dcount.Columns[i].ColumnName + "\t");
                txt.AppendText("\r\n");
                for (int i = 0; i < threeModel.dcount.Rows.Count; i++)
                {
                    for (int j = 0; j < threeModel.dcount.Columns.Count; j++)
                        txt.AppendText(threeModel.dcount.Rows[i][j].ToString() + "\t");
                    txt.AppendText("\r\n");
                }
                txt.AppendText("\r\n");

                //输出检验样本集及相对误差
                txt.AppendText("检验样本集及相对误差如下所示:\r\n");
                for (int i = 0; i < threeModel.errTest.Columns.Count; i++)
                    txt.AppendText(threeModel.errTest.Columns[i].ColumnName + "\t");
                txt.AppendText("\r\n");
                for (int i = 0; i < threeModel.errTest.Rows.Count; i++)
                {
                    for (int j = 0; j < threeModel.errTest.Columns.Count; j++)
                    {
                        if (j == threeModel.errTest.Columns.Count - 2)
                            txt.AppendText(threeModel.errTest.Rows[i][j].ToString() + "\t\t");
                        else
                            txt.AppendText(threeModel.errTest.Rows[i][j].ToString() + "\t");
                    }
                    txt.AppendText("\r\n");
                }

                double avg = 0;
                for (int i = 0; i < threeModel.errTest.Rows.Count; i++)
                {
                    avg += Convert.ToDouble(threeModel.errTest.Rows[i][threeModel.errTest.Columns.Count - 1]);
                }
                avg /= threeModel.errTest.Rows.Count;
                txt.AppendText("平均误差为:" + avg);
            }
            if (ratioModel.mrk) {
                txt.Text = "比值模型\r\n线性回归方程为：Y=" + ratioModel.K + "X+" + ratioModel.B + ",pearson相关系数为:" +
                         ratioModel.p + "\tspearman相关系数为:" + ratioModel.q + "\r\n";
                txt.AppendText("\r\n");

                //输出样本集
                txt.AppendText("回归方程的样本集为:\r\n");
                for (int i = 0; i < ratioModel.dcount.Columns.Count; i++)
                    txt.AppendText(ratioModel.dcount.Columns[i].ColumnName + "\t");
                txt.AppendText("\r\n");
                for (int i = 0; i < ratioModel.dcount.Rows.Count; i++)
                {
                    for (int j = 0; j < ratioModel.dcount.Columns.Count; j++)
                        txt.AppendText(ratioModel.dcount.Rows[i][j].ToString() + "\t");
                    txt.AppendText("\r\n");
                }
                txt.AppendText("\r\n");

                //输出检验样本集及相对误差
                txt.AppendText("检验样本集及相对误差如下所示:\r\n");
                for (int i = 0; i < ratioModel.errTest.Columns.Count; i++)
                    txt.AppendText(ratioModel.errTest.Columns[i].ColumnName + "\t");
                txt.AppendText("\r\n");
                for (int i = 0; i < ratioModel.errTest.Rows.Count; i++)
                {
                    for (int j = 0; j < ratioModel.errTest.Columns.Count; j++)
                    {
                        if (j == ratioModel.errTest.Columns.Count - 2)
                            txt.AppendText(ratioModel.errTest.Rows[i][j].ToString() + "\t\t");
                        else
                            txt.AppendText(ratioModel.errTest.Rows[i][j].ToString() + "\t");
                    }
                    txt.AppendText("\r\n");
                }

                double avg = 0;
                for (int i = 0; i < ratioModel.errTest.Rows.Count; i++)
                {
                    avg += Convert.ToDouble(ratioModel.errTest.Rows[i][ratioModel.errTest.Columns.Count - 1]);
                }
                avg /= ratioModel.errTest.Rows.Count;
                txt.AppendText("平均误差为:" + avg);
            }
        }
    }
}
