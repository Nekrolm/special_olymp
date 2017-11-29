#include <iostream>
#include <algorithm>
#include <vector>
#include <iterator>
#include <set>
#include <unordered_set>

#define ALL(v) (v).begin(),(v).end() 

using namespace std;


class Graph{
public:
	Graph(int n){
		N = n;
		G.assign(N, vector<int>{});
		GTC.assign(N, vector<int>{});
	}

	void generate(int k){
		for (int v = 0; v < N; ++v){
			for (int to = v + 1; to < min(N, v + k + 1); ++to)
				G[v].push_back(to);
		}	
	}
	
	const vector<int>& dfs(int v){
		if (!GTC[v].empty()) return GTC[v];
	
		unordered_set<int> gtcu = {v};
		
		for (int to : G[v]){
			auto& gtc = dfs(to);
			gtcu.insert(ALL(gtc));
		}
		
		copy(ALL(gtcu), back_inserter(GTC[v]));
		
		return GTC[v];
	}

private:
	int N;
	vector<vector<int>> G;
	vector<vector<int>> GTC;
};

int main(){
    cout << "Hello!" << endl;
    Graph G(5000);
    G.generate(100);
    auto vrtx = G.dfs(0);
    cout << "Ololo! " << vrtx.size() << endl;
    return 0;
}
