using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Conjuntos : MonoBehaviour
{
    List<string> A = new List<string> { "a", "b", "c", "d", "e", "f" };
    List<string> B = new List<string> { "d", "e", "f", "g" };
    List<string> C = new List<string> { "b", "c", "d", "e" };
    List<string> U = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
    void Start()
    {

    }
    public void SubConjuntos(List<string> A , List<string> B)
    {
        foreach (var element in A)
        {
            foreach (var elements in B)
            {
                A.Add(elements.ToString());
                if (B.Contains(elements.ToString()))
                {
                    B.Remove(elements.ToString());
                }
            }

            Debug.Log(("Imprimo estos elementos de:") + A + B);
        }
    }
    List<string> Interseccion(List<string> A, List<string> B)
    {
        List<string> resultado = new List<string>();
        foreach (var elemento in A)
        {
            if (B.Contains(elemento))
                resultado.Add(elemento);
        }
        return resultado;
    }
}
