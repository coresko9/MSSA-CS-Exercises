using System;
using System.Collections.Generic;
using static System.Math;

namespace Ex11Cs
{
    class Program
    {
        static List<double> distances2d = new List<double>();
        static List<double> distances3d = new List<double>();
        static double Find2dDistance(Dictionary<int, Tuple<int, int>> points)
        {
            double x1 = 0;
            double y1 = 0;
            double x2 = 0;
            double y2 = 0;

            foreach (KeyValuePair<int, Tuple<int, int>> item in points)
            {
                if (item.Key == 0)
                {
                    x1 = item.Value.Item1;
                    y1 = item.Value.Item2;
                }
                if (item.Key == 1)
                {
                    x2 = item.Value.Item1;
                    y2 = item.Value.Item2;
                }
            }
            double distance = Sqrt((Pow(x2 - x1,2)) + (Pow(y2 - y1, 2)));
            distances2d.Add(distance);
            return distance;

        }
        static void SmallestDistance2D()
        {
            Random val = new Random();

            int i = 0;
            while (i < 100)
            {


                Dictionary<int, Tuple<int, int>> points = new Dictionary<int, Tuple<int, int>>();
                points.Clear();
                points.Add(0, Tuple.Create(val.Next(0, 100), val.Next(0, 100)));
                points.Add(1, Tuple.Create(val.Next(0, 100), val.Next(0, 100)));


                foreach (KeyValuePair<int, Tuple<int, int>> item in points)
                {
                    Console.WriteLine($"\t(x , y)");

                    Console.WriteLine($"point = ({item.Value.Item1},{item.Value.Item2})");
                }
                Console.WriteLine(Find2dDistance(points));
                i++;

            }
            Console.WriteLine();
            distances2d.Sort();
            Console.WriteLine($"smallest distance = {distances2d[0]}");
            
        }
        static double Find3dDistance(Dictionary<int, Tuple<int, int,int>> points)
        {
            double x1 = 0;
            double y1 = 0;
            double x2 = 0;
            double y2 = 0;
            double z1 = 0;
            double z2 = 0;

            foreach (KeyValuePair<int, Tuple<int, int,int>> item in points)
            {
                if (item.Key == 0)
                {
                    x1 = item.Value.Item1;
                    y1 = item.Value.Item2;
                    z1 = item.Value.Item3;
                }
                if (item.Key == 1)
                {
                    x2 = item.Value.Item1;
                    y2 = item.Value.Item2;
                    z2 = item.Value.Item3;
                }
            }
            double distance = Sqrt((Pow(x2 - x1,2)) + (Pow(y2 - y1, 2)));
            distances3d.Add(distance);
            return distance;

        }
        static void SmallestDistance3D()
        {
            Random val = new Random();

            int i = 0;
            while (i < 100)
            {


                Dictionary<int, Tuple<int, int,int>> points3D = new Dictionary<int, Tuple<int, int,int>>();
                points3D.Clear();
                points3D.Add(0, Tuple.Create(val.Next(0, 100), val.Next(0, 100), val.Next(0, 100)));
                points3D.Add(1, Tuple.Create(val.Next(0, 100), val.Next(0, 100), val.Next(0, 100)));
                points3D.Add(2, Tuple.Create(val.Next(0, 100), val.Next(0, 100), val.Next(0, 100)));


                foreach (KeyValuePair<int, Tuple<int,int, int>> item in points3D)
                {
                    Console.WriteLine($"\t(x , y , z)");

                    Console.WriteLine($"point = ({item.Value.Item1},{item.Value.Item2},{item.Value.Item3})");
                }
                Console.WriteLine(Find3dDistance(points3D));
                i++;
            }
            Console.WriteLine();
            distances3d.Sort();
            Console.WriteLine($"smallest distance = {distances3d[0]}");
        }
        static void Main(string[] args)
        {
            string choice = "";

            while (choice.ToLower() != "exit")
            {
                Console.Clear();
                Console.WriteLine("2D or 3D");
                choice = Console.ReadLine();
                if (choice.ToLower() == "2d" || choice == "2")
                {
                    SmallestDistance2D();
                }
                else if (choice.ToLower() == "3d" || choice == "3")
                {
                    SmallestDistance3D();
                }
                else if(choice.ToLower() == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("invalid input");
                }
            }
        }
    }
}
