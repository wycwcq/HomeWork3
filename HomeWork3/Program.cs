using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    abstract class Shape
    {
        //面积
        public abstract double Calculate_Area();
        //周长
        public abstract double Calculate_Perimeter();
        //初始化
        public abstract void initialization();
    }

    //圆形
    class Circle : Shape
    {
        private double r;
        public Circle()
        {
            initialization();
        }
        public override double Calculate_Area()
        {
            return Math.PI * Math.Pow(r, 2);
        }
        public override double Calculate_Perimeter()
        {
            return 2 * Math.PI * r;
        }
        public override void initialization()
        {
            while (true)
            {
                Console.WriteLine("请输入圆的半径:");
                string res = "";
                res = Console.ReadLine();
                if (!double.TryParse(res, out r))
                {
                    Console.WriteLine("输入字段非法，");
                    continue;
                }
                break;
            }
        }
    }
    //长方形
    class Rectangle : Shape
    {
        private double width;
        private double height;
        public Rectangle()
        {
            initialization();
        }
        public override double Calculate_Area()
        {
            return width * height;
        }
        public override double Calculate_Perimeter()
        {
            return 2 * width + 2 * height;
        }
        public override void initialization()
        {
            while (true)
            {
                Console.WriteLine("请输入长方形的长：");
                string Widstr = Console.ReadLine();
                Console.WriteLine("请输入长方形的宽：");
                string Heistr = Console.ReadLine();
                if (!double.TryParse(Widstr, out width) || !double.TryParse(Heistr, out height))
                {
                    Console.WriteLine("输入数据存在非法字符");
                    continue;
                }
                break;
            }
        }
    }

    //三角形
    class Triangle : Shape
    {
        private double side1;
        private double side2;
        private double side3;
        public Triangle()
        {
            initialization();
        }
        public override double Calculate_Area()
        {
            double p = (side1 + side2 + side3) / 2;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }
        public override double Calculate_Perimeter()
        {
            return (side1 + side2 + side3);
        }
        public override void initialization()
        {
            while (true)
            {
                Console.Write("请输入三角形第1个边长：");
                string side1str = Console.ReadLine();
                Console.Write("请输入三角形第2个边长：");
                string side2str = Console.ReadLine();
                Console.Write("请输入三角形第3个边长：");
                string side3str = Console.ReadLine();
                if (!double.TryParse(side1str, out side1) || !double.TryParse(side2str, out side2) || !double.TryParse(side3str, out side3))
                {
                    Console.WriteLine("输入数据存在非法字符");
                    continue;
                }
                if (side1 + side2 <= side3 || side2 + side3 <= side1 || side1 + side3 <= side2)
                {
                    Console.WriteLine("此数据无法构成三角形！");
                    continue;
                }
                break;
            }
        }
    }
    //工厂
    class Factory
    {
        public static Shape CreateShape(int name)
        {
            switch (name)
            {
                case 1: return new Circle();
                case 2: return new Rectangle();
                case 3: return new Triangle();
                default:
                    return null;
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("请输入需要创建的图形个数:");
            string num = Console.ReadLine();
            for (int i = 0; i < int.Parse(num); i++)
            {
                int name = rnd.Next(1, 4);
                Shape shape = Factory.CreateShape(name);
                if (shape != null)
                {
                    Console.WriteLine("面积为:{0}\r\n周长为:{1}", shape.Calculate_Area(), shape.Calculate_Perimeter());
                }
                else
                {
                    Console.WriteLine("找不到指定的图形!");
                }

            }
            Console.ReadKey();
        }
    }
}
