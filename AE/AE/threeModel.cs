using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace AE
{
    public partial class threeModel : Form
    {
        public threeModel()
        {
            InitializeComponent();
            chart1.Series[0].ChartType = SeriesChartType.Point;
            mrk = true;
        }
        //声明
        public static Boolean mrk = false;
        public static DataTable dt;
        public static DataTable dcount;
        public static DataTable dtest;
        public static DataTable errTest;
        Maths math = new Maths();
        int rows ;
        public static double K;
        public static double B;
        public static double p;
        public static double q;

        //加载数据
        private void loadExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1=new OpenFileDialog();
            openFileDialog1.Filter = "CSV Files|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;

                FileInfo X_if = new FileInfo(file);  //获取文件名
                string X_name = X_if.Name;
                dt = new DataTable(X_name);

                StreamReader reader = new StreamReader(file);
                string table_colum = reader.ReadLine();
                string[] temp_counts = table_colum.Split(',');
                int i = 0;
                foreach (var tiem in temp_counts)
                {
                    dt.Columns.Add(temp_counts[i]);
                    i++;
                }
                do
                {
                    string temp_row = reader.ReadLine();
                    string[] temp_countss = temp_row.Split(',');
                    dt.Rows.Add(temp_countss);
                } while (!reader.EndOfStream); //表已建立成功

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.DataSource = dt;
                //MessageBox.Show(dt.Rows[1][1].ToString());
            }
        }

        //提取某一列数据
        private double[] caculatearray(int rows,int colues, DataTable ddt)
        {
            double[] rs = new Double[rows];
            for (int i = 0; i < rows; i++) {
                rs[i] = Convert.ToDouble(ddt.Rows[i][colues]);
            }
            return rs;
        }

        //寻找最佳波段
        private void button3_Click(object sender, EventArgs e)
        {
            rows = dt.Rows.Count;
            double[] yeA=new Double[rows];
            yeA = caculatearray(rows, dt.Columns.Count - 1, dt);
            double[] band1 = new Double[rows];  //一号波段
            double[] band2 = new Double[rows];  //二号波段
            double[] band3 = new Double[rows];  //三号波段
            double[] band4 = new Double[rows];  //组合波段
            double c = 0; double cz = 0;
            double b1 = 0; double b1z = 0;
            double b2 = 0; double b2z = 0;
            double b3 = 0; double b3z = 0;
            double connect = 0;                 //相关系数

            //在i,j,k定义三波段的始末波段index值，具体看excle中数据分布
            for (int i = 68; i <= 74; i++)
            {
                band1 = this.caculatearray(rows, i + 1, dt);
                for (int j = 75; j <= 78; j++)
                {
                    band2 = this.caculatearray(rows, j + 1, dt);
                    for (int k = 81; k <= 86; k++)
                    {
                        band3 = this.caculatearray(rows, k + 1, dt);
                        for (int l = 0; l < rows; l++)
                        {
                            band4[l] = (1 / band1[l] - 1 / band2[l]) * band3[l];
                        }
                        if (pearsonC.Checked==true)
                        {
                            connect = math.PersonConnection(band4, yeA);
                        }
                        if (spearmanC.Checked==true)
                        {
                            connect = math.Spearmanconnection(band4, yeA);
                        }
                        if (connect < 0)
                        { 
                            connect = -connect; 
                        }
                        c = connect; b1 = i; b2 = j; b3 = k;

                        if (cz < c) { cz = c; b1z = b1; b2z = b2; b3z = b3; }
                        //int i1 = i; int j1 = j; int k1 = k;
                    }
                }
            }
            MessageBox.Show("最佳波段为" + b1z + " " + b2z + " " + b3z + " " + "\n" + "最佳相关系数为" + cz);
            
        }

        //清空
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null; 
        }

        //反演
        private void fanyan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()) && string.IsNullOrEmpty(textBox2.Text.Trim()) && string.IsNullOrEmpty(textBox3.Text.Trim()))
            {
                MessageBox.Show("请输入波段");
            }
            else 
            {
                rows = dt.Rows.Count;
                int a = Convert.ToInt32(textBox1.Text.Trim());
                int b = Convert.ToInt32(textBox2.Text.Trim());
                int c = Convert.ToInt32(textBox3.Text.Trim());
                double[] band1 = new Double[rows];  //一号波段
                double[] band2 = new Double[rows];  //二号波段
                double[] band3 = new Double[rows];  //三号波段
                double[] band4 = new Double[rows];  //组合波段
                band1 = caculatearray(rows, a + 1, dt);
                band2 = caculatearray(rows, b + 1, dt);
                band3 = caculatearray(rows, c + 1, dt);
                //计算band4
                for (int i = 0; i < rows; i++)
                {
                    band4[i] = (1 / band1[i] - 1 / band2[i]) * band3[i];
                }

                #region//反演集

                dcount = new DataTable();
                dcount.Columns.Add(textBox1.Text.ToString());
                dcount.Columns.Add(textBox2.Text.ToString());
                dcount.Columns.Add(textBox3.Text.ToString());
                dcount.Columns.Add("λ4");
                dcount.Columns.Add("yeA");

                for (int i = 0; i < rows; i++) 
                {
                    if (dt.Rows[i][0].ToString().Equals("0")) {
                        DataRow dr = dcount.NewRow();
                        
                        object[] rowArray = new object[5];
                        rowArray[0] = dt.Rows[i][a + 1].ToString();
                        rowArray[1] = dt.Rows[i][b + 1].ToString();
                        rowArray[2] = dt.Rows[i][c + 1].ToString();
                        rowArray[3] = Math.Round(band4[i],4).ToString();
                        rowArray[4] = dt.Rows[i][dt.Columns.Count-1].ToString();
                        dr.ItemArray = rowArray;

                        dcount.Rows.Add(dr);
                    }
                }
                dataGridView1.DataSource = dcount;  //测试反演集
                #endregion

                #region//检验集
                dtest = new DataTable();
                dtest.Columns.Add(textBox1.Text.ToString());
                dtest.Columns.Add(textBox2.Text.ToString());
                dtest.Columns.Add(textBox3.Text.ToString());
                dtest.Columns.Add("λ4");
                dtest.Columns.Add("yeA");

                for (int i = 0; i < rows; i++)
                {
                    if (dt.Rows[i][0].ToString().Equals("1"))
                    {
                        DataRow dr = dtest.NewRow();

                        object[] rowArray = new object[5];
                        rowArray[0] = dt.Rows[i][a + 1].ToString();
                        rowArray[1] = dt.Rows[i][b + 1].ToString();
                        rowArray[2] = dt.Rows[i][c + 1].ToString();
                        rowArray[3] = Math.Round(band4[i], 4).ToString();
                        rowArray[4] = dt.Rows[i][dt.Columns.Count - 1].ToString();
                        dr.ItemArray = rowArray;

                        dtest.Rows.Add(dr);
                    }
                }
                //dataGridView1.DataSource = dtest;  //测试检验集
                #endregion

                #region//绘制散点图
                double[] fyband4 = new Double[dcount.Rows.Count];  //组合波段
                fyband4 = caculatearray(dcount.Rows.Count, dcount.Columns.Count - 2, dcount);
                double[] yeA = new Double[dcount.Rows.Count];      //叶绿素A
                yeA = caculatearray(dcount.Rows.Count,dcount.Columns.Count-1,dcount);
                this.chart1.Series[0].Points.DataBindXY(fyband4, yeA);
                for(int i=0;i<dcount.Rows.Count;i++)
                    this.chart1.Series[0].Points.AddXY(fyband4[i], yeA[i]);
                #endregion

                #region//求出回归方程
                double temp=0,avg1=0,avg2=0,xpow2=0;
                for (int i = 0; i < dcount.Rows.Count; i++) {
                    avg1+=fyband4[i];
                    avg2+=yeA[i];
                    xpow2 += Math.Pow(fyband4[i],2);
                    temp+=fyband4[i] * yeA[i];
                }
                temp = temp - avg1 * avg2 / dcount.Rows.Count;
                temp = temp / (xpow2 - avg1 * avg1 / dcount.Rows.Count);
                K = Math.Round(temp,4);
                B = Math.Round(avg2 / dcount.Rows.Count - K * avg1 / dcount.Rows.Count,4);
                lbl1.Text = "Y=" + K + "X" +"+"+ B;
                lbl1.Visible = true;

                //pearson和spearman系数
                p = Math.Round(math.PersonConnection(fyband4,yeA),5);
                q = Math.Round(math.Spearmanconnection(fyband4, yeA),5);
                lblP.Text = "pearson:" + p;
                lblS.Text = "spearman:" + q;


                #endregion

                #region//误差分析
                errTest = new DataTable();
                errTest = dtest.Copy();
                errTest.Columns.Add("反演浓度");
                errTest.Columns.Add("相对误差");
                double[] textFy = new Double[dtest.Rows.Count];//误差反演浓度
                double[] zuhe = new Double[dtest.Rows.Count];//取出组合值
                zuhe = caculatearray(dtest.Rows.Count, dtest.Columns.Count - 2, dtest);
                double[] shiYe = new Double[dtest.Rows.Count];//取出组合值
                shiYe = caculatearray(dtest.Rows.Count, dtest.Columns.Count - 1, dtest);
                //误差反演
                for (int i = 0; i < dtest.Rows.Count; i++) {
                    textFy[i] = Math.Round(K * zuhe[i] + B,3);
                    errTest.Rows[i][errTest.Columns.Count - 2] = textFy[i].ToString();//反演浓度
                    errTest.Rows[i][errTest.Columns.Count - 1] = Math.Abs(Math.Round((textFy[i]-shiYe[i])/shiYe[i],3));
                }
                
                #endregion

            }
        }

        //显示全部数据集
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dt;
        }

        //误差分析
        private void button4_Click(object sender, EventArgs e)
        {
            errorJudge er = new errorJudge();
            er.Visible = true;
        }

        //报表输出
        private void button5_Click(object sender, EventArgs e)
        {
            outData o = new outData();
            o.Visible = true;
        }

        

        
    }
}
