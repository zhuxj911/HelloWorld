using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DrawShape
{
    public class Polyline : Shape
    {
        private List<SPoint> points = new List<SPoint>();
  
        public Polyline()
        {
            this.length = this.area = 0;
        }

        public SPoint this[int index]
        {
            get
            {
                if (index < 0 || index >= this.points.Count)
                    throw new IndexOutOfRangeException("下标溢出！！！");
                return this.points[index];
            }
            //set
            //{
            //    if(index < 0 || index >= this.points.Count)
            //        throw new IndexOutOfRangeException("下标溢出！！！");
            //    this.points[index] = value;
            //}
        }

        private void CalculateLength()
        {
            if (this.Count < 2) this.length = 0;

            for (int k = 0; k < this.Count-1; k++)
            {
                this.length += this[k].Distance(this[k+1]);
            }
        }

        public int Count { get => this.points.Count; }

        public void Add(SPoint pt)
        {
            this.points.Add(pt);

            if (this.points.Count < 2) return;

            int n = this.points.Count - 1;
            this.length += this.points[n].Distance(this.points[n - 1]);
            this.area = 0;
        }

        public void AddRange(IEnumerable<SPoint> collection)
        {
            SPoint last = this.points[this.points.Count - 1];

            this.points.AddRange(collection);
            
            foreach (var item in collection)
            {
                this.length += item.Distance(last);
                last = item;
            }
            
            this.area = 0;
        }

        public override void Drawing()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {        
            return $"多段线Polyline：面积{Area}， 长度{this.Length}";
        }
    }
}
