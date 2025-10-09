using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class MazeNavigation : MonoBehaviour
{
    public WeightedBoardGraph graph;
    public PrimSolution prim;

    public string startNode, endNode;
    public bool drawPath;

    Dictionary<string, List<string>> adjacencyList = new Dictionary<string, List<string>>();
    Queue<string> frontier = new Queue<string>();
    Dictionary<string, string> cameFrom = new Dictionary<string, string>();
    List<string> path = new List<string>();

    void Update()
    {
        Debug.Log("paso por el update");
        if (drawPath)
        {
            GenerateMSTInfo();
            InitBFS();
            BFS();
            RecontructPath();
            drawPath = false;
            Debug.Log(cameFrom.Count);
        }
    }
    void GenerateMSTInfo()
    {
        foreach (var node in graph.adjacencyList.Keys)
        {
            List<string> neighbours = new List<string>();
            foreach (var connection in prim.tree)
            {

                if (node == connection.Item1 && !neighbours.Contains(connection.Item2))
                {
                    neighbours.Add(connection.Item2);
                }
                if (node == connection.Item2 && !neighbours.Contains(connection.Item1))
                {
                    neighbours.Add(connection.Item1);
                }
            }
            adjacencyList.Add(node, neighbours);
        }
    }
    void InitBFS()
    {
        frontier.Enqueue(startNode);
        cameFrom.Add(startNode, startNode);
    }
    void BFS()
    {
        while (frontier.Count > 0)
        {
            string current = frontier.Dequeue();
            List<string> neighbours = adjacencyList[current];
            foreach (var neigh in neighbours)
            {
                if (!cameFrom.ContainsKey(neigh))
                {
                    frontier.Enqueue(neigh);
                    cameFrom.Add(neigh, current);
                }
            }
        }
    }
    void RecontructPath()
    {
        string current = endNode;
        string startPosition = startNode;
        path.Clear();

        while (current != startPosition)
        {
            path.Add(current);
            current = cameFrom[current];
        }
        path.Add(startNode);
        path.Reverse();
        GetComponent<LineRenderer>().positionCount = path.Count;
        int i = 0;
        foreach (string node in path)
        {
            Vector3 nodePosition = GameObject.Find(node).transform.position;
            GetComponent<LineRenderer>().SetPosition(i, nodePosition);
            i++;
        }
    }
}