using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock_V0
{
    class Program
    {
         public static int seqLength=40;
         public static int num = 30;
         public static int min_height = 2;
         public static int max_height = 20;
         
        /// <summary>
        /// 轧制序列倒剁优化程序入口
        /// </summary>
        static void Main(string[] args)
        {
            CreateStock createStock = new CreateStock();
            List<int> listSeq = createStock.CreateSeq(seqLength);
            List<List<int>> listStock = createStock.Create(num, seqLength,min_height,max_height);
            List<int>listSeqUsed=new List<int> ();//存放已经赋值的
            List<int> listStockUsed = new List<int>();//已经使用过的跺位下标
            List<List<int>> listSeqInStock = new List<List<int>>();//用来存放下标可以导出的钢坯
            List<int> StockCount = new List<int>();//倒跺次数
            for (int m = 0; m < listStock.Count;m++ )
            {
                Console.WriteLine();
                Console.Write("坐标：（" + Utility.GetX(m + 1, num) + "," + Utility.GetY(m + 1, num) + "):");
                foreach (int n in listStock[m])
                {
                    Console .Write (n+"  ");
                }
            }
            while (listSeq.Count > 0)
            {
                int seq = listSeq[0];
                double best = 0;
                int best_index = -1;
                List<List<int>> _listCanBeUsed = new List<List<int>>();
                List<int> _stockCount = new List<int>();
                for (int m = 0; m < listStock.Count; m++)
                {
                    List<int> listCanUsed = new List<int>();
                    int num1 = 0;//可纳入计划钢坯个数
                    int num2 = 0;//障碍钢坯个数
                    //统计可纳入计划钢坯个数
                    if (!listStockUsed.Contains(m))//过滤用过的钢坯
                    {
                        foreach (int n in listStock[m])
                        {
                            if (n != 0 && !listSeqUsed.Contains(n) && !listCanUsed.Contains(n))
                            {
                                num1++;
                                listCanUsed.Add(n);
                            }
                        }
                        //统计障碍钢坯个数
                        List<int> listTemp = new List<int>(listStock[m]);
                        while (listTemp.Count > 0)
                        {
                            int temp = listTemp[0];
                            listTemp.RemoveAt(0);
                            if (temp == 0 || listSeqUsed.Contains(temp) || listTemp.Contains(temp))
                            {
                                //可以移除
                            }
                            else
                            {
                                break;
                            }
                        }
                        num2 = listTemp.Count - num1 + 1;
                        //计算权重
                        double temp_weight = num1 * 0.4 / (0.6 * num2 + 1);
                        if (temp_weight > best)
                        {
                            best = temp_weight;
                            best_index = m;
                        }
                    }
                    _listCanBeUsed.Add(listCanUsed);
                    _stockCount.Add(num2);
                }
                //最好的
                listStockUsed.Add(best_index);
                listSeqInStock.Add(_listCanBeUsed[best_index]);
                StockCount.Add(_stockCount[best_index]);
                foreach(int x in _listCanBeUsed[best_index])
                {
                    listSeq.Remove(x);
                    listSeqUsed.Add(x);
                }

            }
            if (listStockUsed.Count != listSeqInStock.Count)
            {
                Console.WriteLine("出现错误");
            }
            Console.WriteLine();
            Console.WriteLine("运行结果：");
            for (int m = 0; m < listStockUsed.Count; m++)
            {
                Console.WriteLine();
                Console.Write("坐标：（" + Utility.GetX(listStockUsed[m]+1, num) + "," + Utility.GetY(listStockUsed[m]+1, num) + "),在该跺位导出的钢坯编号：");
                foreach (int n in listSeqInStock[m])
                {
                    Console.Write(n + " ");
                }
            }
            int count = 0;
            for (int m = 0; m < StockCount.Count; m++)
            {
                count += StockCount[m];
            }
            Console.WriteLine();
             Console.WriteLine("倒跺次数为："+count);
            Console.WriteLine ("运行结束");
            Console.ReadKey();
        }
    }
}
