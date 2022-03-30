using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewKeyPointHexStat", menuName = "HexData/KeyPoint")]
public class HexKeyPointObj : HexEnemyObj
{
    [SerializeField]
    private bool isStart;
    [SerializeField]
    private bool isEnd;
    public bool IsStart => isStart;
    public bool IsEnd => isEnd;

}
