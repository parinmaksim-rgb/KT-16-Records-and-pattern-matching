using System;

public class Program
{
    public static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Выберите фигуру для проверки:");
            Console.WriteLine("1 - Окружность (Circle)");
            Console.WriteLine("2 - Прямоугольник (Rectangle)");
            Console.WriteLine("0 - Выход");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();

            if (choice == "0")
            {
                running = false;
                continue;
            }

            if (choice == "1")
            {
                Console.Write("Введите X центра окружности: ");
                double x = double.Parse(Console.ReadLine());

                Console.Write("Введите Y центра окружности: ");
                double y = double.Parse(Console.ReadLine());

                Console.Write("Введите радиус окружности: ");
                double radius = double.Parse(Console.ReadLine());

                Circle circle = new Circle(new Point(x, y), radius);

                Console.WriteLine();
                Console.WriteLine($"Входные данные: новый Circle с центром в ({circle.Center.X}, {circle.Center.Y}) и радиусом {circle.Radius}");
                Console.WriteLine($"Результат: {ShapeClassifier.Classify(circle)}");
            }
            else if (choice == "2")
            {
                Console.Write("Введите X левого верхнего угла: ");
                double x1 = double.Parse(Console.ReadLine());

                Console.Write("Введите Y левого верхнего угла: ");
                double y1 = double.Parse(Console.ReadLine());

                Console.Write("Введите X правого нижнего угла: ");
                double x2 = double.Parse(Console.ReadLine());

                Console.Write("Введите Y правого нижнего угла: ");
                double y2 = double.Parse(Console.ReadLine());

                Rectangle rect = new Rectangle(new Point(x1, y1), new Point(x2, y2));

                Console.WriteLine();
                Console.WriteLine($"Входные данные: новый Rectangle с TopLeft=({rect.TopLeft.X}, {rect.TopLeft.Y}) и BottomRight=({rect.BottomRight.X}, {rect.BottomRight.Y})");
                Console.WriteLine($"Результат: {ShapeClassifier.Classify(rect)}");
            }
            else
            {
                Console.WriteLine("Неверный выбор фигуры. Попробуйте снова.");
            }
        }
    }
}