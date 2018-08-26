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
    public partial class errorJudge : Form
    {
        public errorJudge()
        {
            InitializeComponent();
        }

        private void errorJudge_Load(object sender, EventArgs e)
        {
            if (threeModel.mrk)
            {
                dataGridView1.DataSource = threeModel.errTest;
                label1.Text = "回归方程：Y=" + threeModel.K + "X+" + threeModel.B;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            if (ratioModel.mrk)
            {
                dataGridView1.DataSource = ratioModel.errTest;
                label1.Text = "回归方程：Y=" + ratioModel.K + "X+" + ratioModel.B;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }
    }
}
