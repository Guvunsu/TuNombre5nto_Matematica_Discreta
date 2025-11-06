using System.Collections.Generic;
using UnityEngine;

public class EjerciciosList : MonoBehaviour
{
    void Start()
    {

    }
    void Temperatura(List<float> list)
    {
        List<float> temperatura = new List<float> { 20, 25 };
        temperatura.Add(21);
        temperatura.Add(22);
        temperatura.Add(23);
        Debug.Log(temperatura.Count);
        //List<float> list2Temperatura = new List<float> { };
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
            string Link;
            if (nombres.Contains("Link"))
            {

            }
            Debug.Log(invitado);
            return;
        }
        nombres.Remove("Juasjuasjuas");
    }
    void PuntuacionesVideojuego()
    {
        List<int> puntuaciones = new List<int> { 9, 29, 35, 26, 10, 48, 44, 1, 22, 50 };
        List<int> puntuacionesIntervalo = puntuaciones.GetRange(1, 50);
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
        Debug.Log(productosTiendita + "fueron añadidos ambas listas" + productosTiendita2);
        if (productosTiendita.Contains("papitas"))
        {
            productosTiendita.RemoveAt(3);
            Debug.Log("fue removido" + productosTiendita);
        }
        productosTiendita.Add("papitas");
        Debug.Log("fue añadido" + productosTiendita);
        productosTiendita.AddRange(productosTiendita2);
        Debug.Log("fueron acomodados" + productosTiendita + productosTiendita2);
        foreach (var item in productosTiendita)
        {
            productosTiendita.Clear();
            Debug.Log("fueron borrados ambas listas" + productosTiendita + productosTiendita2);
        }
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
            Debug.Log("fueron añadidos 30 calificaciones de" + calificaciones[i]);
        }
        calificaciones.Sort();
        Debug.Log("fueron acomodados las calificaciones de:" + calificaciones);
        List<int> calificaciones_menores60 = calificaciones.FindAll(nota => nota <= 60);
        Debug.Log(calificaciones_menores60.Count);
        List<int> calificaciones_mayores70A90 = calificaciones.FindAll(nota => nota > 70);
        Debug.Log(calificaciones_mayores70A90.Count);
    }
}
