using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EjerciciosList : MonoBehaviour
{
    List<float> list;
    char letraFiltro;
    void Start()
    {
        Temperatura(list);
        //ListaInvitados();
        //PuntuacionesVideojuego();
        //InventarioTiendita();
        //CalificacionesExamenes();
        //GestionInventarioProductos(letraFiltro);
    }
    void Temperatura(List<float> list)
    {
        List<float> temperatura = new List<float> { 20, 25 };
        temperatura.Add(21);
        temperatura.Add(22);
        temperatura.Add(23);
        Debug.Log(temperatura.Count);
        temperatura.Sort();
        Debug.Log(temperatura.Count);
        temperatura.GetRange(0, 5);
        Debug.Log(temperatura.Count);
    }
    void ListaInvitados()
    {
        List<string> nombres = new List<string> { "Mario", "Luigi", "Toad", "Peach", "Daisy" };
        nombres.Add("Iwata");
        nombres.Add("Kojima");
        nombres.Add("Juasjuasjuas");
        nombres.Add("Regi");

        foreach (var invitado in nombres)
        {
            if (nombres.Contains("Link"))
            {
                Debug.Log("Link está en la lista.");
            }
            Debug.Log(invitado);
            return;
        }

        nombres.Remove("Juasjuasjuas");
    }
    void PuntuacionesVideojuego()
    {
        List<int> puntuaciones = new List<int> { 9, 29, 35, 26, 10, 48, 44, 1, 22, 50 };
        List<int> puntuacionesIntervalo = puntuaciones.GetRange(1, 5);
        puntuacionesIntervalo.Sort();
        puntuaciones.Add(19);
        puntuaciones.AddRange(puntuacionesIntervalo);
        puntuaciones.IndexOf(50);
    }
    void InventarioTiendita()
    {
        List<string> productosTiendita = new List<string> { "chela", "gansito", "chesco", "papitas", "cigarros", "chicles" };
        List<string> productosTiendita2 = new List<string> { "cocaina", "marihuana", "fentanilo", "DMT", "LSD", "Extasis" };
        productosTiendita.AddRange(productosTiendita2);
        Debug.Log("Fueron añadidos ambas listas: ");

        if (productosTiendita.Contains("papitas"))
        {
            productosTiendita.Remove("papitas");
            Debug.Log("‘Papitas’ fue removido de la lista.");
        }

        productosTiendita.Add("papitas");
        Debug.Log("‘Papitas’ fue añadido nuevamente.");

        productosTiendita.Sort();
        Debug.Log("Lista ordenada: " + string.Join(", ", productosTiendita));

        productosTiendita.Clear();
        Debug.Log("Fueron borrados ambas listas.");
    }
    void CalificacionesExamenes()
    {
        int cantidad_calificaciones = 30;
        int min_calificacion = 0;
        int max_calificacion = 101;
        List<int> calificaciones = new List<int>();

        for (int i = 0; i < cantidad_calificaciones; i++)
        {
            int nota = Random.Range(min_calificacion, max_calificacion);
            calificaciones.Add(nota);
        }

        calificaciones.Sort();
        Debug.Log("Calificaciones ordenadas: " + string.Join(", ", calificaciones));

        List<int> calificaciones_menores60 = calificaciones.FindAll(nota => nota <= 60);
        Debug.Log("Cantidad de calificaciones menores o iguales a 60: " + calificaciones_menores60.Count);

        List<int> calificaciones_70a90 = calificaciones.FindAll(nota => nota >= 70 && nota <= 90);
        Debug.Log("Cantidad de calificaciones entre 70 y 90: " + calificaciones_70a90.Count);
    }
    void GestionInventarioProductos(char letraFiltro) // me ayudo chatgpt
    {
        List<string> productos = new List<string>
        {
            " laptop ", "Mouse", " teclado", "Monitor", "cable HDMI", " mouse",
            "Laptop", "monitor", " teclado ", "Cargador"
        };

        for (int i = 0; i < productos.Count; i++)
        {
            productos[i] = productos[i].Trim().ToUpper();
        }
        List<string> inventarioLimpio = productos.Distinct().ToList();
        inventarioLimpio.Sort();
        inventarioLimpio.Reverse();

        int indexLaptop = inventarioLimpio.IndexOf("LAPTOP");
        if (indexLaptop != -1)
        {
            inventarioLimpio.Insert(indexLaptop + 1, "TABLET");
            inventarioLimpio.Insert(indexLaptop + 2, "SMARTPHONE");
        }

        Debug.Log(" Inventario limpio y ordenado:");
        foreach (string producto in inventarioLimpio)
        {
            Debug.Log(producto);
        }
        List<string> filtrados = inventarioLimpio.FindAll(p => p.StartsWith(letraFiltro.ToString().ToUpper()));

        Debug.Log($" Productos que comienzan con '{letraFiltro}':");
        foreach (string item in filtrados)
        {
            Debug.Log(item);
        }
    }
}
