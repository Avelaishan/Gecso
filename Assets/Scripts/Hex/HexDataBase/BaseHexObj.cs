using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHexStat", menuName = "HexData/Standart")]
public class BaseHexObj : ScriptableObject
{
    [SerializeField]
    public string Name;
    [SerializeField]
    internal HexBase enemyPrefab;
    [SerializeField]
    private readonly bool baseHex = true;
    [SerializeField]
    internal Material HexMaterial;
    [SerializeField]
    internal Material ClassHexMaterial;
    [SerializeField]
    public Int32 Score;

    public HexBase EnemyPrefab => enemyPrefab;
    public bool BaseHex => baseHex;
}
