//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    class Graph{
public Graph(int n){
		N = n;
        G = new List<List<int>>();
        for (int i = 0; i < N; ++i)
            G.Add(new List<int>());
		GTC = new List<List<int>>();
        for (int i = 0; i < N; ++i)
            GTC.Add(new List<int>());
	}

        public int min(int a, int b){
            return a < b ? a : b;
        }
        
public void generate(int k){
		for (int v = 0; v < N; ++v){
			for (int to = v + 1; to < min(N, v + k + 1); ++to)
				G[v].Add(to);
		}	
	}
	
public	List<int> dfs(int v){
		if (GTC[v].Count() > 0) return GTC[v];
		
		var gtcu = new HashSet<int>();
		
		gtcu.Add(v);
		
		foreach (int to in G[v]){
            gtcu.UnionWith(dfs(to));
		}
	
        GTC[v] = gtcu.ToList();
    	return GTC[v];
	}

	int N;
	List<List<int>> G;
	List<List<int>> GTC;
};

    
    
    public class Program
    {
        public static void Main(string[] args)
        {
            //Your code goes here
            Console.WriteLine("Hello!");
            var G = new Graph(5000);
            G.generate(100);
            var vrtx = G.dfs(0);
            Console.WriteLine("Ololo! " + vrtx.Count().ToString());
        }
    }
}
