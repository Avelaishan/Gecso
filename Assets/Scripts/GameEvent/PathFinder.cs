using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
	[SerializeField]
    private HexMap hexMap;

	public bool ChekPath(HexBase startNode, HexBase targetNode, HexBase toDestroy)
	{
		List<HexBase> openSet = new List<HexBase>();
		HashSet<HexBase> closedSet = new HashSet<HexBase>();
		openSet.Add(startNode);

		while (openSet.Count > 0)
		{
			var node = openSet.Last();
			openSet.Remove(node);
			closedSet.Add(node);
			foreach (var neighbour in hexMap.Neighbors(node))
			{
				if(neighbour == toDestroy)
                {
					continue;
				}
				if (neighbour == targetNode)
				{
					return true;
				}
                if (closedSet.Contains(neighbour))
                {
					continue;
				}
				openSet.Add(neighbour);
			}
		}
		return false;
	}

	int GetDistance(HexBase nodeA, HexBase nodeB)
	{
		int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		if (dstX > dstY)
			return 14 * dstY + 10 * (dstX - dstY);
		return 14 * dstX + 10 * (dstY - dstX);
	}




	/*public bool FindPath(HexBaseObj startNode, HexBaseObj targetNode)
	{
		List<HexBaseObj> openSet = new List<HexBaseObj>();
		HashSet<HexBaseObj> closedSet = new HashSet<HexBaseObj>();
		openSet.Add(startNode);

		while (openSet.Count > 0)
		{
			HexBaseObj node = openSet[0];
			for (int i = 1; i < openSet.Count; i++)
			{
				if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost)
				{
					if (openSet[i].hCost < node.hCost)
						node = openSet[i];
				}
			}

			openSet.Remove(node);
			closedSet.Add(node);

			if (node == targetNode)
			{
				//RetracePath(startNode, targetNode);
				return true;
			}

			foreach (HexBaseObj neighbour in hexMap.Neighbors(node))
			{
				if (closedSet.Contains(neighbour))
				{
					continue;
				}

				int newCostToNeighbour = node.gCost + GetDistance(node, neighbour);
				if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
				{
					neighbour.gCost = newCostToNeighbour;
					neighbour.hCost = GetDistance(neighbour, targetNode);
					neighbour.parent = node;

					if (!openSet.Contains(neighbour))
						openSet.Add(neighbour);
				}
			}
		}
		return false;
	}

		int GetDistance(HexBaseObj nodeA, HexBaseObj nodeB)
	{
		int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		if (dstX > dstY)
			return 14 * dstY + 10 * (dstX - dstY);
		return 14 * dstX + 10 * (dstY - dstX);
	}


	/*void RetracePath(HexBaseObj startNode, HexBaseObj targetNode)
	{
		List<HexBaseObj> path = new List<HexBaseObj>();
		HexBaseObj currentNode = targetNode;

		while (currentNode != startNode)
		{
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}
		path.Reverse();
	}*/


}



