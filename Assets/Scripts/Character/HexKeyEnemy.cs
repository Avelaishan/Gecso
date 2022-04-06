using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexKeyEnemy : HexEnemy
{
    private bool isStart;
    private bool isEnd;
    public override void HexInitialization<T>(T hex)
    {
        base.HexInitialization<T>(hex);
        HexKeyPointObj hexEnemyObj = hex as HexKeyPointObj;
        isEnd = hexEnemyObj.IsEnd;
        isStart = hexEnemyObj.IsStart;
        isDiscovored = hexEnemyObj.IsDiscovored;
    }
}
