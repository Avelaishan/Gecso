using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyHexStat", menuName = "HexData/Enemy")]
public class HexEnemyObj : BaseHexObj
{
    [SerializeField]
    internal int health;
    [SerializeField]
    internal int damage;
    [SerializeField]
    internal bool isEnemy;
    private bool isRegen;
    public int Damage => damage;
    public bool IsEnemy => isEnemy;
    public int Health => health;
    public bool IsRegen => isRegen;
}
