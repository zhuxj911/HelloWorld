using System;
using System.Collections.Generic;
using System.Text;

namespace DrawShape
{
    public class Polygon : Shape
    {
        private Polyline pl = new Polyline();
         
        public Polygon()
        {
            this.area = this.length = 0;
        }

        public int Count { get => pl.Count; }

        public SPoint this[int index]
        {
            get => this.pl[index];
        }

        private void CalculateArea()
        {
            this.area = 0;//置初值为0

            if (this.Count < 3) return;
           
            for (int k = 0; k < this.Count; k++)
            {
                int j = k + 1;
                if (j == this.Count) j = 0;
                this.area += (this[k].X * this[j].Y - this[j].X * this[k].Y);
            }
            this.area *= 0.5;
        }

        public void Add(SPoint pt)
        {
            this.pl.Add(pt);

            if (this.Count < 3) return;

            int n = this.pl.Count - 1;
            this.length = pl.Length + this[n].Distance(this[0]);
            
            this.CalculateArea();
        }

        public void AddRange(IEnumerable<SPoint> collection)
        {             
            this.pl.AddRange(collection);

            int last = this.Count - 1;
            this.length = this.pl.Length + this[last].Distance(this[0]);

            this.CalculateArea();
        }

        public override void Drawing()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {        
            return $"多边形Polygon：面积{Area}， 长度{this.Length}";
        }
    }
}
