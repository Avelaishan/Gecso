using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Hex Stats Data Base", menuName = "Assets/Database/Item Database")]
public class HexDataBase : ScriptableObject
{
    public List<HexStat> allHexTypes;
    public HexStat GetHexStat(string hexName)
    {
        HexStat hexStat = allHexTypes.Find(x => x.name == hexName);
        return hexStat;
    }
}
