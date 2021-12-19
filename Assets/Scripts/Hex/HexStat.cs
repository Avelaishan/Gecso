using System;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu (fileName = "NewHexStat", menuName = "HexStat")]
public class HexStat : ScriptableObject
{   
    public string name;
    
    private int Health
    {
        get
        {
            return health;
        }
    }
    private int health;
    public int Attack
    {
        get
        {
            return attack;
        }
    }
    [SerializeField]
    private int attack;
    public GameObject enemyModel;
    public bool IsOpen
    {
        get
        {
            return IsOpen;
        }
    }
    [SerializeField]
    private int isOpen;
    public bool IsDiscovored
    {
        get
        {
            return IsDiscovored;
        }
    }
    private bool isDiscovored;

    public bool IsRegen
    {
        get
        {
            return isRegen;
        }
    }
    private bool isRegen
}
