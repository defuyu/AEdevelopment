using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        private void chartForm_Load(object sender, EventArgs e)
        {
            int m=li.Count;
            double[] yData=new double[m];
            for (int i = 0; i < dt.Rows.Count; i++) { 
                int classT=Convert.ToInt32(dt.Rows[i][0].ToString());
                for (int j = 0; j < m; j++) {
                    if (classT == li[j]) {
                        yData[j] += Convert.ToDouble(dt.Rows[i][1].ToString());
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
