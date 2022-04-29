using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexEnd : HexEnemy
{
    private bool isEnd;
    public bool IsEnd => isEnd;

    public override void HexInitialization<T>(T hex)
    {
        base.HexInitialization<T>(hex);
        HexKeyPointObj hexEnemyObj = hex as HexKeyPointObj;
        isEnd = hexEnemyObj.IsEnd;
        isDiscovored = hexEnemyObj.IsDiscovored;
    }
}
