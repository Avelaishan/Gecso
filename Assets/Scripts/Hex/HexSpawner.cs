
using System;
using System.Collections.Generic;
using UnityEngine;

public class HexSpawner : MonoBehaviour
{
    public Transform BackGround;
    public int row;
    public int column;
    public List<GameObject> tiles;
    public static HexSpawner instance;
    public int HealerNodCounter;
    public int StartNodCounter;
    public int EndNodCounter;
    public HexDataBase hexData;
    public ResuerceBinding resuerce;
    int EntranceCounter = 0;

    void Start()
    {
        instance = this;
        CreateHexTileMap(hexData);
        resuerce.SetEnemyComponent(tiles);
    }

    void CreateHexTileMap(HexDataBase hexData)
    {
        for (int x = 1; x <= row; x++)
        {
            for (int y = 1; y <= column; y++)
            {
                var hexStat = SpawnChose(hexData);
                var visual = Instantiate(hexStat.enemyModel);
                visual.name = hexStat.name;
                visual.transform.SetParent(BackGround, true);
                visual.transform.localScale = 70 * Vector2.one;
                Vector2 pos;
                if (y % 2 == 0)
                {
                    pos = new Vector2(x*70+35 - 350,y*70 * 3 / 4 - 140);
                }
                else
                {
                    pos = new Vector2(x * 70 - 350, y * 70 * 3 / 4 - 140);
                }
                visual.transform.localPosition = pos;
                tiles.Add(visual);
            }
        }
    Debug.Log(tiles.Count);
    }
    HexStat SpawnChose(HexDataBase hexData)
    {
        var lastEntrance = row * column-1;
        System.Random rnd = new System.Random();
        if (EntranceCounter == 0)
        {
            var hexStat = hexData.allHexTypes.Find(x=>x.isStart==true);
            EntranceCounter++;
            return hexStat;
        }
        else if (EntranceCounter == lastEntrance)
        {
            var hexStat = hexData.allHexTypes.Find(x => x.isEnd == true);
            EntranceCounter++;
            return hexStat;

        }
        else
        {
            var hexToSpawn = hexData.allHexTypes.FindAll(x => x.isEnd == false && x.isStart == false);

            var hexDataToSpawn = rnd.Next(0, hexToSpawn.Count);
            var hexStat = hexToSpawn[1];
            EntranceCounter++;
            return hexStat;
        }
    }

}