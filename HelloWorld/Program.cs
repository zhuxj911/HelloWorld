using DrawShape;
using System;
using System.Collections.Generic;

namespace HelloWorld
{
    //public delegate void fff();
    //public enum Color { Red, Green, Blue }

    class Program
    {
        static void Main(string[] args)
        {
            #region 枚举与switch case
            //Color c = (Color)(new Random()).Next(0, 3);
            //switch (c)
            //{
            //    case Color.Red:
            //        Console.WriteLine("The color is red");
            //        break;
            //    case Color.Green:
            //        Console.WriteLine("The color is green");
            //        break;
            //    case Color.Blue:
            //        Console.WriteLine("The color is blue");
            //        break;
            //    default:
            //        Console.WriteLine("The color is unknown.");
            //        break;
            //}
            #endregion

            #region 值类型与引用类型测试
            //Type t = typeof(DateTime);
            //Type t = typeof(string);
            //Type t = typeof(IShape);
            //Type t = typeof(Action);
            //Type t = typeof(int[]);

            //if (t.IsValueType)
            //{
            //    Console.WriteLine($"{t.Name} is ValueType");
            //}
            //else
            //    Console.WriteLine($"{t.Name} is ReferenceType");
            #endregion

            #region 排序算法：冒泡排序与快速排序
            /* 
			//int[] arr = new int[] { 9, 3, 1, 4, 2, 7, 8, 6, 5, -100, 0, -30, -88 };
            //List<int> list = new List<int>(arr);

            Random rd = new Random();
            int n = 10000000;
            List<int> list = new List<int>(n);
            for (int i = 0; i < n; i++)
            {
                list.Add(rd.Next(1, n * 100));
            }

            //Console.WriteLine($"排序前的数据：");
            //Console.WriteLine(string.Join(',', arr));

            //DateTime dt1 = DateTime.Now;
            //Sort.BubbleSort(arr);
            //DateTime dt2 = DateTime.Now;

            //Console.WriteLine($"排序后的数据：");
            //Console.WriteLine(string.Join(',', arr));

            //Console.WriteLine($"排序前的时间：{dt1}");
            //Console.WriteLine($"排序后的时间：{dt2}");

            Stopwatch st1 = new Stopwatch(); //计时器用来计算算法要用多久时间
            st1.Start();
            //Sort.BubbleSort(list);
            Sort.QuickSort(list);
            st1.Stop();
            Console.WriteLine("运行时间：" + st1.Elapsed);
            //Console.WriteLine(string.Join(',', list));
			*/
            #endregion
            #region SPoint类测试
            //SPoint p1 = new SPoint();
            //Console.WriteLine(p1);

            //SPoint p2 = new SPoint("2", 200, 200, 200);
            //Console.WriteLine(p2);

            //double d = p1.Distance(p2);
            //double d1 = p2.Distance(p1);
            //Console.WriteLine($"p1->p2的距离为{d}");

            //SPoint p3 = new SPoint(300, 300, 300);
            //Console.WriteLine(p3);

            //SPoint p4 = new SPoint(400, 400);
            //p4.Y = -500;
            //Console.WriteLine(p4);

            //SPoint p5 = p3;
            //p5.Y = -500;
            //Console.WriteLine(p5);


            //double d4 = SPoint.Distance(p3, p4);

            //Circle c1 = new Circle(10);
            //Console.WriteLine(c1);
            //c1.R = 20;
            //Console.WriteLine(c1);

            //double rad = ZXY.SurMath.DMStoRad(1.2030);
            ////0.0234165007975906
            //Console.WriteLine($"1 20 30 -> Rad:{rad}");
            #endregion

            #region 继承与多态测试

            List<Shape> shapes = new List<Shape>();
            shapes.Add(new SPoint());
            shapes.Add(new Circle(10));
            
            Polyline pl = new Polyline();
            pl.Add(new SPoint(1, 0));
            pl.Add(new SPoint(2, 0));
            pl.Add(new SPoint(3, 0));

            SPoint[] pts = new SPoint[] {new SPoint(4,0), new SPoint(5,0), new SPoint(6,0) };
            pl.AddRange(pts);

            shapes.Add(pl);

            Polyline pl2 = new Polyline();//长度21.494848364936182
            pl2.Add(new SPoint(-1, 0));
            pl2.Add(new SPoint(2, 3));
            pl2.Add(new SPoint(4, 2));

            pts = new SPoint[] { new SPoint(4, 4), new SPoint(6, 8), new SPoint(-2, 5) };
            pl2.AddRange(pts);

            shapes.Add(pl2);


            Polygon pg = new Polygon();           
            pg.Add(new SPoint(1, 0));
            pg.Add(new SPoint(2, 0));
            pg.Add(new SPoint(3, 0));

            pts = new SPoint[] { new SPoint(4, 0), new SPoint(5, 0), new SPoint(6, 0) };
            pg.AddRange(pts);

            shapes.Add(pg);

            Polygon pg2 = new Polygon(); //面积28， 长度26.593867878528968
            pg2.Add(new SPoint(-1, 0));
            pg2.Add(new SPoint(2, 3));
            pg2.Add(new SPoint(4, 2));

            pts = new SPoint[] { new SPoint(4, 4), new SPoint(6, 8), new SPoint(-2, 5) };
            pg2.AddRange(pts);

            shapes.Add(pg2);

            foreach (var item in shapes)
            {
                item.Drawing();
            }
            #endregion

        }
    }
}
