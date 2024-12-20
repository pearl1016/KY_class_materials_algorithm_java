﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace floyd_warshall
{
    public class Program
    {
        static int V = 5; // 정점의 개수
        const int Inf = 100;

        static void Main(string[] args)
        {
            int[,] graph =
            {
                {0, 4, 2, 5, Inf },
                {Inf, 0, 1, Inf, 4},
                {1, 3, 0, 1, 2},
                {-2, 2, 0, 0, 2 },
                {Inf, -3, -2, 1, 0 }
            };

            FloydWarshall(graph, V);
        }

        private static void FloydWarshall(int[,] graph, int v)
        {
            Console.WriteLine("Graph");
            PrintGraph(graph, v);

            for(int k = 0; k<v; k++)
            {
                for(int i = 0; i<v; i++)
                {
                    for(int j=0; j<v; j++)
                    {
                        // D[i,j] = min{D[i,k]+D[k,j], D[i,j]}
                        if (graph[i,k] != Inf && graph[k,j] != Inf &&
                            graph[i,j] > graph[i,k] + graph[k,j])
                        {
                            graph[i, j] = graph[i, k] + graph[k, j];
                            Console.WriteLine("Change : {0}:{1} = [{2},{3}]+[{4},{5}] = {6}",
                                i, k, i, k, k, j, graph[i,j]);
                        }

                    }
                }
            }
            PrintGraph(graph, V);
               
        }

        private static void PrintGraph(int[,] graph, int v)
        {
            for (int i = 0; i<v; i++)
            {
                for(int j = 0; j<v; j++)
                    Console.WriteLine("{0, 8", graph[i, j]);
                Console.WriteLine();
                   
            }
        }
    }
}