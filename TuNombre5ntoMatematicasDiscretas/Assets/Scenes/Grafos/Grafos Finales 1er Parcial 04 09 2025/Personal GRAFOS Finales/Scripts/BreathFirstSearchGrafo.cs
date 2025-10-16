using System;
using System.Collections.Generic;
using UnityEngine;

public class BreathFirstSearchGrafo : MonoBehaviour
{
    [Header("Diccionario y Lista")]
    Dictionary<string, List<string>> breathFirstSearchGraph = new Dictionary<string, List<string>>();
    List<string> cameFrom = new List<string>();
    Queue<string> queue = new Queue<string>();
    string startNodes = "A";

    [Header("Prefabs y Referencias")]
    public GameObject nodePrefab;

    Dictionary<string, GameObject> nodeObjects = new Dictionary<string, GameObject>();

    Dictionary<string, Vector3> nodePositions = new Dictionary<string, Vector3>()
    {
        { "A", new Vector3(0, 0, 0) },
        { "D", new Vector3(2, 2, 0) },
        { "C", new Vector3(-2, 2, 0) },
        { "S", new Vector3(0, -2, 0) },
        { "F", new Vector3(4, 4, 0) },
        { "B", new Vector3(-4, 4, 0) },
        { "E", new Vector3(-2, 4, 0) },
        { "G", new Vector3(6, 6, 0) }
    };

    void Start()
    {
        ConnectionListDefinition();
        CreateNodes();
        BFS_Graph();
    }

    public void ConnectionListDefinition()
    {
        breathFirstSearchGraph["A"] = new List<string> { "D", "C", "S" };
        breathFirstSearchGraph["D"] = new List<string> { "F" };
        breathFirstSearchGraph["C"] = new List<string> { "B", "E" };
        breathFirstSearchGraph["S"] = new List<string> { };
        breathFirstSearchGraph["F"] = new List<string> { "G" };
        breathFirstSearchGraph["B"] = new List<string> { };
        breathFirstSearchGraph["E"] = new List<string> { };
        breathFirstSearchGraph["G"] = new List<string> { };
    }

    void CreateNodes()
    {
        foreach (var node in breathFirstSearchGraph.Keys)
        {
            Vector3 pos;
            if (nodePositions.TryGetValue(node, out pos))
            {
                GameObject newNode = Instantiate(nodePrefab, pos, Quaternion.identity);
                newNode.name = "Node " + node;
                nodeObjects[node] = newNode;
            }
            else
            {
                Debug.LogWarning($"No se definió posición para el nodo {node}, se colocará en (0,0,0).");
                nodeObjects[node] = Instantiate(nodePrefab, Vector3.zero, Quaternion.identity);
            }
        }
    }

    public void BFS_Graph()
    {
        queue.Enqueue(startNodes);
        cameFrom.Add(startNodes);

        while (queue.Count > 0)
        {
            string currentNode = queue.Dequeue();
            Debug.Log("Visitando nodo: " + currentNode);

            nodeObjects[currentNode].GetComponent<Renderer>().material.color = Color.green;

            foreach (string neighbor in breathFirstSearchGraph[currentNode])
            {
                Debug.Log("$ Registro " + currentNode);
                if (!cameFrom.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    cameFrom.Add(neighbor);

                    Debug.DrawLine(
                        nodeObjects[currentNode].transform.position,
                        nodeObjects[neighbor].transform.position,
                        Color.yellow,
                        10f
                    );
                }
            }
        }
        string recorrido = string.Join(" -> ", cameFrom);
        Debug.Log("Recorrido completo BFS: " + recorrido);
    }
}
