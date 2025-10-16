using System.Collections.Generic;
using UnityEngine;

public class RandomWeightedGraph : MonoBehaviour
{
    public int numNodes;

    public float size;

    public GameObject simpleNodePrefab;

    public bool reDrawConnections = false;

    public int[,] adjMatrix;

    [System.NonSerialized]
    public List<(string, string, int)> connectionList = new List<(string, string, int)>();
    [System.NonSerialized]
    public Dictionary<string, List<(string, int)>> adjacencyList = new Dictionary<string, List<(string, int)>>();

    void Start()
    {
        CreateGraph();
        DrawConnections();
    }

    void Update()
    {
        if (reDrawConnections)
        {
            reDrawConnections = false;
            DrawConnections();

        }
    }


    void CreateGraph()
    {
        // Create the nodes
        for (int i = 0; i < numNodes; i++)
        {
            Vector3 nodePosition = RandomPosition();
            GameObject newNode = Instantiate(simpleNodePrefab, transform.Find("Nodes"));

            newNode.transform.localPosition = nodePosition;
            newNode.name = "Node-" + i.ToString();
            newNode.transform.GetComponentInChildren<TextMesh>().text = i.ToString();
        }

        // Create Adjacency Matrix
        adjMatrix = new int[numNodes, numNodes];
        for (int i = 0; i < numNodes; i++)
        {
            for (int j = 0; j < numNodes; j++)
            {
                adjMatrix[i, j] = 1;
            }
        }
        
        for (int i = 0; i < numNodes; i++)
        {
            // Set zeros to diagonal
            adjMatrix[i, i] = 0;
            
            // Delete some connections
            for (int j = 0; j < numNodes; j++)
            {
                bool deleting = Random.Range(1, 101) < 10;
                if (i < j && deleting)
                {
                    adjMatrix[i, j] = 0;
                    adjMatrix[j, i] = 0;
                }
            }
        }
       
        // Create Graph Info

        for (int i = 0; i < numNodes; i++)
        {
            string nodeA = "Node-" + i.ToString();
            List<(string, int)> neighboursOfNodeA = new List<(string, int)>();

            for (int j = 0; j < numNodes; j++)
            {
                string nodeB = "Node-" + j.ToString();
                if (i < j && adjMatrix[i, j] == 1)
                {
                    int randomWeight = Random.Range(1, 11);
                    connectionList.Add((nodeA, nodeB, randomWeight));
                    neighboursOfNodeA.Add((nodeB, randomWeight));
                }
            }
            adjacencyList.Add(nodeA, neighboursOfNodeA);
        }
    }

    void DrawConnections()
    {
        if (transform.Find("Connections").childCount > 0)
        {
            foreach (Transform child in transform.Find("Connections"))
            {
                Destroy(child.gameObject);
            }
        }
        else
        {
            foreach (var pair in connectionList)
            {
                GameObject connection = new GameObject(pair.Item1 + pair.Item2);
                connection.transform.parent = transform.Find("Connections");

                connection.AddComponent<LineRenderer>();
                connection.GetComponent<LineRenderer>().positionCount = 2;

                Vector3 positionA = GameObject.Find(pair.Item1).transform.position;
                Vector3 positionB = GameObject.Find(pair.Item2).transform.position;
                connection.GetComponent<LineRenderer>().SetPosition(0, positionA);
                connection.GetComponent<LineRenderer>().SetPosition(1, positionB);
                connection.GetComponent<LineRenderer>().widthMultiplier = 0.1f;
                connection.GetComponent<LineRenderer>().sortingOrder = -1;
                connection.GetComponent<LineRenderer>().material =  new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended Premultiply"));
            }
        }
    }

    Vector3 RandomPosition()
    {
        float x = Random.Range(-0.5f * size, 0.5f * size);
        float y = Random.Range(-0.5f * size, 0.5f * size);
        return new Vector3(x, y, 0);
    }

}
