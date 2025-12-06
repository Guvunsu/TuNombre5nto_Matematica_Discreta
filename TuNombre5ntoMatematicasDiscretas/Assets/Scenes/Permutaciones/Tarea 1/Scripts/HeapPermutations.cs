using UnityEngine;
using System.Collections.Generic;
public class HeapPermutations : MonoBehaviour
{   
    public List<List<int>> permutations = new List<List<int>>();
    private List<int> list = new List<int>();

    //void Start()
    //{
    //    list.Add(1);
    //    list.Add(2);
    //    list.Add(3);

    //    Heap(list.Count);
    //    PrintPermutations();
    //}
    public void GeneratePermutations(int n)
    {
        permutations.Clear();
        list.Clear();

        // Llenar la lista con los índices de prefabs
        for (int i = 0; i < n; i++)
            list.Add(i);

        Heap(n);
    } 

    public void PrintPermutations()
    {
        // Imprimir las permutaciones guardadas en la consola de Unity
        foreach (var permutation in permutations)
        {
            Debug.Log(string.Join(" ", permutation));
        }
    }

    void Heap(int size)
    {
        if (size == 1)
        {
            List<int> permutation = new List<int> (list);
            permutations.Add(permutation);
        }
        else
        {
            for (int i = 0; i < size; i++)
            {
                Heap(size - 1);
                if (size % 2 == 0)
                    Swap(i, size - 1);
                else
                    Swap(0, size - 1);
            }
        }
    }

    void Swap(int i, int j)
    {
        int temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}
