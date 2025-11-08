using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EjerciciosQueue : MonoBehaviour
{
    void Start()
    {
        FilaDeAtencionCliente();
        //TurnosVentanilla();
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

    void TurnosVentanilla()
    {
        Queue<string> turnos = new Queue<string>();
        turnos.Enqueue("Cliente1");
        turnos.Enqueue("Cliente2");
        turnos.Enqueue("Cliente3");
        if (!turnos.Contains("Cliente4"))
        {
            turnos.Enqueue("Cliente4");
        }
        Queue<string> nuevosTurnosPrioridad = new Queue<string>();
        if (turnos.Contains("Cliente2")) {
            turnos.Enqueue("Cliente2");
        }
        foreach (string clientes in turnos)
        {
            if (clientes != "Cliente2")
            {
                nuevosTurnosPrioridad.Enqueue(clientes);
            }
        }
        nuevosTurnosPrioridad = turnos;
        Debug.Log($"este es el nuevo orden de turnos:{turnos}");

        if (turnos.Count == 2)
        {
            string atendido1 = turnos.Dequeue();
            string atendido2 = turnos.Dequeue();
            Debug.Log($"Atendidos: {atendido1} y {atendido2}");
        }

        //quien sigue depues
        if (turnos.Count > 0)
        {
            Debug.Log("Siguiente cliente: " + turnos.Peek());
        } else
        {
            Debug.Log("No hay más clientes en la cola.");
        }
        int totalAtendidos = 4;
        turnos.Clear();
        Debug.Log($"Jornada terminada. Total de clientes atendidos: {totalAtendidos}");

    }
}
