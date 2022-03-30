
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour
{
    [SerializeField]
    private Spawner spawner;
    [SerializeField]
    private HexDataBase hexData;
    [SerializeField]
    private int chanceToSpawnEnemy;
    private int entranceCounter;
    private int enemyCounter;
    public HexEnemy[,] HexEnemies;
    [SerializeField]
    GameObject tileMap;


    void Start()
    {
        HexEnemies = new HexEnemy[(int)MapData.Row, (int)MapData.Column];
        CreateHexTileMap(hexData);
        SetStartTileMap();
    }

    void CreateHexTileMap(HexDataBase hexData)
    {
        for (int x = 0; x <= MapData.Row - 1; x++)
        {
            for (int y = 0; y <= MapData.Column - 1; y++)
            {
                //var HexData = SelectHex(hexData);
                //var position = SetPositionVector(x, y);
                var hexObj = spawner.HexSpawn(SelectHex(hexData), SetPositionVector(x, y));
                //GetHexWidht();
                hexObj.name = $"Hex {x} / {y} ";
                HexEnemies[x, y] = hexObj;
            }
        }
    }
    //hexSize must be founded in GetHexWidht, that currently didnt work ¯\_(-_-)_/¯
     Vector2 SetPositionVector(int row, int column, float hexWight = 70)
    {
        Vector2 pos;
        var hexSize = hexWight / Math.Sqrt(3);
        if (column % 2 == 0)
        {
            pos = new Vector2(row* hexWight, (float)(column * hexSize * 3 / 2));
        }
        else
        {
            pos = new Vector2(row* hexWight + hexWight/2, (float)(column * hexSize * 3 / 2));
        }
        return pos;
    }

    public BaseHexObj SelectHex(HexDataBase hexData)
    {
        var lastEntrance = (int)MapData.Row * (int)MapData.Column - 1;
        if (entranceCounter == 0)
        {
            entranceCounter++;
            HexKeyPointObj hexStat = hexData.GetKeyHexStat("");
            return hexStat;
        }
        else if (entranceCounter == lastEntrance)
        {
            entranceCounter++;
            HexKeyPointObj hexStat = hexData.GetKeyHexStat("End");
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
                BaseHexObj hexStat = hexData.GetHexStat();
                return hexStat;
            }
        }

        /*var lastEntrance = (int)MapData.Row * (int)MapData.Column - 1;
        if (entranceCounter == 0)
        {
            entranceCounter++;
            var hexStat = hexData.AllHexTypes.Find(x => x.IsStart);
            return hexStat;
        }
        else if (entranceCounter == lastEntrance)
        {
            entranceCounter++;
            var hexStat = hexData.AllHexTypes.Find(x => x.IsEnd);
            return hexStat;
        }
        else
        {
            entranceCounter++;
            var hexToSpawn = hexData.AllHexTypes.FindAll(x => !x.IsEnd && !x.IsStart);
            var randomChance  = UnityEngine.Random.Range(1, 100);
            if( chanceToSpawnEnemy <= randomChance)
            {
                var hexStat = hexData.AllHexTypes.Find(x => x.Damage == 0 && x.Health == 1 && !x.IsStart); ;
                return hexStat;
            }
            else
            {
                int enemyCounter = 0;
                var hexDataToSpawn = UnityEngine.Random.Range(0, hexToSpawn.Count);
                if (hexToSpawn[hexDataToSpawn].IsRegen)
                {
                    int regenCount = 0;
                    regenCount++;
                    enemyCounter++;
                    if (regenCount >= 3)
                    {
                        var hexStat = hexData.AllHexTypes.Find(x => x.Damage == 0 && x.Health == 1 && !x.IsStart); ;
                        return hexStat;
                    }
                    else
                    {
                        var hexStat = hexToSpawn[hexDataToSpawn];
                        return hexStat;
                    }
                }
                else if (hexToSpawn[hexDataToSpawn].Damage ==0)
                {
                    var secondRoll = UnityEngine.Random.Range(0, hexToSpawn.Count);
                    if (hexToSpawn[secondRoll].Damage != 0)
                    {
                        enemyCounter++;
                    }
                    var hexStat = hexToSpawn[secondRoll];
                    return hexStat;
                }
                else
                {
                    var hexStat = hexToSpawn[hexDataToSpawn];
                    return hexStat;
                }
            }
        }*/
    }
    //didnt work for some reason
    Vector2 GetHexWidht(HexEnemy hexEnemy)
    {
        var hexSize = hexEnemy.GetComponent<Renderer>().bounds.size;
        return hexSize;
    }

    public void DiscoverNearHex(HexEnemy targetHex)
    {
        Vector2Int vector = GetVector2(targetHex);
        foreach (var item in Neighbors(targetHex))
        {
            item.IsDiscovored = true;
        }
    }

    public void OpenTargetHex(HexEnemy targetHex)
    {
        targetHex.IsOpen = true;
        targetHex.ChangeCollor(targetHex);
    }

    Vector2Int GetVector2(HexEnemy hexEnemy)
    {
        for (int i = 0; i < HexEnemies.GetLength(0); i++)
        {
            for (int j = 0; j < HexEnemies.GetLength(1); j++)
            {
                if (hexEnemy == HexEnemies[i, j])
                {
                    return new Vector2Int(i,j);
                }
            }
        }
    return default;
    }

    Vector2Int[] matrix = new Vector2Int[]
    {
        new Vector2Int(0, -1),
        new Vector2Int(-1, 0),
        new Vector2Int(-1, 1),
        new Vector2Int(0, 1),
        new Vector2Int(1, 0),
        new Vector2Int(1, -1)
    };

    List<HexEnemy> Neighbors(HexEnemy hexEnemy)
    {
        var position = GetVector2(hexEnemy); //1.1
        var neighbors = new List<HexEnemy>();
        foreach (var item in matrix)
        {
            var neighborPos = position + item;
            if (neighborPos.x < 0 || neighborPos.x >= HexEnemies.GetLength(0) || 
                neighborPos.y < 0 || neighborPos.y >= HexEnemies.GetLength(1))
            {
                continue;
            }
            var varov = HexEnemies[neighborPos.x, neighborPos.y];
            neighbors.Add(varov);
        }
        return neighbors;
    }

    public void SetStartTileMap()
    {
        int x = (int)MapData.Row - 1;
        int y = (int)MapData.Column - 1;
        float lastHexPosX = HexEnemies[x, y].transform.position.x;
        float lastHexPosY = HexEnemies[x, y].transform.position.y;
        tileMap.transform.position = new Vector2(-lastHexPosX/2, -lastHexPosY/2);
    }
}