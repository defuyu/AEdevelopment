using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AE
{
    public partial class chartForm : Form
    {
        public chartForm()
        {
            InitializeComponent();
        }
        public DataTable dt;
        public string year;
        public List<int> li = new List<int>();
        public string attri = "";
        public List<string> years = new List<string>();
        public List<DataTable> dtList = new List<DataTable>();
        public int classGraph=1;
        string[] liName = { ""};

        private void chartForm_Load(object sender, EventArgs e)
        {
            //设置Y轴标题
            if (attri.Equals("从业人员"))
            {
                this.chart1.ChartAreas[0].Axes[1].Title = "从业人员（人）";
            }
            else if (attri.Equals("营业收入"))
            {
                this.chart1.ChartAreas[0].Axes[1].Title = "营业收入（千元）";
            }
            if (classGraph == 1)
            {
                titleText.Text = "武汉市" + year + "年体育产业" + attri + "统计图表";
                this.graph_class1();
            }
            else {
                titleText.Text = "武汉市年际体育产业" + attri + "统计对比图表";
                this.graph_class2();
            }
        }

        //同年图表类型
        public void graph_class1() {
            //计算Y轴值
            double[] yData = this.calculateY(dt);
            //绘制图表
            this.chart1.Series[0].Points.DataBindXY(li, yData);
            this.chart1.Series[0].Name = attri;
        }

        //不同年图表类型
        public void graph_class2()
        {
            //for(int i=0;i<this.chart1.Series.Count;i++){
            //    this.chart1.Series.RemoveAt(i);
            //}
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            //计算Y轴值
            for (int i = 0; i < dtList.Count; i++) {
                double[] yData = this.calculateY(dtList[i]);
                this.chart1.Series.Add(years[i]);
                this.chart1.Series[years[i]].ChartType = SeriesChartType.Line;
                this.chart1.Series[years[i]].Points.DataBindXY(li, yData);
            }
        }

        //计算Y轴值
        public double[] calculateY(DataTable dt) {
            int m = li.Count;
            double[] yData = new double[m];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int classT = Convert.ToInt32(dt.Rows[i][0].ToString());
                for (int j = 0; j < m; j++)
                {
                    if (classT == li[j])
                    {
                        yData[j] += Convert.ToDouble(dt.Rows[i][1].ToString());
                    }
                }
            }
            for (int j = 0; j < m; j++)
            {
                yData[j] = Math.Round(yData[j]);
            }
            return yData;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
