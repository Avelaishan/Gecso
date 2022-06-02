using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateMap<T>
{

	public T[,] CreateBasicMap(Vector2 startNode, Vector2 targetNode, T[,] hexMap/*, int chanceToDestroyHex*/)
	{
		T[,] Map = hexMap;
		List<T> openSet = new List<T>();
		HashSet<T> closedSet = new HashSet<T>();
		List<T> reverseOpenSet = new List<T>();
		HashSet<T> reverseClosedSet = new HashSet<T>();

        //openSet.Add(hexMap[(int)startNode.x,(int)startNode.y]);
		//reverseOpenSet.Add(hexMap[(int)targetNode.x, (int)targetNode.y]);

		/*while (openSet.Count > 0)
		{
			var Neighbors = new Neigbohure<T>();
			var node = openSet.Last();
			openSet.Remove(node);
			closedSet.Add(node);
			foreach (var neighbour in Neighbors.Neighbors(node, hexMap))
			{
				if (EqualityComparer<T>.Default.Equals(neighbour, hexMap[(int)targetNode.x, (int)targetNode.y]))
				{
					continue;
				}
				if (closedSet.Contains(neighbour))
				{
					continue;
				}
				/*if (chanceToDestroyHex > Random.Range(0, 100))
				{
					node = default;
				}
				openSet.Add(neighbour);
			}
		}
		while (reverseOpenSet.Count > 0)
		{
			var neighbors = new Neigbohure<T>();
			var node = openSet.Last();
			reverseOpenSet.Remove(node);
			reverseClosedSet.Add(node);
			foreach (var neighbour in neighbors.Neighbors(node, hexMap))
			{
				/*if(neighbour == toDestroy)
                {
					continue;
				}
				if (EqualityComparer<T>.Default.Equals(neighbour, hexMap[(int)targetNode.x, (int)targetNode.y]))
				{
					continue;
				}
				if (closedSet.Contains(neighbour))
				{
					continue;
				}
				openSet.Add(neighbour);
			}
		}*/
        return Map;
	}




	/*public void ChekPath(HexBase startNode, HexBase targetNode, HexMap hexMap)
	{
        var hexMap1 = new HexMap();
		List<HexBase> openSet = new List<HexBase>();
		HashSet<HexBase> closedSet = new HashSet<HexBase>();
		openSet.Add(startNode);

		while (openSet.Count > 0)
		{
			var node = openSet.Last();
			openSet.Remove(node);
			closedSet.Add(node);
			foreach (var neighbour in hexMap1.Neighbors(node))
			{
				if(neighbour == toDestroy)
                {
					continue;
				}
				if (neighbour == targetNode)
				{
					continue;
				}
                if (closedSet.Contains(neighbour))
                {
					continue;
				}
				openSet.Add(neighbour);
			}
		}
	}*/
}



