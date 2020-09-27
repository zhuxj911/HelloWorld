using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    /// <summary>
    /// 排序类
    /// </summary>
    public class Sort
    {
        //函数的四大要素： 函数名，参数， 返回值， 函数体
        //public static void BubbleSort(int[] arr)
        //静态数组
        //动态数组 泛型

        /// <summary>
        /// 冒泡排序法
        /// </summary>
        /// <param name="list"></param>
        public static void BubbleSort(List<int> list)
        {
            int j = 0;
            while (true)
            {
                bool swap = false;
                for (int i = 0; i < list.Count - 1 - j; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        int tmp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = tmp;
                        swap = true;
                    }
                }
                j++;
                //Console.WriteLine($"第{j}次排序完后的数据：");
                //Console.WriteLine(string.Join(',', array));

                if (swap == false) break;
            }
        }

        /// <summary>
        /// 快速排序法
        /// </summary>
        /// <param name="list"></param>
        public static void QuickSort(List<int> list)
        {
            if (list.Count < 2) return;

            List<int> smaller = new List<int>();
            List<int> same = new List<int>();
            List<int> larger = new List<int>();

            int pivot = list[0];

            foreach (var item in list)
            {
                if (item < pivot)
                    smaller.Add(item);
                else if (item > pivot)
                    larger.Add(item);
                else
                    same.Add(item);
            }

            QuickSort(smaller);
            QuickSort(larger);

            list.Clear();
            list.AddRange(smaller);
            list.AddRange(same);
            list.AddRange(larger);
        }
    }
}
