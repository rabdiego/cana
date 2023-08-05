using System;
using System.Collections.Generic;

class MyTuple
{
    public int x;
    public int y;

    public void setValues(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int getIndex(int key)
    {
        if (key == 0)
        {
            return this.x;
        }
        else
        {
            return this.y;
        }
    }
}

public class Lista
{
    static int questao1(List<int> L)
    {
        /*
        Encontrar o maior número ímpar armazenado na lista L — (se houver algum)
        */

        int biggestOddNumber = L[0];

        foreach (int element in L)
        {
            if (element > biggestOddNumber && element % 2 != 0)
            {
                biggestOddNumber = element;
            }
        }

        if (biggestOddNumber % 2 == 0)
        {
            throw new ArgumentException("A lista precisa conter um número ímpar");
        }

        return biggestOddNumber;
    }

    static int questao2(List<int> L)
    {
        /*
        Encontrar o segundo maior número ímpar armazenado na lista L — (se ele existir)
        */

        if (L.Count < 2)
        {
            throw new ArgumentException("A lista precisa conter pelo menos dois elementos");
        }

        int biggestOddNumber = int.MinValue, secondBiggestOddNumber = int.MinValue;

        foreach (int element in L)
        {
            if (element % 2 != 0)
            {
                if (element > biggestOddNumber)
                {
                    secondBiggestOddNumber = biggestOddNumber;
                    biggestOddNumber = element;
                }
                else if (element > secondBiggestOddNumber)
                {
                    secondBiggestOddNumber = element;
                }
            }
        }
        
        if (secondBiggestOddNumber == int.MinValue)
        {
            throw new ArgumentException("A lista precisa conter pelo menos dois elementos ímpares");
        }

        return secondBiggestOddNumber;
    }

    static int questao3(List <int> L)
    {
        /*
        Encontrar o terceiro maior elemento da lista L
        */

        if (L.Count < 3)
        {
            throw new ArgumentException("A lista precisa conter pelo menos três números");
        }

        int biggestNumber = int.MinValue, secondBiggestNumber = int.MinValue, thirdBiggestNumber = int.MinValue;

        foreach (int element in L)
        {
            if (element > biggestNumber)
            {
                thirdBiggestNumber = secondBiggestNumber;
                secondBiggestNumber = biggestNumber;
                biggestNumber = element;
            }
            else if (element > secondBiggestNumber)
            {
                thirdBiggestNumber = secondBiggestNumber;
                secondBiggestNumber = element;
            }
            else if (element > thirdBiggestNumber)
            {
                thirdBiggestNumber = element;
            }
        }

        return thirdBiggestNumber;
    }

    static int questao4(List <int> L, int k)
    {
        /*
        Encontrar o k-ésimo maior elemento da lista L
        */

        //! Não consegui fazer sem recursão ou ordenando a lista

        if (L.Count < k)
        {
            throw new ArgumentException("A lista deve conter pelo menos " + k + " elemento(s).");
        }

        return 1;
    }

    static int questao5(List <int> L, int k)
    {
        /*
        Procurar o número k na lista L, e se ele não estiver lá,
        retornar o elemento da lista com valor mais próximo de k
        */

        int value = L[0], smallestDifference = Math.Abs(L[0] - k), difference;

        if (smallestDifference == 0)
        {
            return L[0];
        }

        foreach (int element in L)
        {
            difference = Math.Abs(element - k);

            if (difference == 0)
            {
                return element;
            }
            else if (difference < smallestDifference)
            {
                smallestDifference = difference;
                value = element;
            }
        }

        return value;
    }

    static int questao6(List <int> L)
    {
        /*
        Verificar se existe algum número ímpar
        que aparece um número ímpar de vezes na lista L
        */

        var auxiliaryList = new List<int>();
        var visited = new List<bool>();
        int value;

        for (int i = 0; i < L.Count; i++)
        {
            auxiliaryList.Add(0);
            visited.Add(false);
        }

        for (int i = 0; i < L.Count; i++)
        {
            if (visited[i] == false)
            {
                value = L[i];

                for (int j = i; j < L.Count; j++)
                {
                    if (L[j] == value)
                    {
                        auxiliaryList[i]++;
                        visited[j] = true;
                    }
                }
            }
        }

        for (int i = 0; i < L.Count; i++)
        {
            if (L[i] % 2 != 0 && auxiliaryList[i] % 2 != 0)
            {
                return L[i];
            }
        }

        throw new ArgumentException("Não foi encontrado um elemento ímpar que aparece um número ímpar de vezes.");
    }

    static Tuple <int, int> questao7(List <int> L)
    {
        /*
        Verificar se existem dois elementos na lista L tal que um deles é o dobro do outro
        */

        for (int i = 0; i < L.Count; i++)
        {
            for (int j = i + 1; j < L.Count; j++)
            {
                if (L[j] == 2*L[i])
                {
                    var returnTuple = new Tuple <int, int> (L[i], L[j]);
                    return returnTuple;
                }
                else if (L[i] == 2*L[j])
                {
                    var returnTuple = new Tuple <int, int> (L[j], L[i]);
                    return returnTuple;
                }
            }
        }

        throw new ArgumentException("Não foi encontrado um número que é o dobro do outro.");
    }

    static Tuple <int, int> questao8(List <int> L)
    {
        /*
        Encontrar os dois elementos da lista L que possuem
        a menor diferença entre si — (em valor absoluto)
        */

        int difference, smallestDifference = int.MaxValue;
        MyTuple myTuple = new MyTuple();

        for (int i = 0; i < L.Count; i++)
        {
            for (int j = 0; j < L.Count; j++)
            {
                if (i != j)
                {
                    difference = Math.Abs(L[i] - L[j]);
                    
                    if (difference < smallestDifference)
                    {
                        smallestDifference = difference;
                        myTuple.setValues(L[i], L[j]);
                    }
                }
            }
        }

        var returnTuple = new Tuple <int, int> (myTuple.getIndex(0), myTuple.getIndex(1));
        return returnTuple;
    }

    static int questao9(List <int> L)
    {
        /*
        Contar o número de inversões na lista L
        */
        int count = 0;

        for (int i = 0; i < L.Count; i++)
        {
            for (int j = i + 1; j < L.Count; j++)
            {
                if (L[i] > L[j])
                {
                    count++;
                }
            }
        }

        return count;
    }

    static HashSet <int> questao10(List <int> L_1, List <int> L_2)
    {
        /*
        Imprimir todos os números que aparecem nas duas listas
        */

        var mySet = new HashSet <int> ();

        foreach (int element_1 in L_1)
        {
            foreach (int element_2 in L_2)
            {
                if (element_1 == element_2)
                {
                    mySet.Add(element_1);
                }
            }
        }

        return mySet;
    }

    public static void Main(String[] args)
    {
        var asd = new List<int>(){9, 42, 21, 14, 25, 3, 19, 33, 45, 6};
        var qwe = new List<int>(){2, 15, 19, 12, 33, 9, 17, 41, 54, 8};
        HashSet <int> set = questao10(asd, qwe);

        Console.Write("(");
        foreach(int element in set)
        {
            Console.Write(element + ", ");
        }
        Console.WriteLine(")");
    }
}