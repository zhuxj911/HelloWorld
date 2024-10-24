using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DrawShape
{
    //此处不希望该类受Polygon类不恰当的继承，所以声明为sealed，因此不能被继承
    public sealed class Polyline : Shape 
    {
        private List<Point> points = new List<Point>();
  
        public Polyline()
        {
            this.length = this.area = 0;
        }

        /// <summary>
        /// Polyline的顶点个数
        /// </summary>
        public int Count => this.points.Count;

        /// <summary>
        /// 索引，新的C#知识点
        /// 索引 pl[1] 是一个 get 属性
        /// 公布Polyline的各个顶点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Point this[int index]
        {
            get
            {
                if (index < 0 || index >= this.points.Count)
                    throw new IndexOutOfRangeException("下标溢出！！！");
                return this.points[index];
            }
        }

        private void Calculate()
        {
            this.length = 0;
            if (this.Count < 2) return;

            for (int k = 0; k < this.Count-1; k++)
            {
                this.length += this[k].Distance(this[k+1]);
            }
        }

        public void Add(Point pt)
        {
            this.points.Add(pt);            
            Calculate();
        }

        public void AddRange(IEnumerable<Point> collection)
        {
            this.points.AddRange(collection);
            Calculate();
        }

        public override void Drawing()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            //string buffer = "Polyline:\n";
            //for (int i = 0; i < this.Count; i++)
            //{
            //    buffer += $"  {i + 1}, ({this[i].X}, {this[i].Y})\n";
            //}
            //buffer += $"长度={this.length}";
            //return buffer;

            //以上代码 String 类频繁的进行字符串的连接操作，有性能问题，下边改用StringBuilder类
            StringBuilder buffer = new StringBuilder("Polyline:\n");
            for (int i = 0; i < this.Count; i++)
            {
                buffer.Append($"  {i + 1}, ({this[i].X}, {this[i].Y})\n");
            }
            buffer.Append($"长度={this.length}");
            return buffer.ToString();
        }
    }
}
