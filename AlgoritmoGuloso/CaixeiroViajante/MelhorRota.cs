using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixeiroViajante
{
    internal class MelhorRota
    {
        public double[,] DistanceMatrix { get; set; }

        public MelhorRota(double[,] distanceMatrix)
        {
            this.DistanceMatrix = distanceMatrix;
        }

    public void CalculaMelhorRota()
        {

            int cidades = DistanceMatrix.GetLength(0);
            int[] rota = new int[cidades];
            bool[] visitado = new bool[cidades];

            rota[0] = 0;
            visitado[0] = true;

            for(int i = 1; i < cidades; i++) 
            {
                int cidadeAtual = rota[i-1];
                int proximaCidade = -1;
                double menorDistancia = double.PositiveInfinity;
                for(int j = 0; j < cidades; j++)
                {
                    if (!visitado[j] && DistanceMatrix[cidadeAtual, j] < menorDistancia && DistanceMatrix[cidadeAtual, j] != DistanceMatrix[cidadeAtual,cidadeAtual])
                    {
                        menorDistancia = DistanceMatrix[cidadeAtual, j];
                        proximaCidade = j;
                    }
                }

                if (proximaCidade != -1)
                {
                    rota[i] = proximaCidade;
                    visitado[proximaCidade] = true;
                }
            }


            Console.WriteLine("Melhor Rota Encontrada:");
            for (int i = 0; i < cidades; i++)
            {
                Console.Write(rota[i] + " -> ");
            }
            Console.WriteLine(rota[0]); // Volta para a primeira cidade para fechar o ciclo

            double CalculaDistanciaTotal(int[] rota)
            {
                int cidades = rota.Length;
                double distanciaTotal = 0;

                for (int i = 0; i < cidades - 1; i++)
                {
                    distanciaTotal += DistanceMatrix[rota[i], rota[i + 1]];
                }

                // Adiciona a distância de retorno para a primeira cidade
                distanciaTotal += DistanceMatrix[rota[cidades - 1], rota[0]];

                return distanciaTotal;
            }
        }



    }
    
}





