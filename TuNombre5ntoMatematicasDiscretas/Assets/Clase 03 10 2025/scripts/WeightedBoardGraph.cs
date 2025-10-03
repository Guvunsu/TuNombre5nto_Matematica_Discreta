using UnityEngine;
using System.Collections.Generic;

public class WeightedBoardGraph : MonoBehaviour
{
    public Vector2Int size;
    public GameObject nodePrefab, edgePrefab;

    [System.NonSerialized]
    public List<(string, string, int)> connectionList = new List<(string, string, int)>();
    [System.NonSerialized]
    public Dictionary<string, List<(string, int)>> adjacencyList = new Dictionary<string, List<(string, int)>>();
    [System.NonSerialized]
    public List<GameObject> nodes = new List<GameObject>();
    private List<Vector2> nodesPositions = new List<Vector2>();
    public Dictionary<(string, string), GameObject> connectionObjects = new Dictionary<(string, string), GameObject>();

    void Start()
    {
        CreateNodes(true);
        CreateConnections();
        GenerateGraphInfo();
    }

    void CreateNodes(bool hasObstacles)
    {
        int label = 0;
        for (int j = 0; j < size.y; j++)
        {
            for (int i = 0; i < size.x; i++)
            {
                Vector2 newPosition = new Vector2(i, j);
                GameObject newNode = Instantiate(nodePrefab, transform.Find("Nodes"));
                newNode.transform.localPosition = newPosition;
                newNode.transform.GetComponentInChildren<TextMesh>().text = label.ToString();
                nodes.Add(newNode);
                nodesPositions.Add(newPosition);

                int randomNumber = Random.Range(0, 101);
                if (hasObstacles && randomNumber > 100)
                {
                    nodes.Remove(newNode);
                    nodesPositions.Remove(newPosition);
                    Destroy(newNode);
                }
                else
                {
                    newNode.name = "Node-" + label.ToString();
                    label++;
                }
            }
        }
    }

    void CreateConnections()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            for (int j = 0; j < nodes.Count; j++)
            {
                if (AreNeighbours(nodes[i], nodes[j]))// i < j // Que se emplea en Dijkstra
                {
                    int weight = Random.Range(1, 11);
                    connectionList.Add((nodes[i].name, nodes[j].name, weight));
                }
            }
        }

        foreach (var connection in connectionList)
        {
            Vector2 positionA = GameObject.Find(connection.Item1).transform.position;
            Vector2 positionB = GameObject.Find(connection.Item2).transform.position;
            int weight = connection.Item3;

            GameObject edge = Instantiate(edgePrefab, transform.Find("Connections"));
            edge.name = connection.Item1 + "&" + connection.Item2;
            edge.transform.localPosition = (positionA + positionB) / 2f;
            edge.transform.right = (positionA - positionB).normalized;
            connectionObjects.Add((connection.Item1, connection.Item2), edge);

            float lerpFactor = weight / 10f;
            edge.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.black, lerpFactor);
        }
    }


    bool AreNeighbours(GameObject nodeA, GameObject nodeB)
    {
        return ManhattanDistance(nodeA, nodeB) == 1;
    }

    int ManhattanDistance(GameObject nodeA, GameObject nodeB)
    {
        int deltaX = (int)(nodeA.transform.localPosition.x - nodeB.transform.localPosition.x);
        int deltaY = (int)(nodeA.transform.localPosition.y - nodeB.transform.localPosition.y);
        return Mathf.Abs(deltaX) + Mathf.Abs(deltaY);
    }

    void GenerateGraphInfo()
    {
        foreach (GameObject node in nodes)
        {
            string nodeName = node.name;
            adjacencyList.Add(nodeName, NeighbourConnections(nodeName));
        }
    }


    public List<(string, int)> NeighbourConnections(string node)
    {
        List<(string, int)> result = new List<(string, int)>();
        foreach (var connection in connectionList)
        {
            string nodeA = connection.Item1;
            string nodeB = connection.Item2;
            if (node == nodeA || node == nodeB)
            {
                if (nodeA != node)
                {
                    result.Add((nodeA, connection.Item3));
                }
                else if (nodeB != node)
                {
                    result.Add((nodeB, connection.Item3));
                }
            }
        }
        return result;
    }

}