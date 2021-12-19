using System;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "NewHexStat", menuName = "HexStat")]
public class HexStat : ScriptableObject
{
    public string enemyName;
    public int health;
    public int attack;
    public GameObject enemyModel;
    public bool isOpen;
    public bool isDiscovored;
    public bool isRegen;

}
