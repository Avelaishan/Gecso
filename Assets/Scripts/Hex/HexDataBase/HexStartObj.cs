using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHexStat", menuName = "HexData/Start")]
public class HexStartObj : HexBaseObj
{
    [SerializeField]
    private bool isStart;
    [SerializeField]
    private bool isDiscovered;
    public bool IsDiscovered => isDiscovered;
    public bool IsStart => isStart;
}
