using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stock_V0
{
    /// <summary>
    /// 该类用作初始化库存料位
    /// </summary>
    
    class CreateStock
    {
        /*
         *1、跺位结构用List<List<int>>集合存储，根据下标很容易转化为二维数组，确定其位置
         *2、跺位结构是正方形，长度和宽度相同，都为num 则总个数为num*num
         *3、轧制序列的长度为length。跺位生成随机数的时候范围是（1,2*length）
         *    当随机数大于length时，则把当前位置置为0，否则置为当前生成的随机数
         *4、跺位的高度范围：(min_height  max_height)
         */
        //用于生成随机数
        readonly Random random = new Random();
        //num：跺位的长和宽。 length：轧制序列长度
        public  List<List<int>> Create(int num ,int length,int min_height,int max_height)
        { 
            List<List<int>>result=new List<List<int>>();
           
            for (int m = 0; m < num*num; m++)
            {
                int height = random.Next(min_height, max_height);//随机跺位高度
                List<int> list = new List<int>();
                for (int n = 0; n < height; n++)
                {
                    int temp = random.Next(1, 2 * length);
                    if (temp <= length)
                    {
                        list.Add(temp);
                    }
                    else
                    {
                        list.Add(0);
                    }
                }
                result.Add(list);
            }
           return result;
        }

        //生产轧制序列，顺序编号
        public  List<int> CreateSeq(int length)
        {
            List<int> result = new List<int>();
            for (int m = 1; m < length + 1; m++)
            {
                result.Add(m);
            }
            return result;
        }
    }
}
