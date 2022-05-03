using UnityEngine;

public class HexStart : HexBase
{
    [SerializeField]
    private bool isStart;

    public override void HexInitialization<T>(T hex)
    {
        HexStartObj hexStart = hex as HexStartObj;
        isStart = hexStart.IsStart;
        Discovored = hexStart.IsDiscovered;
    }
}
