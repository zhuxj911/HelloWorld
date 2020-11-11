using DrawShape;
using System;
using System.Collections.Generic;

namespace HelloWorld
{
    //public delegate void fff();
    //public enum Color { Red, Green, Blue }

    #region Event演示
    // Define a class to hold custom event info
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

    // Class that publishes an event
    class Publisher
    {
        // Declare the event using EventHandler<T>
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;

        public void DoSomething()
        {
            // Write some code that does something useful here
            // then raise the event. You can also raise an event
            // before you execute a block of code.
            OnRaiseCustomEvent(new CustomEventArgs("Event triggered"));
        }

        // Wrap event invocations inside a protected virtual method
        // to allow derived classes to override the event invocation behavior
        protected virtual void OnRaiseCustomEvent(CustomEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            EventHandler<CustomEventArgs> raiseEvent = RaiseCustomEvent;

            // Event will be null if there are no subscribers
            if (raiseEvent != null)
            {
                // Format the string to send inside the CustomEventArgs parameter
                e.Message += $" at {DateTime.Now}";

                // Call to raise the event.
                raiseEvent(this, e);
            }
        }
    }

    //Class that subscribes to an event
    class Subscriber
    {
        private readonly string _id;

        public Subscriber(string id, Publisher pub)
        {
            _id = id;

            // Subscribe to the event
            pub.RaiseCustomEvent += HandleCustomEvent;
        }

        // Define what actions to take when the event is raised.
        void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            Console.WriteLine($"{_id} received this message: {e.Message}");
        }
    }
    #endregion

    class Program
    {
        /// <summary>
        /// 该函数为显示所有图形的函数，
        /// 同样的Shape，但表现为各种不同子类的信息
        /// 
        /// 知识点： 数组类的参数用可枚举接口 IEnumerable<Shape> shapes
        ///        不要直接用 静态数组     Shape[] shapes
        ///               或 动态数组 List<Shape> shapes
        /// 优化： 这个函数其实只做了一个功能：画图形 ，是从接口 IDrawing 继承来的
        ///       根据面向接口编程原则，此处的参数更应该从：
        ///  static void DisplayAllShapes(IEnumerable<Shape> shapes)
        /// 更改为：
        ///  static void DisplayAllShapes(IEnumerable<IDrawing> shapes)
        /// </summary>
        /// <param name="shapes"></param>
        static void DrawAllShapes(IEnumerable<IDrawing> shapes)
        {
            //static void DrawAllShapes(IEnumerable<Shape> shapes)
            //    foreach (IDrawing item in shapes)                 //此处体现了类的多态性
            foreach (IDrawing item in shapes) //  此处采用接口的形式，体现了面向接口编程的原则
            {
                item.Drawing();

                //由于所有的子类都从Shape继承，而Shape实现了IShape与IDrawing两个接口
                //所以此处可以将IDrawing接口向IShape接口做接口跳转，从而调用IShape接口中的方法
                //在ArcGIS Engine的开发中，常常采用这种方法，将一个大类的各种功能用接口的形式进行分类管理与应用
                IShape shape = item as IShape;
                Console.WriteLine($"这是IShape接口的方法：{shape.Length}");
            }
        }

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

            #region Event测试代码
            var pub = new Publisher();
            var sub1 = new Subscriber("sub1", pub);
            var sub2 = new Subscriber("sub2", pub);

            // Call the method that raises the event.
            pub.DoSomething();
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
            pg2.AddRange(new SPoint[] {
                new SPoint(-1, 0),
                new SPoint(2, 3),
                new SPoint(4, 2),
                new SPoint(4, 4),
                new SPoint(6, 8),
                new SPoint(-2, 5)} );

            shapes.Add(pg2);

            //foreach (var item in shapes)
            //{
            //    item.Drawing();
            //}
            DrawAllShapes(shapes);//此处用一个一般化的函数代替上面的循环
            #endregion

        }
    }
}
