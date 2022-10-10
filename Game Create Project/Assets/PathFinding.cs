using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    AGrid grid;

    public Transform StartObject;
    public Transform TargetObect;

    private void Awake()
    {
        grid = GetComponent<AGrid>();
    }

    private void Update()
    {
        FindPath(StartObject.position, TargetObect.position);
    }

    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        ANode startNode = grid.GetNodeFromWorldPoint(startPos);
        ANode targetNode = grid.GetNodeFromWorldPoint(targetPos);

        List<ANode> openList = new List<ANode>();
        HashSet<ANode> closedList = new HashSet<ANode>();
        openList.Add(startNode);

        while(openList.Count>0)
        {
            ANode currentNode = openList[0];

            for(int i = 1; i <openList.Count; i++)
            {
                if(openList[i].fCost < currentNode.fCost || openList[i].fCost == currentNode.fCost && openList[i].hCost < currentNode.hCost)
                {
                    currentNode = openList[i];
                }
            }
            openList.Remove(currentNode);
            closedList.Add(currentNode);

            if(currentNode == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            foreach(ANode n in grid.GetNeighbors(currentNode))
            {
                if (!n.isWalkable || closedList.Contains(n))
                    continue;

                int newCurrentToNeiborCost = currentNode.gCost + GetDistanceCost(currentNode, n);
                if (newCurrentToNeiborCost < n.gCost || !openList.Contains(n))
                {
                    n.gCost = newCurrentToNeiborCost;
                    n.hCost = GetDistanceCost(n, targetNode);
                    n.parentNode = currentNode;

                    if (!openList.Contains(n))
                        openList.Add(n);
                }
            }
        }
    }

    void RetracePath(ANode startNode, ANode endNode)
    {
        List<ANode> path = new List<ANode>();
        ANode currentNode = endNode;

        while(currentNode!=startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parentNode;
        }
        path.Reverse();
        grid.path = path;
    }

    int GetDistanceCost(ANode nodeA, ANode nodeB)
    {
        int distX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if(distX>distY)
            return 14 * distY + 10 * (distX - distY);
        return 14 * distX + 10 * (distY - distX);
    }
}
