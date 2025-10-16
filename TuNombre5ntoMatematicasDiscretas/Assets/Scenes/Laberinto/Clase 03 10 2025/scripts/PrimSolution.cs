using UnityEngine;
using System.Collections.Generic;
using DataStructures.PQ;
using UnityEngine.InputSystem;

public class PrimSolution : MonoBehaviour
{
    public string startNode;

    public WeightedBoardGraph graph;

    public bool startAlgorithm;

    private List<string> pluggedSet = new List<string>();
    private List<string> unpluggedSet = new List<string>();
    public List<(string, string)> tree = new List<(string, string)>();

    private PriorityQueue<int, (string, string)> pending = new PriorityQueue<int, (string, string)>();


    void Update()
    {
        if (startAlgorithm)
        {
            InitAlgorithm();
            Prim();
            HideExpensiveConnections();
            startAlgorithm = false;
        }
    }


    public void InitAlgorithm()
    {
        // Inicializa S1
        pluggedSet.Add(startNode);

        List<GameObject> nodes = graph.nodes;
        // Inicializa S2
        foreach (var node in nodes)
        {
            if (node.name != startNode)
            {
                unpluggedSet.Add(node.name);
            }
        }

        // Adjunta en Pending las conexiones próximas a revisar
        List<(string, int)> nextNeighbours = graph.adjacencyList[startNode];
        foreach (var connection in nextNeighbours)
        {
            string neighbour = connection.Item1;
            int cost = connection.Item2;
            pending.Enqueue(cost, (startNode, neighbour));
        }
    }


    void Prim()
    {
        while (unpluggedSet.Count > 0)
        {
            (string, string) cheaperConnection = pending.Dequeue();
            string unplugged = cheaperConnection.Item2;

            if (!pluggedSet.Contains(unplugged))
            {
                pluggedSet.Add(unplugged);
                tree.Add(cheaperConnection);
            }

            unpluggedSet.Remove(unplugged);
            string plugged = unplugged;

            List<(string, int)> nextNeighbours = graph.adjacencyList[plugged];
            foreach (var connection in nextNeighbours)
            {
                string neighbour = connection.Item1;
                int cost = connection.Item2;
                if (unpluggedSet.Contains(neighbour))
                {
                    (string, string) connectionToCheck = (plugged, neighbour);
                    pending.Enqueue(cost, connectionToCheck);
                }
            }
        }
        Debug.Log("Respira!");
        foreach (var connection in tree)
        {
            Debug.Log(connection);
        }
    }

    void HideExpensiveConnections()
    {
        foreach (var connection in graph.connectionObjects.Keys)
        {
            string nodeA = connection.Item1;
            string nodeB = connection.Item2;
            (string, string) reverseConnection = (nodeB, nodeA);

            if (!tree.Contains(connection))
            {
                graph.connectionObjects[connection].SetActive(false);
            }
            else if (!tree.Contains(connection))
            {
                graph.connectionObjects[reverseConnection].SetActive(false);
            }

        }
    }

}
