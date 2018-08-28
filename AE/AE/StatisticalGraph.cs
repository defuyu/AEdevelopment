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
        string filename;    //数据库目录
        string attri = "";  //选择的属性
        List<int> li = new List<int>(); //选择的类型

        //同一年
        DataTable dt;       //同一年的总表
        string year;        //同一年选择的年份
        
        //不同年
        List<DataTable> dtList = new List<DataTable>();
        List<string> years = new List<string>();    //选择的年份

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

            if (filename.Equals("")) { return; }
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
            Connection.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btGenerate_Click(object sender, EventArgs e)
        {
            //选择的属性
            if (radioButton1.Checked)
            {
                attri = "从业人员";
            }
            else
            {
                attri = "营业收入";
            }
            //tab
            if (this.tab.SelectedIndex == 0) {
                this.sameYearCompire();
            }
            if (this.tab.SelectedIndex == 1) {
                this.differYearCompire();
            }
        }

        //不同年对比
        private void differYearCompire()
        {
            //选择的类别
            li = null;
            li = new List<int>();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    li.Add(i + 1);
                }
            }
            //选择的年份
            years = null;
            years = new List<string>();
            for (int i = 0; i < checkedListyear.Items.Count; i++) 
            {
                if (checkedListyear.GetItemChecked(i)) {
                    string temp=checkedListyear.Items[i].ToString();
                    temp=temp.Replace("年","");
                    years.Add(temp);
                    DataTable dtTemp = this.dataSearch(temp);
                    dtList.Add(dtTemp); //数据库操作
                }
            }
            //图表生成
            chartForm chart0 = new chartForm();
            chart0.li = li;
            chart0.years = years;
            chart0.dtList = dtList;
            chart0.attri = attri;
            chart0.classGraph = 2;
            chart0.Visible = true;
        }

        //同年对比
        public void sameYearCompire() {
            //选择的类别
            li = null;
            li = new List<int>();
            for (int i = 0; i < checkedList.Items.Count; i++)
            {
                if (checkedList.GetItemChecked(i))
                {
                    li.Add(i + 1);
                }
            }
            //选择的年份
            year = tableCmb.SelectedItem.ToString();
            //数据库操作
            dt=this.dataSearch(year);
            //图表生成
            chartForm chart0 = new chartForm();
            chart0.li = li;
            chart0.year = year;
            chart0.dt = dt;
            chart0.attri = attri;
            chart0.classGraph = 1;
            chart0.Visible = true;
        }

        //数据库操作
        private DataTable dataSearch(string searchYear) {
            //初始化dt
            DataTable dSearch = new DataTable();
            dSearch.Columns.Add("类别");
            dSearch.Columns.Add(attri);
            //数据库查询
            OleDbConnection Connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + filename);
            Connection.Open();
            string sql = "select 类别," + attri + " from " + searchYear;
            OleDbCommand comm = new OleDbCommand(sql, Connection);
            try
            {
                OleDbDataReader dread = comm.ExecuteReader();
                while (dread.Read())
                {
                    DataRow dr = dSearch.NewRow();
                    dr[0] = dread[0].ToString();
                    dr[1] = dread[1].ToString();
                    dSearch.Rows.Add(dr);
                }
            }
            catch
            {
                MessageBox.Show("操作错误");
                return dSearch;
            }
            return dSearch;
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAll.Checked)
            {
                for (int i = 0; i < checkedList.Items.Count; i++)
                {
                    checkedList.SetItemChecked(i, true);
                }
            }
            else {
                for (int i = 0; i < checkedList.Items.Count; i++)
                {
                    checkedList.SetItemChecked(i, false);
                }
            }
        }

        private void checkAllyear_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAllyear.Checked)
            {
                for (int i = 0; i < checkedListyear.Items.Count; i++)
                {
                    checkedListyear.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListyear.Items.Count; i++)
                {
                    checkedListyear.SetItemChecked(i, false);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }
    }
}
