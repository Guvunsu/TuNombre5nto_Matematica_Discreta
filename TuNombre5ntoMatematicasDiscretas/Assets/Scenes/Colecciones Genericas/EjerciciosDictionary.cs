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
        productos.Add("Brocas", 25);
        productos.Add("Llaves Inglesas", 12);
        productos.Add("Cintas Métricas", 30);
        string productoBuscado = "Clavos";
        if (productos.ContainsKey(productoBuscado))
        {
            Debug.Log($"El producto {productoBuscado} está disponible con {productos[productoBuscado]} unidades.");
        } else
        {
            Debug.Log($"El producto {productoBuscado} no está disponible.");
        }

        productos["Martillos"] = 0;
        productos["Tuercas"] = 0;

        List<string> productosAEliminar = new List<string>();
        foreach (var item in productos)
        {
            if (item.Value == 0)
            {
                productosAEliminar.Add(item.Key);
            }
        }
        foreach (string producto in productosAEliminar)
        {
            productos.Remove(producto);
        }

        Debug.Log("Inventario final (sin productos con cantidad 0):");
        foreach (KeyValuePair<string, int> par in productos)
        {
            Debug.Log($"{par.Key} → {par.Value} unidades");
        }
    }
    void TelefonosDeContactos()
    {
        Dictionary<string, string> contactos = new Dictionary<string, string>();

        contactos.Add("Carlos", "555-1111");
        contactos.Add("María", "555-2222");
        contactos.Add("Luis", "555-3333");

        string numeroBuscado = "555-2222";
        bool numeroExiste = contactos.ContainsValue(numeroBuscado);
        Debug.Log(numeroExiste ? $"El número {numeroBuscado} ya está registrado." : $"El número {numeroBuscado} no está registrado.");

        contactos.Add("Ana", "555-4444");
        Debug.Log("Agregado: Ana → 555-4444");

        string nuevoNumero = "555-3333";
        if (!contactos.ContainsValue(nuevoNumero))
        {
            contactos.Add("Pedro", nuevoNumero);
        } else
        {
            Debug.Log($"No se puede agregar a Pedro. El número {nuevoNumero} ya está registrado.");
        }

        Debug.Log("Lista final de contactos:");
        foreach (var contacto in contactos)
        {
            Debug.Log($"{contacto.Key} → {contacto.Value}");
        }
    }
}

