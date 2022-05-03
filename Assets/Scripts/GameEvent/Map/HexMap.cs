
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour
{
    #region Serialized var
    [SerializeField] 
    Spawner spawner;
    [SerializeField]
    HexDataBase hexData;
    [SerializeField]
    int chanceToSpawnEnemy;
    [SerializeField]
    int chanceToDectoyHex;
    [SerializeField]
    GameObject tileMap;
    #endregion
    int entranceCounter;
    HexBaseObj[,] HexScriptObj;
    public HexBase[,] HexEnemies;

    private void Start()
    {
        HexEnemies = new HexBase[MapGenData.Row, MapGenData.Column];
        HexScriptObj = new HexBaseObj[MapGenData.Row, MapGenData.Column];
        CreateScriptableHexArrey();
        //DestroyHex(HexScriptObj);
        CreateHexTileMap();
        SetStartTileMap();
    }

    public void DiscoverNearHex(HexBase targetHex)
    {
        foreach (var item in Neighbors(targetHex))
        {
            if (item != null)
            {
                item.Discovored = true;
            }
        }
    }

    public void BlockNearHex(HexEnemy hexEnemy)
    {
        foreach (var item in Neighbors(hexEnemy))
        {
            if (item != null)
            {
                item.Blocked = true;
            }
        }
    }

    public void UnBlockNearHex(HexEnemy hexEnemy)
    {
        foreach (var item in Neighbors(hexEnemy))
        {
            item.Blocked = false;
        }
    }

    public void OpenTargetHex(HexBase targetHex)
    {
        targetHex.Open = true;
    }

    public void SetStartTileMap()
    {
        if(MapGenData.Row <= 1)
        {
            MapGenData.Row = 2;
        }
        if (MapGenData.Column <= 1)
        {
            MapGenData.Column = 2;
        }
        int x = (int)MapGenData.Row - 1;
        int y = (int)MapGenData.Column - 1;
        float lastHexPosX = HexEnemies[x, y].transform.position.x;
        float lastHexPosY = HexEnemies[x, y].transform.position.y;
        tileMap.transform.position = new Vector2(-lastHexPosX / 2, -lastHexPosY / 2);
    }

    private HexBaseObj[,] CreateScriptableHexArrey()
    {
        for (int x = 0; x <= MapGenData.Row - 1; x++)
        {
            for (int y = 0; y <= MapGenData.Column - 1; y++)
            {
                var hexObj = SetScriptObjInArrey();
                HexScriptObj[x, y]  = hexObj;
            }
        }
        return HexScriptObj;
    }

    private void CreateHexTileMap()
    {
        for (int x = 0; x <= MapGenData.Row - 1; x++)
        {
            for (int y = 0; y <= MapGenData.Column - 1; y++)
            {
                if(HexScriptObj[x, y] != null)
                {
                    var scriptObj = HexScriptObj[x, y];
                    var hexObj = spawner.HexSpawn(scriptObj, SetPositionVector(x, y));
                    hexObj.name = $"Hex {x} / {y} ";
                    HexEnemies[x, y] = hexObj;
                }
            }
        }
    }

    private HexBaseObj SetScriptObjInArrey()
    {
        var lastEntrance = (int)MapGenData.Row * (int)MapGenData.Column - 1;
        if (entranceCounter == 0)
        {
            entranceCounter++;
            HexStartObj hexStat = hexData.GetStartHexStat();
            return hexStat;
        }
        else if (entranceCounter == lastEntrance)
        {
            entranceCounter++;
            HexKeyPointObj hexStat = hexData.GetKeyHexStat();
            return hexStat;
        }
        else
        {
            entranceCounter++;
            var randomChance = UnityEngine.Random.Range(1, 100);
            if (chanceToSpawnEnemy >= randomChance)
            {
                HexEnemyObj hexStat = hexData.GetEnemyHexStat();
                return hexStat;
            }
            else
            {
                HexBaseObj hexStat = hexData.GetHexStat();
                return hexStat;
            }
        }
    }

    private Vector2Int GetVector2(HexBase hexEnemy)
    {
        for (int i = 0; i < HexEnemies.GetLength(0); i++)
        {
            for (int j = 0; j < HexEnemies.GetLength(1); j++)
            {
                if (hexEnemy == HexEnemies[i, j])
                {
                    if(hexEnemy != null)
                    {
                        return new Vector2Int(i, j);
                    }
                }
            }
        }
    return default;
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


    //hexSize must be founded in GetHexWidht, that currently didnt work ¯\_(-_-)_/¯
    private Vector2 SetPositionVector(int row, int column, float hexWight = 70)
    {
        Vector2 pos;
        var hexSize = hexWight / Math.Sqrt(3);
        if (column % 2 == 0)
        {
            pos = new Vector2(row * hexWight, (float)(column * hexSize * 3 / 2));
        }
        else
        {
            pos = new Vector2(row * hexWight + hexWight / 2, (float)(column * hexSize * 3 / 2));
        }
        return pos;
    }

    private List<HexBase> Neighbors(HexBase hexEnemy)
    {
        var position = GetVector2(hexEnemy);
        var posy = position.y;
        var neighbors = new List<HexBase>();
        if(posy % 2 == 0)
        {
            foreach (var item in matriForEvenHex)
            {
                if (item != null)
                {
                    var neighborPos = position + item;
                    if (neighborPos.x < 0 || neighborPos.x >= HexEnemies.GetLength(0) ||
                        neighborPos.y < 0 || neighborPos.y >= HexEnemies.GetLength(1))
                    {
                        continue;
                    }
                    var NeighborsHex = HexEnemies[neighborPos.x, neighborPos.y];
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
                    if (neighborPos.x < 0 || neighborPos.x >= HexEnemies.GetLength(0) ||
                        neighborPos.y < 0 || neighborPos.y >= HexEnemies.GetLength(1))
                    {
                        continue;
                    }
                    var NeighborsHex = HexEnemies[neighborPos.x, neighborPos.y];
                    neighbors.Add(NeighborsHex);
                }
            }
        }
        return neighbors;
    }

    /*didnt work for some reason to lazy for fixing
    Vector2 GetHexWidht(HexBase hexEnemy)
    {
    var hexSize = hexEnemy.GetComponent<Renderer>().bounds.size;
    return hexSize;
    }*/

    //No idea how to implement logic thant will delite some hex but will leave path to win game
    /*HexBaseObj[,] DestroyHex(HexBaseObj[,] hexBaseObj)
{
    for (int x = 0; x <= MapGenData.Row - 1; x++)
    {
        for (int y = 0; y <= MapGenData.Column - 1; y++)
        {
            if (hexBaseObj[x, y] != null )
            {
                if(hexBaseObj[x, y] != hexBaseObj[MapGenData.Row - 1, MapGenData.Column - 1])
                {
                    if(hexBaseObj[x, y] != hexBaseObj[0, 0])
                    {
                        var passnumber = UnityEngine.Random.Range(0, 100);
                        if (chanceToDectoyHex >= passnumber)
                        {
                            hexBaseObj[x, y] = null;
                        }
                    }
                }
            }
        }
    }
    return hexBaseObj;
}*/

    /*void CheckForExistingNeighbors(HexBaseObj[,] hexBaseObj)
    {

    }*/

}