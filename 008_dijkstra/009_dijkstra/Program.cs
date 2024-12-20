﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace _009_dijkstra
{

    class Program
    {
        static int V = 10;
        string[] city = { "서울", "천안", "원주", "강릉", "논산", "대전", "대구", "포항", "광주", "부산" };
        static bool[] sptSet = new bool[V]; // shortest path 집합, true이면 포함
        static int[] D = new int[V]; //최단경로의 값을 저장



        static void Main(string[] args)
        {
            int[,] graph = new int[,]
            {
                { 0,   12,  15,  0,   0,   0,   0,   0,   0,   0 },
                { 12,  0,   0,   0,   4,   10,  0,   0,   0,   0 },
                { 15,  0,   0,   21,  0,   0,   7,   0,   0,   0 },
                { 0,   0,   21,  0,   0,   0,   0,   25,  0,   0 },
                { 0,   4,   0,   0,   0,   3,   0,   0,   13,  0 },
                { 0,   10,  0,   0,   3,   0,   10,  0,   0,   0 },
                { 0,   0,   7,   0,   0,   10,  0,   19,  0,   9 },
                { 0,   0,   0,   25,  0,   0,   19,  0,   0,   5 },
                { 0,   0,   0,   0,   13,  0,   0,   0,   0,   15 },
                { 0,   0,   0,  0,   0,   0,   9,   5,   15,  0 } 
            };

            Shortestpath(graph, 0); //0은 처음 시작하는 도시의 인덱스


        }

        //graph에 대해서 s 버텍스에서 출발하는 최단경로 구하기
        private static void Shortestpath(int[,] graph, int s) //알고리즘 시작
        {
            for(int i=0; i<V; i++)
            {
                D[i] = int.MaxValue;
                sptSet[i] = false;
            }

            D[s] = 0;

            //(mindistance찾는거 핵심)
            for (int i = 0; i<V-1; i++)
            {
                int min = MinDistance();
                sptSet[min] = true;

                //D[] 배열을 업데이트 해야함.((가장핵심!!!!!!)
                for(int v=0; v<V; v++)
                {
                    //아직 결정되지 않은 버텍스 중에서, min와 연결되었고,
                    // 현재까지 알려진 최단경로보다 지금 찾아진 min을  통한 거리가 더 가까우면 ~ 이라는 뜻
                    if (sptSet[v] == false&&graph[min, v] != 0 &&
                        D[min] + graph[min,v] < D[v])
                    {
                        D[v] = D[min] + graph[min, v];
                    }
                }

                Console.WriteLine("최단경로 버텍스 : {0}", city[min]);
                PrintDist();

            }
        }

        private static void PrintDist()
        {
            for(int i=0; i<V; i++)
            {
                Console.WriteLine("{0}:{1}", city[i], D[i]);
            }
        }

        //D[]에서 가장 작은 값을 갖는 인덱스를 리턴한다.
        //대신 조건은 sptSet[i]는 false인 것 중에서 찾는다.
        private static int MinDistance() //최솟값 찾는 알고리즘
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for(int i=0; i<V; i++)
            {
                if (sptSet[i] == false && D[i] < min)
                {
                    min = D[i];
                    minIndex = i;
                }
            }
        }
    }

}
