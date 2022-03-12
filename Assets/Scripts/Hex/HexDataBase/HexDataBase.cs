using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Hex Stats Data Base", menuName = "Assets/Database/Item Database")]
public class HexDataBase : ScriptableObject
{
    [SerializeField]
    private List<HexData> allHexTypes;
    public List<HexData> AllHexTypes => allHexTypes;
    public HexData GetHexStat(string hexName)
    {
        HexData hexStat = allHexTypes.Find(x => x.name == hexName);
        return hexStat;
    }

}
