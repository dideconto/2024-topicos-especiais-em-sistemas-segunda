using System.Diagnostics;

namespace Exe02;

class Program
{
    static void Main(string[] args)
    {
        int[] vetor = new int[100];
        Random random = new Random();
        //Preenchendo o vetor com valores aleatórios
        for (int i = 0; i < vetor.Length; i++)
        {
            vetor[i] = random.Next(100);
        }
        //Imprimindo o vetor desordenado
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.Write(vetor[i] + " ");
        }
        Console.WriteLine("\n");

        //Ordenar o vetor com um recurso da linguagem
        Array.Sort(vetor);

        //Ordenar o vetor com o algoritmo bubble sort
        bool troca;
        do
        {
            troca = false;
            for (int i = 0; i < vetor.Length - 1; i++)
            {
                if (vetor[i] > vetor[i + 1])
                {
                    int aux = vetor[i];
                    vetor[i] = vetor[i + 1];
                    vetor[i + 1] = aux;
                    troca = true;
                }
            }
        } while (troca);

        //Imprimindo o vetor ordenado
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.Write(vetor[i] + " ");
        }
    }
}
