using System;
using System.Runtime.CompilerServices;

namespace _007_PrimMST
{
    internal class Graph
    {
        static int MAX = 100; // 최대 버텍스 수
        static int INF = 000; // 무한대
        private int V; // 정점의 수?
        string[] vertex = new string[MAX];
        int[,] adj = new int[MAX, MAX]; // 인접행렬
        private int MSTWeight = 0;

        internal void Prim(int start) // 핵심
        {
            bool[] selected = new bool[V];
            int[] dist = new int[V];

            //초기화
            for (int i = 0; i < V; i++)
            {
                dist[i] = INF;
                selected[i] = false;
            }

            dist[start] = 0;

            for(int i = 0; i<V; i++)
            {
                int u = GetMinVertex(selected, dist);
                selected[i] = true; // 0번을 true로 바꾼다

                MSTWeight += dist[u]; // 처음에는 0이다. 
                Console.WriteLine("select={0},W={1}", vertex[u], MSTWeight);

                //dist[] 업데이트(가장핵심)
                for (int v = 0; v < V; v++) 
                    if (adj[u, v] != INF)
                        if (!selected[v] && adj[u, v] < dist[v])
                            dist[v] = adj[u, v];
                //B는3, D는2, E는 4로 업데이트
            }
        }

        private int GetMinVertex(bool[] selected, int[] dist)
        {
            int minV = 0;
            int minDist = INF;

            for (int v = 0; v < V; v++)
            {
                if (!selected[v] && dist[v] < minDist)
                {
                    minV = v;
                    minDist = dist[v];
                }
            }
            return minV;
        }
        

        internal void PrintGraph()
        {
            Console.WriteLine("vertax 수 = " + V);
            for(int i = 0; i<V; i++)
            {
                Console.Write(vertex[i]);
                for (int j = 0; j < V; j++)
                    Console.Write("{0,8}",adj[i,j]);
                Console.WriteLine();
            }

        }

        internal void ReadGraph(string filename)
        {
            string[] lines = System.IO.File.ReadAllLines("../../" + filename);

            V = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                // A    0   3   999 2   4   999
                string[] s = lines[i].Split('\t');

                InsertVertex(i - 1, s[0]);
                for (int j = 1; j < s.Length; j++)
                    InsertEdge(i - 1, j - 1, int.Parse(s[j]));

            }
        }

        private void InsertEdge(int i, int j, int w)
        {
            adj[i, j] = w;
        }

        private void InsertVertex(int index, string name)
        {
            vertex[index] = name;
        }
    }
}

