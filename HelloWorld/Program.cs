using System;
using System.Runtime.InteropServices;

/*
块注释
 */

//行注释

namespace HelloWorld
{
    /// <summary>
    /// 1. 注释
    ///    1.1 块注释
    ///        /* /**/  */
    ///    1.2 行注释  //
    /// 2. 变量
    ///     2.1 简单变量
    ///     2.1.1 数值 int  long float double byte bit char
    ///     2.1.2 文本 string  ==> char[]
    ///     2.2 自定义变量
    ///         struct
    ///         enum
    ///
    ///         class  类
    ///         inerface  接口
    /// 3. 变量的定义位置
    ///     3.1？ 命名空间外  ×
    ///     3.2？ 命名空间内， 类的定义外  ×
    ///     3.3？ 类的内部，函数或方法体外 √
    ///            类的成员变量  前边可加修饰符 readonly static public const
    ///     3.4？ 方法或函数内 √
    ///             局部变量
    ///     3.5？ 函数或方法的参数定义  √
    ///             函数的形参
    /// 4. 变量的静态与非静态 static 与 non static
    /// 类class 与 对象Object 实例 Instance
    ///
    /// 5. 变量的 值类型 与 引用类型
    /// 硬盘（磁盘、机械硬盘、SSD）==> 缓存（二级缓存） => 内存（RAM） => CPU
    /// 
    /// 值类型： Value Type
    /// int  long float double byte bit char
    /// bool
    /// struct
    /// enum
    /// DateTime
    /// 
    /// 引用类型
    /// class
    /// interface
    /// 
    /// 数组
    /// 
    /// string
    /// 
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {
            SPoint p1 = new SPoint();
            Console.WriteLine(p1);

            SPoint p2 = new SPoint("2", 200, 200, 200);
            Console.WriteLine(p2);

            double d = p1.Distance(p2);
            double d1 = p2.Distance(p1);
            Console.WriteLine($"p1->p2的距离为{d}");

            SPoint p3 = new SPoint(300, 300, 300);
            Console.WriteLine(p3);

            SPoint p4 = new SPoint(400, 400);
            p4.Y = -500;
            Console.WriteLine(p4);
            

            double d4 = SPoint.Distance(p3, p4);

            Circle c1 = new Circle(10);
            Console.WriteLine(c1);
            c1.R = 20;
            Console.WriteLine(c1);
        }
    }
}
