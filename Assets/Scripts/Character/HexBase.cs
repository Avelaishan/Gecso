using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexBase : MonoBehaviour
{
    #region stats
    protected bool isOpen;
    protected bool isClosed;
    protected bool isDiscovored;
    public string Name;
    protected bool isBlocked;
    #endregion
    public bool IsBlocked
    {
        get => isBlocked;
        set => isBlocked = value;
    }
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
    public virtual void HexInitialization<T>(T hex)
        where T : HexBaseObj
    {
        Name = hex.name;
    }
}
