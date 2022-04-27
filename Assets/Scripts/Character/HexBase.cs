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
    #endregion
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
    public MaterialsDataBase materialsData;
    public virtual void HexInitialization<T>(T hex)
        where T : BaseHexObj
    {
        Name = hex.name;
    }
    public virtual void ChangeHexMaterrial<R>(R hex)
        where R : HexBase
    {
        if (hex.isDiscovored)
        {
            var hexmat = materialsData.GetHexMaterial("StandartHex");
            hex.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
        if (hex.isOpen)
        {
            var hexmat = materialsData.GetHexMaterial("StandartHex");
            hex.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
    }
}
