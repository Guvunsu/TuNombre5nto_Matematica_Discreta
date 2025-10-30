using UnityEngine;
using System.Collections.Generic;

public class EjerciciosDictionary : MonoBehaviour
{
    void Start()
    {

    }
    void PaisesCapitales()
    {
        Dictionary<int, string> paises = new Dictionary<int, string>()
        {
            {1, "Japon"} ,
            { 2, "Mexico" },
            { 3, "Alemania"},
            { 4 , "USA"},
            { 5,"Canada"}
        };
        Dictionary<string, int> capitales = new Dictionary<string, int>()
        {
            { "Tokyo",1} ,
            { "CDMX", 2 },
            { "Berlin", 3},
            { "Washington DC" ,4},
            { "Toronto",5}
        };
        bool isTrue = capitales.ContainsKey("Japon");
        bool istrueCa = paises.ContainsKey(1);
        Dictionary<string, string> parejas = new Dictionary<string, string>();
        parejas.Add("Japon", "Tokyo");
        parejas.Remove("Japon");
    }

    void InventarioProductos()
    {
        Dictionary<string, int> productos = new Dictionary<string, int>();
        productos.Add("Martillos", 1);
        productos.Add("Clavos", 2);
        productos.Add("Tornillos", 3);

        if (productos.ContainsKey("Clavos"))
        {
            Debug.Log(productos);
        }
    }
}
