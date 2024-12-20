﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _014_Sorting
{
    internal class Program
    {
        static int N = 100;
        static int[] a = new int[N];
        static void Main(string[] args)
        {
            RandomInit();
            PrintArray();

            Console.WriteLine("\nArray.Sort()");
            RandomInit();
            Array.Sort(a);
            PrintArray();

            // 버블정렬
            RandomInit();
            BubbleSort();
            PrintArray();

            // 선택정렬
            RandomInit();
            SelectionSort();
            PrintArray();

            // 삽입정렬
            RandomInit();
            InsertionSort();
            PrintArray();

            // 쉘정렬
            RandomInit();
            ShellSort();
            PrintArray();
        }

        private static void ShellSort()
        {
            Console.WriteLine("\n쉘정렬 :");
            int[] h = { 0, 1, 4, 10, 23, 57, 132, 201, 701, 1750 };
            int index = 0;
            while (h[index] < N / 2)
                index++;
            int gap = h[--index];

            while (gap > 0)
            {
                Console.WriteLine("gap = " + gap);
                for (int i = gap; i<N; i++)
                {
                    int current = a[i];
                    int j = i;
                    while (j>=gap && a[j-gap] > current)
                    {
                        a[j] = a[j - gap];
                        j = j - gap;
                    }
                    a[j] = current;
                }
                PrintArray();
                gap = h[--index];
            }
        }

        private static void InsertionSort()
        {
            Console.WriteLine("\n삽입정렬");
            for (int i = 1; i<=N-1; i++)
            {
                int current = a[i];
                int j = i - 1;
                while (j >= 0 && a[j] > current)
                {
                    a[j + 1] = a[j];
                    j--;
                }
                a[j + 1] = current;
            }
        }

        private static void SelectionSort()
        {
            Console.WriteLine("\n선택정렬 :");
            for (int i = 0; i<N-1; i++)
            {
                int min = i;
                for (int j = i+1; j<N; j++)
                    if (a[j] < a[min])
                        min = j;
                swap(i, min);
            }
        }

        private static void BubbleSort()
        {
            Console.WriteLine("\n버블정렬: ");

            //for (int pass = 1; pass <= N - 1; pass++)
            //  for (int i = 1; i <= N - pass; i++)
            //    if (a[i - 1] > a[i])
            //      swap(i - 1, i);

            for (int i = 1; i <= N - 1; i++)
                for (int j = 1; j <= N - i; j++)
                    if (a[j - 1] > a[j])
                        swap(j - 1, j);
        }

        private static void swap(int i, int j)
        {
            int t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        private static void PrintArray()
        {
            foreach (var i in a)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        private static void RandomInit()
        {
            Random r = new Random();
            for (int i = 0; i<N; i++)
            {
                a[i] = r.Next(1000);
            }
        }
    }
}