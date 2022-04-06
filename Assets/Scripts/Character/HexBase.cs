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

    public virtual void HexInitialization<T>(T hex)
        where T : BaseHexObj
    {
        Name = hex.name;
    }
    /*public void ChangeCollor(HexEnemy hexEnemy)
    {
        if (hexEnemy.isStart)
        {
            var hexmat = materialsData.GetHexMaterial("StartHex");
            hexEnemy.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
        else if (hexEnemy.isDiscovored)
        {
            var hexmat = materialsData.GetHexMaterial("StandartHex");
            hexEnemy.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
        else if(hexEnemy.isOpen && hexEnemy.damage > 0)
        {
            var hexmat = materialsData.GetHexMaterial("DiscovoredHex");
            hexEnemy.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
        else if (hexEnemy.isEnd)
        {
            var hexmat = materialsData.GetHexMaterial("EndHex");
            hexEnemy.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
        else if (hexEnemy.IsKilled)
        {
            var hexmat = materialsData.GetHexMaterial("KilledHex");
            hexEnemy.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
        else if (hexEnemy.isStart)
        {
            var hexmat = materialsData.GetHexMaterial("KilledHex");
            hexEnemy.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
    }*/
}
