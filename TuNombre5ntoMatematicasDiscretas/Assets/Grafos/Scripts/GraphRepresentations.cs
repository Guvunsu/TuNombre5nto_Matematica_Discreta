using UnityEngine;
using System.Collections.Generic;

public class GraphRepresentations : MonoBehaviour
{
    List<string> nodeList = new List<string>();

    List<(string, string)> connectionList = new List<(string, string)>();

    Dictionary<string, List<string>> adjList = new Dictionary<string, List<string>>();

    int[,] adjMatrix = new int[8, 8];
    void Start()
    {
        connectionList = new List<(string, string)> { ("A","C"), ("A","D"),("A","B"), ("A","C"), ("A","E"),
                                                 ("E","F"), ("A","E"),
                                                  ("B","A"),("B","G"),
                                                  ("G","B"),("G","F"),
                                                  ("F","G"),("F","H"),("F","E"),
                                                  ("H","F"),
                                                  ("D","A"),
                                                  ("C","A")
                                                                                };

    }

    void Update()
    {

    }
}
