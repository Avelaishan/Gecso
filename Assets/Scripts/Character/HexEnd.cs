
public class HexEnd : HexEnemy
{

    public override void HexInitialization<T>(T hex)
    {
        base.HexInitialization<T>(hex);
        HexEndObj hexEnemyObj = hex as HexEndObj;
        Discovored = hexEnemyObj.IsDiscovored;
    }
}
