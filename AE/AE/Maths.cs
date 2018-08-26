using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AE
{
    class Maths
    {
        #region
        /// <summary>
        /// 计算person相关系数
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <returns></returns>
        public double PersonConnection(double[] a1, double[] a2)
        {
            int l1 = a1.Length;
            double sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, avare_a1 = 0, avare_a2 = 0;
            for (int i = 0; i < l1; i++)
            {
                sum1 += a1[i]; sum2 += a2[i];
            }
            avare_a1 = sum1 / l1; avare_a2 = sum2 / l1; //平均值
            sum1 = 0;
            for (int i = 0; i < l1; i++)
            {
                sum1 += ((a1[i] - avare_a1) * (a2[i] - avare_a2));
                sum3 += ((a1[i] - avare_a1) * (a1[i] - avare_a1));
                sum4 += ((a2[i] - avare_a2) * (a2[i] - avare_a2));
            }
            sum2 = Math.Sqrt(sum3);
            sum3 = Math.Sqrt(sum4);
            double connectDate = sum1 / (sum2 * sum3);
            return connectDate;
        }


        /// Spearman相关计算

        public double Spearmanconnection(double[] arrays1, double[] arrays2)
        {
            double[] array1 = new double[arrays1.Length]; double[] array2 = new double[arrays2.Length];
            for (int row = 0; row < arrays1.Length; row++)
            {
                array1[row] = arrays1[row];
                array2[row] = arrays2[row];
            }
            double Spearmanconnects = 0;
            double[] list1 = new double[array1.Length]; double[] list2 = new double[array2.Length];
            for (int i = 0; i < array1.Length; i++)    //得到由大到小的排列序号列表
            {
                int a1 = this.MaxArray(array1);
                list1[a1] = i + 1;
                array1[a1] = -10000;
                int a2 = this.MaxArray(array2);
                list2[a2] = i + 1;
                array2[a2] = -10000;
            }

            bool same = false;
            for (int k = 0; k < list1.Length; k++)   //检查有没有相同的秩次
            {
                if (list1[k] == list2[k]) { same = true; break; }
            }
            if (same)  //有相同的秩次
            {
                Spearmanconnects = PersonConnection(list1, list2);
            }
            else  //没有相同的秩次
            {
                double Sum = 0;
                for (int l = 0; l < list1.Length; l++)
                {
                    Sum += (list1[l] - list2[l]) * (list1[l] - list2[l]);
                }
                int n = list1.Length;
                Spearmanconnects = 1 - (6 * Sum) / (n * (n * n - 1));
            }
            return Spearmanconnects;
        }
        #endregion

        #region
        public int MaxArray(double[] Array)
        {
            int length = Array.Length;
            double max = Array[0]; int index_max = 0;
            for (int i = 1; i < length; i++)
            {
                if (Array[i] > max) { max = Array[i]; index_max = i; }
            }
            return index_max;
        }

        #endregion
    }
}
