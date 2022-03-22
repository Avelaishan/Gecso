using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Hex Stats Data Base", menuName = "Assets/Database/Item Database")]
public class HexDataBase : ScriptableObject
{
    [SerializeField]
    private List<HexBaseData> allHexTypes;
    public List<HexBaseData> AllHexTypes => allHexTypes;
    public HexBaseData GetHexStat(string hexName)
    {
        HexBaseData hexStat = allHexTypes.Find(x => x.name == hexName);
        return hexStat;
    }

}
