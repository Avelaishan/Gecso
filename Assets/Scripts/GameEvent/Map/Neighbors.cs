using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neigbohure <T>
{
    /*public List<HexBase> Neighbors(HexBase hexEnemy, HexBase[,] hexBases)
    {
        var getPos = new PosInArrey(); 
        var position = getPos.GetVector2(hexEnemy, hexBases);
        var posy = position.y;
        var neighbors = new List<HexBase>();
        if (posy % 2 == 0)
        {
            foreach (var item in matriForEvenHex)
            {
                if (item != null)
                {
                    var neighborPos = position + item;
                    if (neighborPos.x < 0 || neighborPos.x >= hexBases.GetLength(0) ||
                        neighborPos.y < 0 || neighborPos.y >= hexBases.GetLength(1))
                    {
                        continue;
                    }
                    var NeighborsHex = hexBases[neighborPos.x, neighborPos.y];
                    neighbors.Add(NeighborsHex);
                }
            }
        }
        else
        {
            foreach (var item in matriForOddHex)
            {
                if (item != null)
                {
                    var neighborPos = position + item;
                    if (neighborPos.x < 0 || neighborPos.x >= hexBases.GetLength(0) ||
                        neighborPos.y < 0 || neighborPos.y >= hexBases.GetLength(1))
                    {
                        continue;
                    }
                    var NeighborsHex = hexBases[neighborPos.x, neighborPos.y];
                    neighbors.Add(NeighborsHex);
                }
            }
        }
        return neighbors;
    }*/
    
    public List<T> Neighbors(T Target, T[,] MapArrey)
    {
        PosInArrey getPos = new PosInArrey();
        var position = getPos.GetVector2<T>(Target, MapArrey);
        var posy = position.y;
        var neighbors = new List<T>();
        var mapArreyX = MapArrey.GetLength(0);
        var mapArreyY = MapArrey.GetLength(1);

        if (posy % 2 == 0)
        {
            foreach (var item in matriForEvenHex)
            {
                if (item != null)
                {
                    var neighborPos = position + item;
                    if (neighborPos.x < 0 || neighborPos.x >= mapArreyX ||
                        neighborPos.y < 0 || neighborPos.y >= mapArreyY)
                    {
                        continue;
                    }
                    var NeighborsHex = MapArrey[neighborPos.x, neighborPos.y];
                    neighbors.Add(NeighborsHex);
                }
            }
        }
        else
        {
            foreach (var item in matriForOddHex)
            {
                if (item != null)
                {
                    var neighborPos = position + item;
                    if (neighborPos.x < 0 || neighborPos.x >= mapArreyX ||
                        neighborPos.y < 0 || neighborPos.y >= mapArreyY)
                    {
                        continue;
                    }
                    var NeighborsHex = MapArrey[neighborPos.x, neighborPos.y];
                    neighbors.Add(NeighborsHex);
                }
            }
        }
        return neighbors;
    }

    private Vector2Int[] matriForEvenHex = new Vector2Int[]
    {
        new Vector2Int(1, 0),
        new Vector2Int(0, -1),
        new Vector2Int(-1, -1),
        new Vector2Int(-1, 0),
        new Vector2Int(-1, 1),
        new Vector2Int(0, 1)
    };

    private Vector2Int[] matriForOddHex = new Vector2Int[]
    {
        new Vector2Int(1,  0),
        new Vector2Int(1, -1),
        new Vector2Int(0, -1),
        new Vector2Int(-1, 0),
        new Vector2Int(0, 1),
        new Vector2Int(1,1)
    };
}
