using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexBase : MonoBehaviour
{
    #region protected stats
    protected bool IsOpen;
    protected bool IsClosed;
    protected bool IsDiscovored;
    protected bool IsBlocked;
    #endregion
    #region public stats
    public int Score;
    public string Name;
    public bool Blocked
    {
        get => IsBlocked;
        set => IsBlocked = value;
    }
    public bool Discovored
    {
        get => IsDiscovored;
        set { IsDiscovored = value; }
    }
    public bool Open
    {
        get => IsOpen;
        set { IsOpen = value; }
    }
    #endregion

    public bool toDespawn;
    public HexBase parent;


    public virtual void HexInitialization<T>(T hex)
        where T : HexBaseObj
    {
        Name = hex.name;
        HexType = hex.HexType; 
    }
    [field: SerializeField]
    public HexType HexType { get; private set; }

}
