using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class MazGenerator : MonoBehaviour
{
    public WeightedBoardGraph graph;
    public PrimSolution prim;
    public GameObject wallPrefab;
    public bool createMaze;

    void Update()
    {
        if (createMaze)
        {
            CreateMazeBorders();
            CreateMazeWalls();
            createMaze = false;
        }
    }
    void CreateMazeBorders()
    {
        for (int i = 0; i < graph.size.x; i++)
        {
            Vector2 posBotton = new Vector2(i, -0.5f);
            Vector2 posTop = new Vector2(i, graph.size.y - 0.5f);
            Quaternion rot = Quaternion.identity;
            GameObject botton = Instantiate(wallPrefab, posBotton, rot, transform);
            GameObject top = Instantiate(wallPrefab, posTop, rot, transform);
            botton.transform.localScale = new Vector3(1, 0.1f, 1);
            top.transform.localScale = new Vector3(1, 0.1f, 1);
        }
        for (int j = 0; j < graph.size.y; j++)
        {
            Vector2 posLeft = new Vector2(-0.5f, j);
            Vector2 posRight = new Vector2(graph.size.x - 0.5f, j);
            Quaternion rot = Quaternion.identity;
            GameObject left = Instantiate(wallPrefab, posLeft, rot, transform);
            GameObject right = Instantiate(wallPrefab, posRight, rot, transform);
            left.transform.localScale = new Vector3(0.1f, 1, 1);
            right.transform.localScale = new Vector3(0.1f, 1, 1);
        }
    }
    void CreateMazeWalls()
    {
        List<(string, string)> singleConnections = new List<(string, string)>();
        foreach (var connection in graph.connectionList)
        {
            string nodeA = connection.Item1;
            string nodeB = connection.Item2;
            if (!singleConnections.Contains((nodeA, nodeB)) && !singleConnections.Contains((nodeB, nodeA)))
                
            {

                singleConnections.Add((nodeA, nodeB));
            }
        }
    
        foreach (var connection in singleConnections)
        {
            {
                string nodeA = connection.Item1;
                string nodeB = connection.Item2;
                (string, string) revConnection = (nodeB, nodeA);
                if (!prim.tree.Contains(connection) && !prim.tree.Contains(revConnection))
                {
                    Vector2 nodeAPoss = GameObject.Find(nodeA).transform.position;
                    Vector2 nodeBPoss = GameObject.Find(nodeB).transform.position;

                    Vector2 wallPos = 0.5f * (nodeAPoss + nodeBPoss);
                    Quaternion rot = Quaternion.identity;
                    GameObject wall = Instantiate(wallPrefab, wallPos, rot, transform);

                    float ScaleX = Mathf.Abs(nodeAPoss.x - nodeBPoss.x);
                    float ScaleY = Mathf.Abs(nodeAPoss.y - nodeBPoss.y);
                    Vector3 scaleVector = new Vector3(ScaleX, ScaleY);
                    wall.transform.localScale = Vector3.one - 0.9f * scaleVector;
                }
            }
        }
    }
}
