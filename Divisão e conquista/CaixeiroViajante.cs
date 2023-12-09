using System;
using System.Collections.Generic;

class TSP
{
    static int TSPDivideConquer(int[,] graph, bool[] visited, int currentCity, int n, List<int> path)
    {
        if (AllVisited(visited, n))
        {
            path.Add(0); // Adiciona a cidade inicial ao caminho
            return graph[currentCity, 0];
        }

        int minCost = int.MaxValue;
        int nextCity = -1;

        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                visited[i] = true;
                path.Add(i);

                int currentCost = graph[currentCity, i] + TSPDivideConquer(graph, visited, i, n, path);

                if (currentCost < minCost)
                {
                    minCost = currentCost;
                    nextCity = i;
                }

                visited[i] = false;
                path.RemoveAt(path.Count - 1);
            }
        }

        if (nextCity != -1)
            path.Add(nextCity);

        return minCost;
    }

    static bool AllVisited(bool[] visited, int n)
    {
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                return false;
            }
        }
        return true;
    }

    static void Main()
    {
        int n = 4;
        int[,] graph = {
            {0, 10, 15, 20},
            {10, 0, 35, 25},
            {15, 35, 0, 30},
            {20, 25, 30, 0}
        };

        bool[] visited = new bool[n];
        visited[0] = true;

        List<int> path = new List<int>();
        path.Add(0); // Inicia com a cidade 0

        int minCost = TSPDivideConquer(graph, visited, 0, n, path);

        Console.WriteLine("Menor custo do Caixeiro Viajante: " + minCost);
        Console.Write("Melhor rota encontrada: ");

        foreach (var city in path)
        {
            Console.Write(city + " ");
        }
    }
}