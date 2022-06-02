using System.Collections.Generic;
using UnityEngine;

public class PosInArrey
{

    public Vector2Int GetVector2 <T>(T target, T[,] map)
    {
        var mapx = map.GetLength(0);
        var mapy = map.GetLength(1);
        for (int x = 0; x < mapx; x++)
        {
            for (int y = 0; y < mapy; y++)
            {
                if (EqualityComparer<T>.Default.Equals(target, map[x, y]))
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return default;
    }
}