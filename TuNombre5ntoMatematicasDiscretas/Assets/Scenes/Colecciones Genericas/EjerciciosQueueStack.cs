using System.Collections.Generic;
using UnityEngine;

public class EjerciciosQueueStack : MonoBehaviour
{
    void Start()
    {
        FilaDeAtencionCliente();
        HistorialDeNavegacion();
    }
    void FilaDeAtencionCliente()
    {
        Queue<string> filaClientes = new Queue<string>();

        filaClientes.Enqueue("Carlos");
        filaClientes.Enqueue("María");
        filaClientes.Enqueue("Luis");
        filaClientes.Enqueue("Ana");
        filaClientes.Enqueue("Pedro");

        Debug.Log("Fila inicial de clientes:");
        foreach (string cliente in filaClientes)
        {
            Debug.Log(cliente);
        }

        string clienteAtendido = filaClientes.Dequeue();
        Debug.Log($"Cliente atendido: {clienteAtendido}");

        if (filaClientes.Count > 0)
        {
            string siguienteCliente = filaClientes.Peek();
            Debug.Log($"El siguiente cliente en la fila será: {siguienteCliente}");
        } else
        {
            Debug.Log("No quedan más clientes en la fila.");
        }
        Debug.Log("Fila actual después de atender:");
        foreach (string cliente in filaClientes)
        {
            Debug.Log(cliente);
        }
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
