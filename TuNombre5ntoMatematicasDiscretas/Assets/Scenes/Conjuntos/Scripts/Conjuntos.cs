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
        SubConjuntos();
        // Conjuntoss();
        //Interseccion();
    }
    public void SubConjuntos(List<string> A = new List<string>)
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
    //public void Conjuntoss()
    //{
    //    foreach (var element in )
    //}
    public void Interseccion(List<string> list1, List<string> list2)
    {
        foreach (var element in A)
        {
            foreach (var elements in B)
            {

                if (A.Contains(element) != B.Contains(element))
                {
                    Debug.Log("La Interseccion es:" + element);

                }
            }
        }
    }
}
