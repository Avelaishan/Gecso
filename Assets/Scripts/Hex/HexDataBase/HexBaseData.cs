using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHexStat", menuName = "HexData/Standart")]
public class HexBaseData : ScriptableObject
{
    [SerializeField]
    private int health;
    [SerializeField]
    private HexEnemy enemyPrefab;
    public int Health => health;
    public HexEnemy EnemyPrefab => enemyPrefab;
    [SerializeField]
    private int damage;
    public int Damage => damage;
    [SerializeField]
    private bool isEnemy;
    public bool IsEnemy => isEnemy;
    [SerializeField]
    private bool isStart;
    [SerializeField]
    private bool isEnd;
    private bool isDiscovored;
    private bool isOpen;
    public bool IsStart => isStart;
    public bool IsEnd => isEnd;
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
    [SerializeField]
    private bool isRegen;
    public bool IsRegen => isRegen;

}
