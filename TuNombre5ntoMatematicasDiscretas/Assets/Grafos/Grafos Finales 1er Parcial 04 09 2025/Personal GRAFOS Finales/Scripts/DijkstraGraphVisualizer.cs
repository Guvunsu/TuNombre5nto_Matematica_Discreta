using System.Collections.Generic;
using UnityEngine;

public class DijkstraGraphVisualizer : MonoBehaviour
{
    [Header("Diccionario, Lista y Cola/Prioridad")]
    Dictionary<string, List<string>> breathFirstSearchGraph = new Dictionary<string, List<string>>();
    Dictionary<(string fromNode, string toNode), float> edgeCost = new Dictionary<(string, string), float>();
    Dictionary<string, string> cameFrom = new Dictionary<string, string>();
    Dictionary<string, float> costSoFar = new Dictionary<string, float>();

    string startNodes = "A";
    string goalNode = "G";

    [Header("Prefab para nodos")]
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
        DefineEdgeCosts();
        CreateNodes();
        RunDijkstra();
        DrawPath();
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

    public void DefineEdgeCosts()
    {
        edgeCost[("A", "D")] = 1f;
        edgeCost[("A", "C")] = 4f;
        edgeCost[("A", "S")] = 2f;

        edgeCost[("D", "F")] = 5f;

        edgeCost[("C", "B")] = 1f;
        edgeCost[("C", "E")] = 3f;

        edgeCost[("F", "G")] = 1f;
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
                newNode.GetComponent<Renderer>().material.color = Color.white;
                nodeObjects[node] = newNode;
            }
            else
            {
                Debug.LogWarning($"No se definió posición para el nodo {node}, se colocará en (0,0,0).");
                GameObject newNode = Instantiate(nodePrefab, Vector3.zero, Quaternion.identity);
                newNode.name = "Node " + node;
                newNode.GetComponent<Renderer>().material.color = Color.white;
                nodeObjects[node] = newNode;
            }
        }
    }

    void RunDijkstra()
    {
        // Frontier: nodos pendientes con su prioridad (costo conocido)
        var frontier = new List<(string node, float priority)>();

        frontier.Add((startNodes, 0f));
        costSoFar[startNodes] = 0f;
        cameFrom[startNodes] = null;

        while (frontier.Count > 0)
        {
            // Obtener el nodo en frontier con menor prioridad
            frontier.Sort((a, b) => a.priority.CompareTo(b.priority));
            var pair = frontier[0];
            frontier.RemoveAt(0);

            string current = pair.node;
            float currentCost = pair.priority;
            nodeObjects[current].GetComponent<Renderer>().material.color = Color.green;

            if (current == goalNode)
            {
                Debug.Log("Llegó al nodo objetivo: " + goalNode);
                break;
            }

            if (!breathFirstSearchGraph.ContainsKey(current))
            {
                continue;
            }

            foreach (string neighbor in breathFirstSearchGraph[current])
            {
                // Ignorar si no hay costo definido entre current a neighbor
                if (!edgeCost.ContainsKey((current, neighbor)))
                {
                    Debug.LogWarning($"No se definió costo de la arista {current} y {neighbor}, se considera infinito.");
                    continue;
                }

                float newCost = costSoFar[current] + edgeCost[(current, neighbor)];

                if (!costSoFar.ContainsKey(neighbor) || newCost < costSoFar[neighbor])
                {
                    costSoFar[neighbor] = newCost;
                    cameFrom[neighbor] = current;
                    frontier.Add((neighbor, newCost));

                    Debug.DrawLine(
                        nodeObjects[current].transform.position,
                        nodeObjects[neighbor].transform.position,
                        Color.yellow,
                        10f
                    );
                }
            }
        }
        string recorrido = string.Join(" -> ", cameFrom);
        Debug.Log("Ruta completa Djistra: " + recorrido);
    }

    void DrawPath()
    {
        if (!cameFrom.ContainsKey(goalNode))
        {
            Debug.Log("No hay camino al objetivo");
            return;
        }

        // Reconstruir camino desde goalNode hasta startNodes
        var path = new List<string>();
        string curr = goalNode;
        while (curr != null)
        {
            path.Add(curr);
            curr = cameFrom[curr];
        }
        path.Reverse(); // para que vaya desde start hasta goal

        // Pinta los nodos del camino
        foreach (string node in path)
        {
            nodeObjects[node].GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
