using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewKeyPointHexStat", menuName = "HexData/KeyPoint")]
public class HexKeyPointObj : HexEnemyObj
{
    [SerializeField]
    private bool isStart;
    [SerializeField]
    internal bool isDiscovored;
    [SerializeField]
    private bool isEnd;
    public bool IsStart => isStart;
    public bool IsEnd => isEnd;
    public bool IsDiscovored
    {
        get => isDiscovored;
        set { isDiscovored = value; }
    }
}
