
using System;
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


    void Start()
    {
        HexEnemies = new HexEnemy[(int)MapData.Row, (int)MapData.Column];
        CreateHexTileMap(hexData);
    }

    void CreateHexTileMap(HexDataBase hexData)
    {
        for (int x = 0; x <= MapData.Row - 1; x++)
        {
            for (int y = 0; y <= MapData.Column - 1; y++)
            {
                var hexObj = spawner.HexSpawn(SelectHex(hexData), SetPositionVector(x, y));
                //GetHexWidht();
                hexObj.name = $"Hex {x} / {y} ";
                HexEnemies[x, y] = hexObj;
            }
        }
    }
    //hexSize must be founded in GetHexWidht, that currently didnt work ¯\_(-_-)_/¯
    private Vector2 SetPositionVector(int row, int column, float hexSize =1)
    {
        
        Vector2 pos;
        var hexWidth = hexSize / Math.Sqrt(3);
        if (column % 2 == 0)
        {
            pos = new Vector2(row, (float)(column * hexWidth * 3 / 2));
        }
        else
        {
            pos = new Vector2(row + 0.5f, (float)(column * hexWidth * 3 / 2));
        }
        return pos;
    }

    public HexData SelectHex(HexDataBase hexData)
    {
        var lastEntrance = (int)MapData.Row * (int)MapData.Column - 1;
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
            Debug.Log(randomChance);
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
        }
    }
    //didnt work for some reason
    private Vector2 GetHexWidht(GameObject gameObject)
    {
        var hexSize = gameObject.GetComponent<Renderer>().bounds.size;
        return hexSize;
    }
    public void DiscoverNearHex(HexEnemy targetHex)
    {
        Vector2Int vector = GetVector2(targetHex);
        foreach (var item in Neighbors(targetHex))
        {
            item.IsDiscovored = true;
            targetHex.ChangeCollor(targetHex);

        }

    }
    public void OpenTargetHex(HexEnemy targetHex)
    {
        targetHex.IsOpen = true;
        targetHex.ChangeCollor(targetHex);
    }
    private Vector2Int GetVector2(HexEnemy hexEnemy)
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
    private Vector2Int[] matrix = new Vector2Int[]
    {
        new Vector2Int(0, -1),
        new Vector2Int(-1, 0),
        new Vector2Int(-1, 1),
        new Vector2Int(0, 1),
        new Vector2Int(1, 0),
        new Vector2Int(1, -1)
    };
    private List<HexEnemy> Neighbors(HexEnemy hexEnemy)
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
}