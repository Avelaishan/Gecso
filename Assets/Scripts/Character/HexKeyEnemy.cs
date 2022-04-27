using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexKeyEnemy : HexEnemy
{
    private bool isStart;
    private bool isEnd;
    public bool IsEnd => isEnd;
    public bool IsStart => isStart;

    public override void HexInitialization<T>(T hex)
    {
        base.HexInitialization<T>(hex);
        HexKeyPointObj hexEnemyObj = hex as HexKeyPointObj;
        isEnd = hexEnemyObj.IsEnd;
        isStart = hexEnemyObj.IsStart;
        isDiscovored = hexEnemyObj.IsDiscovored;
    }
    public override void ChangeHexMaterrial<R>(R hex)
    {
        HexKeyEnemy hexEnemyObj = hex as HexKeyEnemy;
        if (hexEnemyObj.isStart)
        {
            var hexmat = materialsData.GetHexMaterial("StartHex");
            hex.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
        else if (hexEnemyObj.IsEnd)
        {
            var hexmat = materialsData.GetHexMaterial("EndHex");
            hex.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
    }
}
