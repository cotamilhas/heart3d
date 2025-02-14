using System;
using System.Threading;

class RotatingHeart3D
{
    static void Main()
    {
        const int width = 40;
        const int height = 20;
        const double angleStep = Math.PI / 30;
        double angle = 0;

        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            DrawHeart3D(width, height, angle);
            angle += angleStep;
            Thread.Sleep(50);
        }
    }

    static void DrawHeart3D(int width, int height, double angle)
    {
        char[,] buffer = new char[height, width];
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                buffer[y, x] = ' ';

        for (double t = 0; t < 2 * Math.PI; t += 0.1)
        {
            for (double z = -1; z <= 1; z += 0.2)
            {
                double x = 16 * Math.Pow(Math.Sin(t), 3);
                double y = 13 * Math.Cos(t) - 5 * Math.Cos(2 * t) - 2 * Math.Cos(3 * t) - Math.Cos(4 * t);

                double rotatedX = x * Math.Cos(angle) - z * Math.Sin(angle);
                double rotatedZ = x * Math.Sin(angle) + z * Math.Cos(angle);
                double rotatedY = y;

                int drawX = (int)(width / 2 + rotatedX / 2);
                int drawY = (int)(height / 2 - rotatedY / 2);

                if (drawX >= 0 && drawX < width && drawY >= 0 && drawY < height)
                    buffer[drawY, drawX] = '*';
            }
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
                Console.Write(buffer[y, x]);
            Console.WriteLine();
        }
    }
}