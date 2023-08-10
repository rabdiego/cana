using System;  // I/O
using System.Collections.Generic;  // Estrutura de lista

class Questao1
{
    private static int IndiceMaximo(List <int> L_1, List <int> L_2, int inicio, int fim)
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

        // Tudo em cima é O(1)*
        // * Tecnicamente a função de copiar é O(n), mas para fins da disciplina, é possível assumir O(1)

        // O(n)
        for (int i = inicio; i < fim_1; i++)
        {
            // O(1)
            if (L_1_copy[i] > maior)
            {
                maior = L_1_copy[i];
                indiceMaior = i;
            }
        }

        // O(n)
        for (int i = inicio; i < fim_2; i++)
        {
            // O(1)
            if (L_2_copy[i] > maior)
            {
                maior = L_2_copy[i];
                indiceMaior = i + N;
            }
        }

        // Total: O(n)
        return indiceMaior;
    }

    private static (List <int>, List <int>) Troca(List <int> L_1, List <int> L_2, int a, int b)
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

        // Tudo é O(1)

        return (L_1_copy, L_2_copy);
    }

    public static (List <int>, List <int>) SelectionSortDuplo(List <int> L_1, List <int> L_2)
    {
        List <int> L_1_copy = new List <int> (L_1);
        List <int> L_2_copy = new List <int> (L_2);
        int index, N = L_1_copy.Count;

        // Tudo em cima é O(1)

        for (int i = 1; i < 2*N; i++)  // O(n)
        {
            index = IndiceMaximo(L_1_copy, L_2_copy, 0, 2*N - i + 1);  // O(n)
            (L_1_copy, L_2_copy) = Troca(L_1_copy, L_2_copy, index, 2*N - i);  // O(1)
        }

        // Total: O(n²)
        return (L_1_copy, L_2_copy);
    }
}

class Questao2
{
    private static int IndiceMinimo(List <int> L, int inicio, int fim)
    {
        List <int> L_copy = new List <int> (L);

        int menor = L_copy[inicio], indiceMenor = inicio, N = L_copy.Count;

        for (int i = inicio; i < fim; i += 2)
        {
            if (L[i] < menor)
            {
                menor = L[i];
                indiceMenor = i;
            }
        }

        return indiceMenor;
    }

    private static List <int> Trocar(List <int> L, int a, int b)
    {
        List <int> L_copy = new List <int> (L);

        int temp = L_copy[a];
        L_copy[a] = L_copy[b];
        L_copy[b] = temp;

        return L_copy;
    }

    public static List <int> OrdenaParidade(List <int> L)
    {
        var L_copy = new List <int> (L);
        int index, N = L_copy.Count;

        // O(n)
        for (int i = 0; i < N; i++)
        {
            index = IndiceMinimo(L_copy, i, N);  // O(n)
            L_copy = Trocar(L_copy, index, i);  // O(1)
        }

        // Total: O(n²) [não mudou nada da última questão pra essa]
        return L_copy;
    }
}

class Questao3
{
    // Idéia: Primeiro ordenamos a lista, depois achamos o pivô, vemos qual partição é menor, a que for, "refletimos" ela

    private static int IndiceMaximo(List <int> L, int inicio, int fim)
    {
        List <int> L_copy = new List <int> (L);

        int maior = L_copy[inicio], indiceMaior = inicio, N = L_copy.Count;

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

    private static List <int> Trocar(List <int> L, int a, int b)
    {
        List <int> L_copy = new List <int> (L);

        int temp = L_copy[a];
        L_copy[a] = L_copy[b];
        L_copy[b] = temp;

        return L_copy;
    }

    private static List <int> SelectionSort(List <int> L, int a, int b, bool crescente)
    {
        var L_copy = new List <int> (L);
        int index, N = L_copy.Count;

        if (crescente == true)
        {
            for (int i = a; i < b; i++)
            {
                index = IndiceMaximo(L_copy, a, b - (i - a));
                L_copy = Trocar(L_copy, index, b - (i - a) - 1);
            }
        }
        else
        {
            for (int i = a; i < b; i++)
            {
                index = IndiceMaximo(L_copy, i, b);
                L_copy = Trocar(L_copy, index, i);
            }
        }

        return L_copy;
    }

    public static List <int> OrdenaUnimodal(List <int> L, int k)
    {
        var L_copy = new List <int> (L);
	    int N = L.Count;

	    L_copy = SelectionSort(L_copy, 0, N, true);  // O(n²)

        if (N - k > k)
        {
            L_copy = SelectionSort(L_copy, k, N, false);  // O(n²)
        }
        else
        {
            L_copy = SelectionSort(L_copy, 0, k, false);  // O(n²)
        }

        // Total: O(n²)
        return L_copy;
    }
}

class Questao4
{
    // Essa eu não consegui fazer por completo, pois quando há elementos iguais, quebra a lógica
    // Lógica que é bem simples, primeiro você ordena a lista, e depois vai trocando os valores
    // das duplas de índices (2,3), (6,7), (10, 11)...

