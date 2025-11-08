using System.Collections.Generic;
using UnityEngine;

public class EjerciciosStack : MonoBehaviour
{
    void Start()
    {
        HistorialDeNavegacion();
    }
    void HistorialDeNavegacion()
    {
        Stack<string> historial = new Stack<string>();

        historial.Push("www.google.com");
        historial.Push("www.youtube.com");
        historial.Push("www.unity.com");

        Debug.Log("Páginas visitadas (de más reciente a más antigua):");
        foreach (string pagina in historial)
        {
            Debug.Log(pagina);
        }

        string ultimaPagina = historial.Peek();
        Debug.Log($"Última página visitada: {ultimaPagina}");

        string paginaCerrada = historial.Pop();
        Debug.Log($"Cerraste la página: {paginaCerrada}");

        if (historial.Count > 0)
        {
            Debug.Log($"Ahora estás en: {historial.Peek()}");
        } else
        {
            Debug.Log("No quedan páginas en el historial.");
        }
    }
}
