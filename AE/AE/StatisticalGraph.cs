using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AE
{
    public partial class StatisticalGraph : Form
    {
        public StatisticalGraph()
        {
            InitializeComponent();
        }

        //浏览，查找数据库位置
        private void button1_Click(object sender, EventArgs e)
        {
            filepathtBx.Text = null;
            List<string> tabledata = new List<string>();
            //读取文件
            OpenFileDialog OpenExcelDlg = new OpenFileDialog();
            OpenExcelDlg.Filter = "Access files(*.mdb)|*.mdb";
            OpenExcelDlg.FilterIndex = 1;
            OpenExcelDlg.ShowDialog();
            string filename = OpenExcelDlg.FileName;
            filepathtBx.Text = filename;

            //读取数据库
            OleDbConnection Connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + filename);
            Connection.Open();
            System.Data.DataTable tblSch = Connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
            for (int i = 0; i < tblSch.Rows.Count; i++)
            {
                string name = tblSch.Rows[i]["TABLE_NAME"].ToString();
                tabledata.Add(name);
            }
            tableCmb.DataSource = null;
            tableCmb.DataSource = tabledata;
            checkedList.Items.Add(tabledata);//检索数据库中的表

            //提取类别
            string sql = "select 类别 from " + checkedList.SelectedItem.ToString();
            Console.WriteLine("");
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
