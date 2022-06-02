using UnityEngine;

public class HexStart : HexBase
{
    public override void HexInitialization<T>(T hex)
    {
        base.HexInitialization<T>(hex);
        HexStartObj hexStart = hex as HexStartObj;
        Discovored = hexStart.IsDiscovered;
    }
}
