using System.Collections.Generic;
using UnityEngine;

public class EjercicioLinkedList : MonoBehaviour
{
    void Start()
    {

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
}
