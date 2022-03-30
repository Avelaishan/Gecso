using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Hex Stats Data Base", menuName = "Assets/Database/Item Database")]
public class HexDataBase : ScriptableObject
{
    [SerializeField]
    private List<BaseHexObj> hexTypes;
    [SerializeField]
    private List<HexEnemyObj> hexEnemyTypes;
    [SerializeField]
    private List<HexKeyPointObj> hexKeyTypes;


    //public List<BaseHexObj> HexTypes => hexTypes;
    public BaseHexObj GetHexStat()
    {
        BaseHexObj hexStat = hexTypes.Find(x => x.BaseHex);
        return hexStat;
    }
    public HexEnemyObj GetEnemyHexStat()
    {
        HexEnemyObj hexStat = hexEnemyTypes.Find(x => x.isEnemy);
        return hexStat;
    }
    public HexKeyPointObj GetKeyHexStat(string hexName)
    {
        if (hexName == "End")
        {
            HexKeyPointObj hexStat = hexKeyTypes.Find(x =>x.IsEnd);
            return hexStat;
        }
        else
        {
            HexKeyPointObj hexStat = hexKeyTypes.Find(x => x.IsStart);
            return hexStat;
        }
    }
}
