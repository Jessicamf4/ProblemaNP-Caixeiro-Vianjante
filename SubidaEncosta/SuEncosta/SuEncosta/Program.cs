using System;
using System.Collections.Generic;

class Program
{
    static Random random = new Random();

    // Função para calcular a distância entre duas cidades (pode ser substituída por lógica de distância real)
    static double CalcularDistancia(int cidade1, int cidade2, double[,] matrizDistancias)
    {
        return matrizDistancias[cidade1, cidade2];
    }

    // Função para calcular o custo do caminho
    static double CalcularCusto(List<int> caminho, double[,] matrizDistancias)
    {
        double custo = 0;
        for (int i = 0; i < caminho.Count - 1; i++)
        {
            custo += CalcularDistancia(caminho[i], caminho[i + 1], matrizDistancias);
        }
        return custo;
    }

    // Função para gerar um caminho inicial aleatório
    static List<int> GerarCaminhoInicial(int numCidades)
    {
        List<int> caminho = new List<int>();
        for (int i = 0; i < numCidades; i++)
        {
            caminho.Add(i);
        }
        for (int i = 0; i < numCidades; i++)
        {
            int temp = caminho[i];
            int randomIndex = random.Next(i, numCidades);
            caminho[i] = caminho[randomIndex];
            caminho[randomIndex] = temp;
        }
        return caminho;
    }

    // Algoritmo de busca local por Subida da Encosta
    static List<int> BuscaSubidaEncosta(int numCidades, double[,] matrizDistancias, int maxIteracoes)
    {
        List<int> melhorCaminho = GerarCaminhoInicial(numCidades);
        double melhorCusto = CalcularCusto(melhorCaminho, matrizDistancias);
        int iteracao = 0;

        while (iteracao < maxIteracoes)
        {
            List<int> vizinho = new List<int>(melhorCaminho);
            int posicao1 = random.Next(0, numCidades);
            int posicao2 = random.Next(0, numCidades);

            int temp = vizinho[posicao1];
            vizinho[posicao1] = vizinho[posicao2];
            vizinho[posicao2] = temp;

            double custoVizinho = CalcularCusto(vizinho, matrizDistancias);

            if (custoVizinho < melhorCusto)
            {
                melhorCaminho = new List<int>(vizinho);
                melhorCusto = custoVizinho;
            }

            iteracao++;
        }

        return melhorCaminho;
    }

    // Exemplo de uso
    static void Main(string[] args)
    {
        int numCidades = 4; // Número de cidades (altere conforme necessário)
        double[,] matrizDistancias = new double[,] {
        {0, 10, 15, 20},
            {10, 0, 35, 25},
            {15, 35, 0, 30},
            {20, 25, 30, 0}
    }; // Matriz de distâncias (substitua pelos valores reais)

        List<int> melhorCaminho = BuscaSubidaEncosta(numCidades, matrizDistancias, maxIteracoes: 1000);

        melhorCaminho.Add(melhorCaminho[0]); // Adiciona a cidade inicial ao final do caminho

        Console.WriteLine("Melhor caminho encontrado (incluindo retorno à cidade inicial):");
        foreach (int cidade in melhorCaminho)
        {
            Console.Write(cidade + " ");
        }
        Console.WriteLine();

        double melhorCusto = CalcularCusto(melhorCaminho, matrizDistancias);
        Console.WriteLine("Melhor custo encontrado: " + melhorCusto);
    }

}
