using System.Collections;
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
    public HexStat hex;
    //public Player Player;

     void Start()
    {
        instance = this;
        CreateHexTileMap(hex);
    }

    void CreateHexTileMap(HexStat hexStat)
    {
        for (double x = 1; x <= row; x++)
        {
            for (double y = 1; y <= column; y++)
            {
                GameObject visual = Instantiate(hexStat.enemyModel);
                visual.name = hexStat.name;
                visual.transform.SetParent(BackGround);
                Vector3 pos;
                double hexOffset = Math.Sqrt(2) * 120;
                if (y % 2 == 0)
                {
                    pos = new Vector3((float)(x * hexOffset), (float)(y * hexOffset));
                }
                else
                {
                    pos = new Vector3((float)(x * hexOffset + hexOffset / 2), (float)(y * hexOffset + hexOffset / 2));
                }
                visual.transform.localPosition = pos;
                if (hexStat.isRegen)
                {
                    HealTileCounter();
                }
                tiles.Add(visual);
            }
        }
    Debug.Log(tiles.Count);
    }
    void HealTileCounter()
    {
        HealerNodCounter++;
    }
}