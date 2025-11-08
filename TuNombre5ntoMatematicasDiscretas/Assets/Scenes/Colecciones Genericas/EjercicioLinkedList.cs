using System.Collections.Generic;
using UnityEngine;

public class EjercicioLinkedList : MonoBehaviour
{
    void Start()
    {
        EncenderPC();
        //PlayListMusic();
        //NumerosPares();
        //ReorganizarListaDeEspera();
        //IntercalarPositivosYNegativos();
        //InversionParcialDeLista();
    }
    void EncenderPC()
    {
        LinkedList<string> encenderPC = new LinkedList<string>();
        encenderPC.AddLast("Revisar el correo");
        encenderPC.AddLast("Responder mensajes");
        encenderPC.AddLast("Asisitir a reunion");

        encenderPC.AddFirst("Encender computadora");

        LinkedListNode<string> node = encenderPC.Find("Revisar el correo");
        encenderPC.AddAfter(node, "Responder correo");
        encenderPC.Remove("Asistir a reunion");
        foreach (var tareas in encenderPC)
        {
            Debug.Log(tareas);
        }
    }
    void PlayListMusic()
    {
        LinkedList<string> playList = new LinkedList<string>(
            new string[] { "Intro", "Camino", "Luz", "Final" });

        LinkedListNode<string> node = playList.Find("Final");
        playList.AddBefore(node, "Interludio");
        playList.AddFirst("Despertar");

        LinkedListNode<string> nodess = playList.Find("Despertar");
        Debug.Log(nodess);

        LinkedListNode<string> nodesss = playList.FindLast("Final");
        Debug.Log(nodesss);

        LinkedListNode<string> nnodes = playList.Find("Intro");
        playList.Remove("Intro");
        Debug.Log(playList);
    }

    void NumerosPares()
    {
        //https://classroom.google.com/c/NzkxMTIzNjYyMjU1/a/ODE2NzEwOTgxNzc4/details
        //https://drive.google.com/file/d/10tXO_gfHlIBeIcaKs4zhjF6srpRpN8KO/view
        //https://classroom.google.com/c/NzkxMTIzNjYyMjU1/m/ODE2NzAxMDU0NDc5/details
        //https://classroom.google.com/c/NzkxMTIzNjYyMjU1/m/ODIxODEyNjk0OTIw/details
    }
    void ReorganizarListaDeEspera()
    {
        LinkedList<string> pacientes = new LinkedList<string>(new[] { "Ana", "Luis", "Carlos", "María" });
        Debug.Log("Lista inicial: " + string.Join(", ", pacientes));

        if (pacientes.Contains("Carlos"))
        {
            pacientes.Remove("Carlos");
            pacientes.AddFirst("Carlos");
        }

        LinkedListNode<string> nodoAna = pacientes.Find("Ana");
        if (nodoAna != null)
        {
            pacientes.AddAfter(nodoAna, "Pedro");
        }

        pacientes.Remove("Luis");

        Debug.Log("Lista reorganizada: " + string.Join(", ", pacientes));
    }
    void IntercalarPositivosYNegativos()
    {
        LinkedList<int> numeros = new LinkedList<int>(new[] { 3, 7, 2 });
        Debug.Log("Lista original: " + string.Join(", ", numeros));

        LinkedList<int> resultado = new LinkedList<int>();

        foreach (int n in numeros)
        {
            resultado.AddLast(n);
            resultado.AddLast(-n);
        }

        Debug.Log("Lista intercalada (+ y -): " + string.Join(", ", resultado));
    }
    void InversionParcialDeLista()
    {
        LinkedList<int> lista = new LinkedList<int>(new[] { 10, 20, 30, 40, 50, 60, 70 });
        Debug.Log("Lista original: " + string.Join(", ", lista));

        List<int> subLista = new List<int>();
        bool dentroDelRango = false;

        foreach (int n in lista)
        {
            if (n == 20) dentroDelRango = true;
            if (dentroDelRango) subLista.Add(n);
            if (n == 50) break;
        }

        subLista.Reverse();

        LinkedList<int> resultado = new LinkedList<int>();

        foreach (int n in lista)
        {
            if (n < 20 || n > 50)
            {
                resultado.AddLast(n);
            } else if (n == 20)
            {
                foreach (int val in subLista)
                    resultado.AddLast(val);
            }
        }

        Debug.Log("Lista con inversión parcial: " + string.Join(", ", resultado));
    }
}
