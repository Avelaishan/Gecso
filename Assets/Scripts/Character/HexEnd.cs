
public class HexEnd : HexEnemy
{
    public bool End => IsEnd;
    private bool IsEnd;

    public override void HexInitialization<T>(T hex)
    {
        base.HexInitialization<T>(hex);
        HexKeyPointObj hexEnemyObj = hex as HexKeyPointObj;
        IsEnd = hexEnemyObj.IsEnd;
        Discovored = hexEnemyObj.IsDiscovored;
    }
}
