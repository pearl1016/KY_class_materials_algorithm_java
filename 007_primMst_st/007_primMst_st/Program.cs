using _007_PrimMST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//그래프 만드는 것 도 시험에 나올 확률 있음!

namespace _007_primMst_st
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();
            g.ReadGraph("graph.txt");
            g.PrintGraph();

            g.Prim(0); //0번 정점에서 출발하는 MST
        }
    }
}
