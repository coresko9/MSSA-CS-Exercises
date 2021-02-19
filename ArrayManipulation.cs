using System;

namespace cssbs_ex05
{
    class Program
    {
        
        public static void ShiftArray(char dir, int shiftPlace, int[] arr)
        {
            Console.WriteLine();
            if (shiftPlace >= arr.Length)
            {
                do
                {
                    shiftPlace -= arr.Length;
                } while (shiftPlace > arr.Length);
                ShiftArray(dir, shiftPlace, arr);
            }
            else
            {
                int[] copyArr = new int[arr.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    copyArr[i] = arr[i];
                }
                if (char.ToLower(dir) == 'l')
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (i - shiftPlace < 0)
                        {
                            arr[(arr.Length + (i - shiftPlace))] = copyArr[i];
                        }
                        else
                        {
                            arr[i - shiftPlace] = copyArr[i];
                        }
                    }

                    Console.WriteLine();
                    Console.Write("input array:\t");
                    foreach (int copyA in copyArr)
                    {
                        Console.Write($"{copyA}, ");
                    }

                    Console.WriteLine($"\n\nshifting array to the left by {shiftPlace}\n");
                    Console.Write("shifted array:\t");
                    foreach (int a in arr)
                    {

                        Console.Write($"{a}, ");
                    }
                }
                else if (char.ToLower(dir) == 'r')
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (i + shiftPlace >= arr.Length)
                        {
                            copyArr[(shiftPlace +i)-arr.Length]=arr[i];
                        }
                        else
                        {
                             copyArr[i + shiftPlace]=arr[i] ;
                        }
                    }

                    Console.WriteLine();
                    Console.Write("input array:\t");
                    foreach (int copyA in arr)
                    {
                        Console.Write($"{copyA}, ");
                    }

                    Console.WriteLine($"\n\nshifting array to the right by {shiftPlace}\n");
                    Console.Write("shifted array:\t");
                    foreach (int a in copyArr)
                    {
                        Console.Write($"{a}, ");
                    }
                }
                else
                {
                    Console.WriteLine("wrong input");
                }
            }
        }
        public static void Reverse(int[] arr)
        {
            Console.WriteLine();
            Console.WriteLine("Reversing ......");
            int[] reverseArr = new int[arr.Length];
            for (int i = arr.Length - 1, a = 0; i >= 0; i--, a++)
            {
                reverseArr[i] = arr[a];
            }

            foreach (int item in reverseArr)
            {
                Console.Write($"{item}, ");
            }
        }
        public static double returnAvg(int[] arr)
        {
            int a = 0;
            foreach (var item in arr)
            {
                a += item;
            }
            Console.WriteLine($"the length is: {arr.Length}, sum of all numbers is: {a}");
            double retval = Convert.ToDouble(a);
            retval = retval / Convert.ToDouble(arr.Length);
            return retval;
        }
        //4,2,5,1,2,8,
        public static void SortArray(int[] arr)
        {
            Console.WriteLine();
            int temp;
            int i = 0;
            do
            {
                if (i == arr.Length-1)
                {
                    break;
                }
                else if (arr[i] <= arr[i + 1])
                {
                    i++;
                }
                else
                {
                    temp = arr[i + 1];
                    arr[i + 1] = arr[i];
                    arr[i] = temp;
                    i = 0;
                }

            } while (true);
            Console.Write("Sorted low to high:\t ");
            foreach (int item in arr)
            {
                Console.Write($"{item}, ");
            }
        }
        public static void StringToArray(string inputString)
        {
            var strArray = inputString.Split(' ');
            Console.WriteLine();
            string[] copyStrArray = new string[strArray.Length];
            for (int i = strArray.Length -1 , a = 0; i >= 0; i--, a++)
            {
                copyStrArray[i] = strArray[a];
            }
            foreach (var str in copyStrArray)
            {
                Console.WriteLine(str);
            }

        }
        static void Main(string[] args)
        {            
            int[] a = { 0, 2, 4, 6, 8, 10 };
            int[] b = { 1, 3, 5, 7, 9 };
            int[] c = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9 };
            double avgA = returnAvg(a);
            double avgB = returnAvg(b);
            double avgC = returnAvg(c);
            Console.WriteLine($"Average of a:\t {avgA}\nAverage of b:\t {avgB}\nAverage of c:\t {avgC}");
            Reverse(a);
            Reverse(b);
            Reverse(c);

            ShiftArray('r', 11, a);

            SortArray(c);

            StringToArray("Hello my name is Corey");
        }
    }
}
