using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

public class AStar : MonoBehaviour
{
    public static MinPriorityQueue openList;
    public static HashSet<Node> closedLsit;

    private static float HeuristicEstimatedCost(Node currentNode, Node goalNode)
    {
        Vector3 vecCost = currentNode.position - goalNode.position;
        return vecCost.magnitude;
    }
    public static ArrayList FindPath(Node start, Node goal)
    {
        openList = new MinPriorityQueue();
        openList.Push(start);
        start.nodeTotalCost = 0f;
        start.estimatedCost = HeuristicEstimatedCost(start, goal);
        closedLsit = new HashSet<Node>();
        Node node = null;

        while (openList.Length != 0)
        {
            node = openList.First();
            if (node.position == goal.position){
                return CalculatePath(node);
            }
            ArrayList neighbours = new ArrayList();
            GridManager.instance.GetNeighbours(node, neighbours);

            for (int i = 0; i < neighbours.Count; i++)
            {
                Node neighbourNode = (Node)neighbours[i];
                if (!closedLsit.Contains(neighbourNode))
                {
                    float cost = HeuristicEstimatedCost(node, neighbourNode);
                    float totalCost = node.nodeTotalCost + cost;
                    float neighbourNodeEstCost = HeuristicEstimatedCost(neighbourNode, goal);

                    neighbourNode.nodeTotalCost = totalCost;
                    neighbourNode.parent = node;
                    neighbourNode.estimatedCost = totalCost + neighbourNodeEstCost;
                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Push(neighbourNode);
                    }
                }
            }
            closedLsit.Add(node);
            openList.Remove(node);
        }
        if (node.position != goal.position)
        {
            Debug.LogError("Goal not found");
            return null;
        }
        return CalculatePath(node);
    }
    private static ArrayList CalculatePath(Node node)
    {
        ArrayList list = new ArrayList();
        while (node != null)
        {
            list.Add(node);
            node = node.parent;
        }
        list.Reverse();
        return list;
    }
}
