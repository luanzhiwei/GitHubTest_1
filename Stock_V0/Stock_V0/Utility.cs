using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock_V0
{
   public  class Utility
    {
        /*
         *跺位结构：
         * 1 ,2 ,3 ,4 ,5 ,6
         * 7 ,8 ,9 ,10,11,12
         * 13,14,15,16,17,18
         * 19,20,21,22,23,24,
         * ……
         * 
         * 
         */
       /// <summary>
       /// 根据下标和长度来确定坐标值，从1开始的顺序数
       /// </summary>
       /// <param name="num"></param>
       /// <param name="length"></param>
       /// <returns></returns>
        public static string  GetX(int num,int length)
        {
            return Convert.ToString(Math.Floor(Convert.ToDouble((num -1)/ length)));
        }
        public static string GetY(int num, int length)
        {
            int i= num % length;
            return Convert.ToString((num-1) % length);
        }

    }
}
