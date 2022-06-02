using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewKeyPointHexStat", menuName = "HexData/KeyPoint")]
public class HexEndObj : HexEnemyObj
{
    [SerializeField]
    internal bool isDiscovored;
    [SerializeField]
    public bool IsDiscovored
    {
        get => isDiscovored;
        set { isDiscovored = value; }
    }
}
