using System;
using System.Collections.Generic;

class Questao1
{
    public static int IndiceMaximo(List <int> L, int inicio, int fim)
    {
        List <int> L_copy = new List <int> (L);
        int maior = L_copy[inicio], indiceMaior = inicio;

        for (int i = inicio; i < fim; i++)
        {
            if (L_copy[i] > maior)
            {
                maior = L_copy[i];
                indiceMaior = i;
            }
        }

        return indiceMaior;
    }

    public static List <int> Troca(List <int> L, int a, int b)
    {
        List <int> L_copy = new List <int> (L);
        int temp = L_copy[a];
        L_copy[a] = L_copy[b];
        L_copy[b] = temp;
        return L_copy;
    }

    public static List <int> SelectionSort(List <int> L)
    {
        List <int> L_copy = new List <int> (L);
        int index, N = L_copy.Count;
        for (int i = 1; i < N; i++)
        {
            index = IndiceMaximo(L_copy, 0, N - i);
            L_copy = Troca(L_copy, index, N - i);
        }
        return L_copy;
    }

    public static (List <int>, List <int>) OrdenarPares(List <int> L_1, List <int> L_2)
    {
        return (L_1, L_2);
    }
}

class Testes
{
    public static void Main(String[] args)
    {
        var a = new List <int> {1, 2, 4, 3, 0};
        var b = new List <int> {5, 3, 0};
        a = Questao1.SelectionSort(a);
        foreach (int element in a)
        {
            Console.WriteLine(element);
        }
    }
}