using System;
using System.Collections.Generic;
using UnityEngine;

public class BreathFirstSearchGrafo : MonoBehaviour
{
    [Header("Diccionario y Lista")]
    Dictionary<string, List<string>> breathFirstSearchGraph = new Dictionary<string, List<string>>();
    List<String> cameFrom = new List<String>();
    Queue <string> queue = new Queue<string>();
    string startNodes;
    //buscar rutas
    public void ConnectionListDefinition()
    {
        breathFirstSearchGraph["A"] = new List<String> { "A","D", "C", "S" };
        breathFirstSearchGraph["D"] = new List<String> { "F" };
        breathFirstSearchGraph["C"] = new List<String> { "B","E" };
        breathFirstSearchGraph["S"] = new List<String> {  };
        breathFirstSearchGraph["F"] = new List<String> { "G" };
        breathFirstSearchGraph["B"] = new List<String> {  };
        breathFirstSearchGraph["E"] = new List<String> {  };

    }
    public void BFS_Graph()
    {
        queue.Enqueue(startNodes);
        cameFrom.Add(startNodes);
        while (queue.Count>0)
        {
            string currentNode =queue.Dequeue();
        }
    }
    void Start()
    {
        ConnectionListDefinition();
        BFS_Graph();
    }
}
