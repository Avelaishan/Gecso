using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Hex Stats Data Base", menuName = "Assets/Database/Item Database")]
public class HexDataBase : ScriptableObject
{
    [SerializeField]
    private List<HexBaseObj> hexTypes;
    [SerializeField]
    private List<HexStartObj> hexStarts;
    [SerializeField]
    private List<HexEnemyObj> hexEnemyTypes;
    [SerializeField]
    private List<HexEndObj> hexKeyTypes;


    //public List<BaseHexObj> HexTypes => hexTypes;
    public HexBaseObj GetHexStat()
    {
        HexBaseObj hexStat = hexTypes.Find(x => x.BaseHex);
        return hexStat;
    }
    public HexStartObj GetStartHexStat()
    {
        HexStartObj hexStat = hexStarts.Find(x => x.IsStart);
        return hexStat;
    }
    public HexEnemyObj GetEnemyHexStat()
    {
        HexEnemyObj hexStat = hexEnemyTypes.Find(x => x.isEnemy);
        return hexStat;
    }
    public HexEndObj GetKeyHexStat()
    {
        HexEndObj hexStat = hexKeyTypes.Find(x => x.IsEnd);
        return hexStat;
    }
}
