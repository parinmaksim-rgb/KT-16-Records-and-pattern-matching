using System;

namespace KT16
{
    public class Program
    {
        public record Point(double X, double Y);

        public record Circle(Point Center, double Radius);

        public record Rectangle(Point TopLeft, Point BottomRight);

        public static void Main()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Выберите фигуру для проверки:");
                Console.WriteLine("1 - Окружность (Circle)");
                Console.WriteLine("2 - Прямоугольник (Rectangle)");
                Console.WriteLine("0 - Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        return; 

                    case "1":
                        {
                            Console.Write("Введите X центра: ");
                            double x = double.Parse(Console.ReadLine() ?? "0");

                            Console.Write("Введите Y центра: ");
                            double y = double.Parse(Console.ReadLine() ?? "0");

                            Console.Write("Введите радиус: ");
                            double radius = double.Parse(Console.ReadLine() ?? "0");

                            object shape = new Circle(new Point(x, y), radius);
                            Console.WriteLine($"\nРезультат: {Classify(shape)}\n");
                            break;
                        }

                    case "2":
                        {
                            Console.Write("Введите X левого верхнего угла (TopLeft X): ");
                            double x1 = double.Parse(Console.ReadLine() ?? "0");

                            Console.Write("Введите Y левого верхнего угла (TopLeft Y): ");
                            double y1 = double.Parse(Console.ReadLine() ?? "0");

                            Console.Write("Введите X правого нижнего угла (BottomRight X): ");
                            double x2 = double.Parse(Console.ReadLine() ?? "0");

                            Console.Write("Введите Y правого нижнего угла (BottomRight Y): ");
                            double y2 = double.Parse(Console.ReadLine() ?? "0");

                            object shape = new Rectangle(new Point(x1, y1), new Point(x2, y2));
                            Console.WriteLine($"\nРезультат: {Classify(shape)}\n");
                            break;
                        }

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        public static string Classify(object shape) => shape switch
        {
            Circle { Center: { X: 0, Y: 0 } } => "окружность в начале координат",
            Circle { Radius: 0 } => "вырожденная окружность (точка)",
            Circle c => $"радиус {c.Radius}",

            Rectangle r when r.TopLeft == r.BottomRight => "вырожденный прямоугольник (точка)",
            Rectangle r => $"размеры: ширина {Math.Abs(r.BottomRight.X - r.TopLeft.X)}, высота {Math.Abs(r.BottomRight.Y - r.TopLeft.Y)}",

            _ => "неизвестная фигура"
        };
    }
}