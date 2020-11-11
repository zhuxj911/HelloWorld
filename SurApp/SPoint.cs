using System;
using System.Collections.Generic;
using System.Text;
using ZXY;

namespace ZXY.Drawing
{   
    public class SPoint : NotificationObject
    {
        private static int count;

        private int id;
        public int Id
        {
            get => id;
        }

        //private string name;
        public String Name
        {
            get;
            set;
        }

        private double x;
        private double y;
        private double z;

        #region 构造函数

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static SPoint()
        {
            count = 0;
        }

        public SPoint()
        {
            this.id = ++count;
            Name = "";
            x = y = z = 0;
        }

        public SPoint(string name, double x, double y, double z)
        {
            this.id = ++count;
            this.Name = name;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public SPoint(double x, double y, double z)
        {
            this.id = ++count;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public SPoint(double x, double y)
        {
            this.id = ++count;
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            //if(Name == null || Name == " ") //System.String -> string
            if ( string.IsNullOrWhiteSpace(Name) )
                return $"{Id}, {x},{y},{z}";
            else
                return $"{Id}, {Name},{x},{Y},{z}";
        }
        #endregion

        public double X
        {
            get => x;
            set
            {
                if (value >= 0)
                {
                    x = value;
                    RaisePropertyChanged("X");
                }
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value >= 0)
                {
                    y = value;
                    RaisePropertyChanged("Y");
                }
            }
        }

        public double Z
        {
            get
            {
                return z;
            }
            set
            {
                if (value >= 0)
                {
                    z = value;
                    RaisePropertyChanged("Z");
                }
            }
        }

        /// <summary>
        /// 计算该点至p2点的距离
        /// </summary>
        /// <param name="p2">目标点p2</param>
        /// <returns>该点至p2点的距离</returns>
        public double Distance(SPoint p2)
        {           
            return Distance(this, p2);
        }

        public static double Distance(SPoint p1, SPoint p2)
        {
            //double dx = p1.x - p2.x;
            //double dy = p1.y - p2.y;
            //return Math.Sqrt(dx * dx + dy * dy);
            return SurMath.Azimuth(p1.X, p1.Y, p2.X, p2.Y).d;
        }
    }
}
