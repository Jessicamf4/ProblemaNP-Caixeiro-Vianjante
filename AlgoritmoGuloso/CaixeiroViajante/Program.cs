namespace CaixeiroViajante
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double[,] distanceMatrix = {
            {0, 10, 15, 20},
            {10, 0, 35, 25},
            {15, 35, 0, 30},
            {20, 25, 30, 0}
        };

            Console.WriteLine("Matriz de distâncias entre as cidades:");
            for (int i = 0; i < distanceMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < distanceMatrix.GetLength(1); j++)
                {
                    Console.Write(distanceMatrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            MelhorRota melhorRota = new MelhorRota(distanceMatrix);
            melhorRota.CalculaMelhorRota();

        }
    }

}