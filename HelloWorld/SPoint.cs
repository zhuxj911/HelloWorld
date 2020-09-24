using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    /// <summary>
    /// 测量点
    /// 
    /// 封装 private protected
    /// 
    /// 1. 构造函数
    ///    作用：用于类的初始化工作， 主要是类数据的初始化
    ///    特点：
    ///    如果类中一个构造函数都没有，系统会为我们生成一个默认的构造函数
    ///    函数名与类名完全一样
    ///    无返回类型,即使void也不行，函数体中不能用return 
    ///    
    ///     this 指类的实例本身
    ///     
    ///     可以重载： 函数重载， 函数名相同，参数类型或个数不相同
    ///     
    ///     只能 new， 不能做其他的调用
    /// 2 方法/函数
    ///  类中的 this 代表类的本身的实例（类的静态中不能使用this）
    ///  
    /// 3 属性（Property）  //Attrubite 特性
    ///     特殊的 get/set 函数
    ///     因为类中的数据一般情况都是封装起来的 private/protected
    ///     就需要 一定的规则 来设置/修改 或者 访问数据
    /// </summary>
    public class SPoint
    {
        private string name;
        private double x;
        private double y;
        private double z;

        #region 构造函数
        public SPoint()
        {
            name = "";
            x = y = z = 0;
        }

        public SPoint(string name, double x, double y, double z)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public SPoint(double x, double y, double z)
        {          
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public SPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            if(name == null || name == "")
                return $"{x},{y},{z}";
            else
                return $"{name},{x},{y},{z}";
        }
        #endregion

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                if(value >= 0)
                    y = value;
            }
        }
    
        public double Distance(SPoint p2)
        {           
            return Distance(this, p2);
        }

        public static double Distance(SPoint p1, SPoint p2)
        {           
            double dx = p1.x - p2.x;
            double dy = p1.y - p2.y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}
