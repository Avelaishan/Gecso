using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyHexStat", menuName = "HexData/Enemy")]
public class HexEnemyObj : HexBaseObj
{
    [SerializeField]
    internal int health;
    [SerializeField]
    internal int damage;
    [SerializeField]
    internal bool isEnemy;
    public int Damage => damage;
    public bool IsEnemy => isEnemy;
    public int Health => health;
}
