using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Hex Stats Data Base", menuName = "Assets/Database/Item Database")]
public class HexDataBase : ScriptableObject
{
    [SerializeField]
    private List<HexBaseObj> hexTypes;

    public HexBaseObj GetHex(HexType hexType)
    {
        var hexStat = hexTypes.Find(x => x.HexType == hexType);
        return hexStat;
    }
}
