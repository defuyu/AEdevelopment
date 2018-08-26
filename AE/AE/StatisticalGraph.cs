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
        DataTable dt;
        string filename;
        string year;
        List<int> li = new List<int>();
        string attri="";

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
            filename = OpenExcelDlg.FileName;
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
            Connection.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btGenerate_Click(object sender, EventArgs e)
        {
            //选择的类别
            for (int i = 0; i < checkedList.Items.Count; i++) {
                if (checkedList.GetItemChecked(i)) {
                    li.Add(i + 1);
                }
            }
            //选择的年份
            year = tableCmb.SelectedItem.ToString();
            //选择的属性
            if (radioButton1.Checked)
            {
                attri = "从业人员";
            }
            else {
                attri = "营业收入";
            }
            //初始化dt
            dt = new DataTable();
            dt.Columns.Add("类别");
            dt.Columns.Add(attri);
            //数据库查询
            OleDbConnection Connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + filename);
            Connection.Open();
            string sql = "select 类别,"+attri+" from "+year;
            OleDbCommand comm = new OleDbCommand(sql, Connection);
            try
            {
                OleDbDataReader dread = comm.ExecuteReader();
                while (dread.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = dread[0].ToString();
                    dr[1] = dread[1].ToString();
                    dt.Rows.Add(dr);
                }
            }
            catch
            {
                MessageBox.Show("操作错误");
                return;
            }
            chartForm chart0 = new chartForm();
            chart0.li = li;
            chart0.year = year;
            chart0.dt = dt;
            chart0.attri=attri;
            chart0.Visible = true;
        }
    }
}
