using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "NewHexStat", menuName = "HexStat")]
public class HexStat : ScriptableObject
{   
    public int health;
    public int attack;
    public GameObject enemyModel;
    public bool isOpen;
    public bool isDiscovored;
    public bool isRegen;
    public bool isStart;
    public bool isEnd;

    public int Health => health;
    public int Attack => attack;
    public bool IsOpen => IsOpen;
    public bool IsDiscovored => IsDiscovored;
    public bool IsRegen => isRegen;
    public bool IsStart => isStart;
    public bool IsEnd => isEnd;
}
