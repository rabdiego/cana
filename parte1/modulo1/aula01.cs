using System;  // I/O
using System.Collections.Generic;  // Estrutura de lista

class Questao1
{
    public static int IndiceMaximo(List <int> L_1, List <int> L_2, int inicio, int fim)
    {
        // Copiando as listas para não bagunçar ponteiros
        List <int> L_1_copy = new List <int> (L_1);
        List <int> L_2_copy = new List <int> (L_2);

        int maior = L_1_copy[inicio], indiceMaior = inicio, N = L_1_copy.Count;  // .Count retorna o número de elementos da lista
        int fim_1, fim_2;

        if (fim < N)
        {
            fim_1 = fim;
            fim_2 = 0;
        }
        else
        {
            fim_1 = N;
            fim_2 = fim - N;
        }

        for (int i = inicio; i < fim_1; i++)
        {
            if (L_1_copy[i] > maior)
            {
                maior = L_1_copy[i];
                indiceMaior = i;
            }
        }

        for (int i = inicio; i < fim_2; i++)
        {
            if (L_2_copy[i] > maior)
            {
                maior = L_2_copy[i];
                indiceMaior = i + N;
            }
        }

        return indiceMaior;
    }

    public static (List <int>, List <int>) Troca(List <int> L_1, List <int> L_2, int a, int b)
    {
        List <int> L_1_copy = new List <int> (L_1);
        List <int> L_2_copy = new List <int> (L_2);

        int N = L_1_copy.Count, temp;

        if (a < N)
        {
            temp = L_1_copy[a];

            if (b < N)
            {
                L_1_copy[a] = L_1_copy[b];
                L_1_copy[b] = temp;
            }
            else
            {
                L_1_copy[a] = L_2_copy[b - N];
                L_2_copy[b - N] = temp;
            }
        }
        else
        {
            temp = L_2_copy[a - N];
            L_2_copy[a - N] = L_2_copy[b - N];
            L_2_copy[b - N] = temp;
        }

        return (L_1_copy, L_2_copy);
    }

    public static (List <int>, List <int>) SelectionSortDuplo(List <int> L_1, List <int> L_2)
    {
        List <int> L_1_copy = new List <int> (L_1);
        List <int> L_2_copy = new List <int> (L_2);
        int index, N = L_1_copy.Count;

        for (int i = 1; i < 2*N; i++)
        {
            index = IndiceMaximo(L_1_copy, L_2_copy, 0, 2*N - i + 1);
            (L_1_copy, L_2_copy) = Troca(L_1_copy, L_2_copy, index, 2*N - i);
        }

        return (L_1_copy, L_2_copy);
    }
}

class Testes
{
    public static void Main(String[] args)
    {
        var a = new List <int> {1, 8, 24, 2};
        var b = new List <int> {5, 3, 11, 9};
        (a, b) = Questao1.SelectionSortDuplo(a, b);
        foreach (int element in a)
        {
           Console.WriteLine(element);
        }
        foreach (int element in b)
        {
            Console.WriteLine(element);
        }
    }
}