using UnityEngine;
using System.Collections.Generic;

public class GraphRepresentations : MonoBehaviour

{
    [Header("GameObjects")]
    [SerializeField] GameObject nodo;
    [SerializeField] GameObject arista;

    [Header("Lista")]
    List<string> nodeList = new List<string>();
    List<(string, string)> connectionList = new List<(string, string)>();

    [Header("Diccionario")]
    Dictionary<string, List<string>> adjList = new Dictionary<string, List<string>>();

    int[,] adjMatrix = new int[8, 8];
    void Start()
    {
    //hacer esto que se instancie en la escena de unity 
    
        // Lista Adyacente "One Hit"
        connectionList = new List<(string, string)> { ("A","C"), ("A","D"),("A","B"), ("A","E"),
                                                  ("F","G"),("F","H"),("F","E"),
                                                  ("E","F"), ("E","A"),
                                                  ("B","A"),("B","G"),
                                                  ("G","B"),("G","F"),
                                                  ("H","F"),
                                                  ("D","A"),
                                                  ("C","A")
                                                                                };

        //Definir la Lista Adyacente 
        adjList.Add("A", new List<string> { "C", "D", "B", "E" });
        adjList.Add("B", new List<string> { "A", "G" });
        adjList.Add("C", new List<string> { "A" });
        adjList.Add("D", new List<string> { "A" });
        adjList.Add("E", new List<string> { "F", "A" });
        adjList.Add("F", new List<string> { "G", "H", "E" });
        adjList.Add("G", new List<string> { "B", "F" });
        adjList.Add("H", new List<string> { "F" });
    }

    void Update()
    {

    }
}
