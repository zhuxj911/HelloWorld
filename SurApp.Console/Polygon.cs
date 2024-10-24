using System;
using System.Collections.Generic;
using System.Text;

namespace DrawShape
{
    /// <summary>
    /// 由于Polygon类结构与Polyline有许多相似之处，
    /// 但他们之间不是 is a 的关系，也就是说 直接用 继承 不太合适
    /// 所以这里我们改用组合使用的方式，复用Polyline类
    /// </summary>
    public class Polygon : Shape
    {
        private Polyline polyline = new Polyline();
         
        public Polygon()
        {
            this.area = this.length = 0;
        }

        public int Count => polyline.Count;

        public Point this[int index]
        {
            get => this.polyline[index];
        }

        private void Calculate()
        {
            this.length = 0;
            this.area = 0;
            if (this.Count < 3) return;

            //下面这句用Polyline类中的长度 + 首尾两点的距离
            this.length = polyline.Length + this[this.Count - 1].Distance(this[0]);

            for (int i = 0; i < this.Count; i++)
            {
                int j = (i + 1) % this.Count; //用求余的方式替代下边的判断
                                              //循环队列的方式应尽量使用取余的方式进行
                //if (j == this.Count) j = 0; 
                area += this[i].X * this[j].Y - this[j].X * this[i].Y;
            }
            this.area *= 0.5;            
        }

        public void Add(Point pt)
        {
            this.polyline.Add(pt);            
            this.Calculate(); //此处在顶点添加、删除或修改的情况下进行计算（删除或修改没有实现）
        }

        public void AddRange(IEnumerable<Point> collection)
        {
            this.polyline.AddRange(collection);
            Calculate();//此处在顶点添加、删除或修改的情况下进行计算（删除或修改没有实现）
        }

        public override void Drawing()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder("Polygon:\n");
            for (int i = 0; i < this.Count; i++)
            {
                buffer.Append($"  {i + 1}, ({this[i].X}, {this[i].Y})\n");
            }
            buffer.Append($"面积={Area}， 长度={this.Length}\n");
            return buffer.ToString();
        }
    }
}
