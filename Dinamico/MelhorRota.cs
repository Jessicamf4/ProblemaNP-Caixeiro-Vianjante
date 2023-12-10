using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class MelhorRota
{
    private double[,] DistanceMatrix { get; }
    private double[,] memo;
    private int[,] path;

    public MelhorRota(double[,] distanceMatrix)
    {
        this.DistanceMatrix = distanceMatrix;
        this.memo = new double[distanceMatrix.GetLength(0), 1 << distanceMatrix.GetLength(0)];
        this.path = new int[distanceMatrix.GetLength(0), 1 << distanceMatrix.GetLength(0)];
    }

    public void CalculaMelhorRota()
    {
        int n = DistanceMatrix.GetLength(0);
        int allVisited = (1 << n) - 1;

        double resultado = MinCusto(0, 1, n, allVisited);

        Console.WriteLine("Custo da Melhor Rota: " + resultado);
        MostraCaminho();
    }

    private void MostraCaminho()
    {
        Console.Write("Caminho percorrido: ");
        int cidadeAtual = 0;
        int mask = 1;
        int n = DistanceMatrix.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            int proximaCidade = path[cidadeAtual, mask];
            Console.Write($"{cidadeAtual} -> ");
            cidadeAtual = proximaCidade;
            mask |= (1 << cidadeAtual);
        }

        Console.WriteLine("0"); // Volta para a primeira cidade
    }

    private double MinCusto(int cidadeAtual, int mask, int n, int allVisited)
    {
        if (mask == allVisited)
            return DistanceMatrix[cidadeAtual, 0]; // Volta para a primeira cidade

        if (memo[cidadeAtual, mask] != 0)
            return memo[cidadeAtual, mask];

        double menorDistancia = double.PositiveInfinity;
        int proximaCidadeEscolhida = -1;

        for (int proximaCidade = 0; proximaCidade < n; proximaCidade++)
        {
            if ((mask & (1 << proximaCidade)) == 0)
            {
                double custo = DistanceMatrix[cidadeAtual, proximaCidade] + MinCusto(proximaCidade, mask | (1 << proximaCidade), n, allVisited);
                if (custo < menorDistancia)
                {
                    menorDistancia = custo;
                    proximaCidadeEscolhida = proximaCidade;
                }
            }
        }

        memo[cidadeAtual, mask] = menorDistancia;
        path[cidadeAtual, mask] = proximaCidadeEscolhida;

        return menorDistancia;
    }
}