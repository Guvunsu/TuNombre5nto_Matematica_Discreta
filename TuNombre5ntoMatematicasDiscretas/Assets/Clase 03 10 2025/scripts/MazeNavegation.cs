using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class MazeNavegation : MonoBehaviour
{
    public WeightedBoardGraph graph;
    public PrimSolution prim;
    public string startNode, endNode;
    public bool drrawPath;
    Dictionary<string, List<string>> adjacencyList = new Dictionary<string, List<string>>();
    Queue<string> frontier = new Queue<string>();
    Dictionary<string, string> camefrom = new Dictionary<string, string>();
    List<string> path = new List<string>();
    void Update()
    {

    }
    void GenerateMSTinfo()
    {
        foreach (var node in graph.adjacencyList.Keys)
        {
            List<string> neighbours = new List<string>();
            foreach (var connection in prim.tree)
            {
                if (node == connection.Item1 && !neighbours.Contains(connection.Item2)){
                    neighbours.Add(connection.Item2);
                }
                if (node == connection.Item2 && !neighbours.Contains(connection.Item1)){
                    neighbours.Add(connection.Item1);
                }
            }
            adjacencyList.Add(node, neighbours);
        }
    }

}
