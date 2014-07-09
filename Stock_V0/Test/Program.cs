using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stock_V0;

namespace Test
{
    class Program
    {
        /// <summary>
        /// 测试类
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
           /* 测试找权重最大
            * List<int> list = new List<int>() { 0,1,0,1,3,3,4,0};

            List<int> listCanUsed = new List<int>();
            int num1 = 0;//可纳入计划钢坯个数
            int num2 = 0;//障碍钢坯个数
            //统计可纳入计划钢坯个数
            foreach (int n in list)
            {
                if (n != 0  && !listCanUsed.Contains(n))
                {
                    num1++;
                    listCanUsed.Add(n);
                }
            }
            List<int> listTemp = new List<int>(list);
            while (listTemp.Count > 0)
            {
                int temp = listTemp[0];
                listTemp.RemoveAt(0);
                if (temp == 0 || listTemp.Contains(temp))
                {
                    //可以移除
                }
                else
                {
                    break;
                }
            }
            num2 = listTemp.Count - num1 + 1;

            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.ReadKey();
            */

            /*找坐标值*/
            for (int i = 1; i < 37; i++)
            {
                Console.Write("(" + Utility.GetX(i, 6) + "," + Utility.GetY(i, 6) + ")");
            }
            Console.ReadKey();
        }
    }
}
