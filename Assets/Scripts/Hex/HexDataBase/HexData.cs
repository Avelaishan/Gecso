using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "NewHexStat", menuName = "HexData")]
public class HexData : ScriptableObject
{   
    [SerializeField]
    private int health;
    [SerializeField]
    private int damage;
    [SerializeField]
    public GameObject enemyModel;
    [SerializeField]
    private HexEnemy enemyPrefab;
    [SerializeField]
    private bool isRegen;
    [SerializeField]
    private bool isStart;
    [SerializeField]
    private bool isEnd;

    public GameObject EnemyModel
    {
        get { return enemyModel; }
        set { enemyModel = value; }
    }
    public HexEnemy EnemyPrefab => enemyPrefab;
    public int Health => health;
    public int Damage => damage;
    public bool IsRegen => isRegen;
    public bool IsStart => isStart;
    public bool IsEnd => isEnd;

}
