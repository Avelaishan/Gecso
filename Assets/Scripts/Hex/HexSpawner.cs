
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

    //public Player Player;

    void Start()
    {
        instance = this;
        CreateHexTileMap(hexData);
    }
    void CreateHexTileMap(HexDataBase hexData)
    {
        for (double x = 0; x <= row-1; x++)
        {
            for (double y = 0; y <= column-1; y++)
            {
                var hexStat = SpawnChose(hexData);
                var visual = Instantiate(hexStat.enemyModel);
                visual.name = hexStat.name;
                visual.transform.SetParent(BackGround, true);
                visual.transform.localScale = 20 * Vector3.one;
                Vector3 pos;
                if (y % 2 == 0)
                {
                    pos = new Vector3((float)(x*20), (float)(y*20 * 3 / 4));
                }
                else
                {
                    pos = new Vector3((float)(x * 20 +10+1), (float)(y * 20 * 3 / 4));
                }
                visual.transform.localPosition = pos;
                tiles.Add(visual);
            }
        }
    Debug.Log(tiles.Count);
    }
    HexStat SpawnChose(HexDataBase hexData)
    {
        System.Random rnd = new System.Random();
        int hexToSpawn = rnd.Next(0, hexData.allHexTypes.Count);
        var hexStat = hexData.allHexTypes[hexToSpawn];
        /*if (hexStat.IsRegen)
        {
            HealTileCounter();
        }*/
        if (hexStat.name == "Start")
        {
            StartTileCounter();
        }
        if (hexStat.name == "End")
        {
            EndTileCounter();
        }

        return hexStat;
    }
    #region counter
    void HealTileCounter()
    {
        HealerNodCounter++;
    }
    void StartTileCounter()
    {
        StartNodCounter++;
    }
    void EndTileCounter()
    {
        EndNodCounter++;
    }
    #endregion
}