    private static int IndiceMaximo(List <int> L, int inicio, int fim)
    {
        List <int> L_copy = new List <int> (L);

        int maior = L_copy[inicio], indiceMaior = inicio, N = L_copy.Count;

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

    private static List <int> Trocar(List <int> L, int a, int b)
    {
        List <int> L_copy = new List <int> (L);

        int temp = L_copy[a];
        L_copy[a] = L_copy[b];
        L_copy[b] = temp;

        return L_copy;
    }

    private static List <int> SelectionSort(List <int> L, int a, int b, bool crescente)
    {
        var L_copy = new List <int> (L);
        int index, N = L_copy.Count;

        if (crescente == true)
        {
            for (int i = a; i < b; i++)
            {
                index = IndiceMaximo(L_copy, a, b - (i - a));
                L_copy = Trocar(L_copy, index, b - (i - a) - 1);
            }
        }
        else
        {
            for (int i = a; i < b; i++)
            {
                index = IndiceMaximo(L_copy, i, b);
                L_copy = Trocar(L_copy, index, i);
            }
        }

        return L_copy;
    }

    public static List <int> OrdenaZigZag(List <int> L)
    {
        var L_copy = new List <int> (L);
        int N = L_copy.Count;

        L_copy = SelectionSort(L_copy, 0, N, true);  // O(n²)

        // O(n)
        for (int i = 3; i < N; i += 4)
        {
            L_copy = Trocar(L_copy, i, i-1);  // O(1)
        }

        // Total: O(n²)
        return L_copy;
    }
}

class Questao5
{
    // Omiti a análise de tempo pois é praticamente o mesmo algorítmo que usei na questão 2
    
    private static int IndiceMinimo(List <int> L, int inicio, int fim)
    {
        List <int> L_copy = new List <int> (L);

        int menor = L_copy[inicio], indiceMenor = inicio, N = L_copy.Count;

        for (int i = inicio; i < fim; i += 2)
        {
            if (L[i] < menor)
            {
                menor = L[i];
                indiceMenor = i;
            }
        }

        return indiceMenor;
    }

    private static List <int> Trocar(List <int> L, int a, int b)
    {
        List <int> L_copy = new List <int> (L);

        int temp = L_copy[a];
        L_copy[a] = L_copy[b];
        L_copy[b] = temp;

        return L_copy;
    }

    public static List <int> OrdenaImpar(List <int> L)
    {
        var L_copy = new List <int> (L);
        int index, N = L_copy.Count;

        for (int i = 1; i < N; i += 2)
        {
            index = IndiceMinimo(L_copy, i, N);
            L_copy = Trocar(L_copy, index, i);
        }

        return L_copy;
    }
}


class Testes
{
    public static void Main(String[] args)
    {
        var a = new List <int> {22, 28, 22, 28, 50, 39, 44, 3, 8, 33, 45, 16, 12, 3, 19, 16, 48, 46, 12, 9, 27, 50, 34, 41, 40, 21, 27, 10, 35, 14};
        a = Questao5.OrdenaImpar(a);
        
        for (int i = 0; i < a.Count; i++)
        {
            if (i % 2 != 0)
            {
                for (int j = 0; j < a[i]; j++)
                {
                    Console.Write("#");
                }
                Console.WriteLine("");
            }
            
        }
    }
}