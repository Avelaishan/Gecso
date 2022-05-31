using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHexStat", menuName = "HexData/Standart")]
public class HexBaseObj : ScriptableObject
{
    [SerializeField]
    public string Name;
    [SerializeField]
    internal HexBase enemyPrefab;
    [SerializeField]
    private readonly bool baseHex = true;
    [SerializeField]
    public Int32 Score;

    /*public int gCost;
    public int hCost;
    public int fCost
    {
        get { return hCost + gCost; }
    }
    public int gridX;
    public int gridY;
    public bool toDespawn = false;
    public HexBaseObj parent;*/


    public HexBase EnemyPrefab => enemyPrefab;
    public bool BaseHex => baseHex;
}
