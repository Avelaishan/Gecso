using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHexStat", menuName = "HexData/Standart")]
public class BaseHexObj : ScriptableObject
{
    [SerializeField]
    public string Name;
    [SerializeField]
    internal HexEnemy enemyPrefab;
    [SerializeField]
    internal bool isDiscovored;
    [SerializeField]
    internal bool isOpen;
    [SerializeField]
    internal bool isClosed;
    [SerializeField]
    private readonly bool baseHex = true;
    [SerializeField]
    internal Material HexMaterial;
    [SerializeField]
    internal Material ClassHexMaterial;

    public HexEnemy EnemyPrefab => enemyPrefab;
    public bool IsDiscovored
    {
        get => isDiscovored;
        set { isDiscovored = value; }
    }
    public bool IsOpen
    {
        get => isOpen;
        set { isOpen = value; }
    }
    public bool IsClosed
    {
        get => isClosed;
        set { isClosed = value; }
    }
    public bool BaseHex => baseHex;
}
