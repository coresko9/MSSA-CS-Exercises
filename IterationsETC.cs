using System;

namespace Exercise02
{
    class MainClass
    {

        public static int AddNums(int total = 0, int iterations=10)
        {
            Console.WriteLine($"#{10 - iterations}: Enter in a number between 0 and 100: ");

            int added = int.Parse(Console.ReadLine());
            total += added;
            if (iterations <= 0)
            {
 
                return total;
            }
            else
            {
                return AddNums(total, iterations - 1);
            }
        }

        public static char Letter(double total)
        {
            Console.Write($"total of 10 numbers: {total}");
            char grade;
            double average = total / 10.0;
            if (average < 60)
            {
                return grade = 'F'; 
            }
            else if (average < 70)
            {
                return grade = 'D';
            }
            else if (average < 80)
            {
                return grade = 'C';
            }
            else if (average < 90)
            {
                return grade = 'B';
            }
            else
            {
                return grade = 'A';
            }
        }
        public static double Average(int iterations, int initial, double total =0)
        {

            if (iterations <= 0)
            {

                Console.WriteLine($"total of: {total}");
                return (double) total / initial;
            }
            else
            {
                Console.WriteLine($"Enter a number {iterations} (to go)");
                return Average(iterations -1 , initial, total += double.Parse(Console.ReadLine()));

            }
            
            
        }

        public static int KeepAdding(int total = 0)
        {
            
            if (int.TryParse(Console.ReadLine(), out int add))
            {
                total += add;

                return KeepAdding(total);
            }
            else
            {
                return total;
            }
        }

        public static void Main(string[] args)
        {

            double total = AddNums();
            char letterGrade = Letter(total);
            Console.WriteLine($"total sum is: {total}\n \t average grade is: {total / 10.0}:   {letterGrade}");
            Console.WriteLine();

            Console.Write("how many numbers would you like to add and find the average of?: ");
            int iterations = int.Parse(Console.ReadLine());
            double average = Average(iterations, iterations);
            Console.WriteLine($"Average of the {iterations} numbers you entered is: {average}");

            Console.WriteLine();
            Console.WriteLine("type anything besides a number value to stop program and recieve your sum ,or type a number to keep adding it");
            int infinteAdd = KeepAdding();
            Console.WriteLine("your total is: " + infinteAdd );

           

        }
    }
}
