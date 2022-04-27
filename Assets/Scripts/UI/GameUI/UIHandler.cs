using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    static public UIHandler current;

    private void Awake()
    {
        current = this; 
    }

    public event Action<Player> PlayerUIUpdate;
    public event Action<HexEnemy> HexUIUpdate;
    public event Action<HexBase> HexUIMaterialChanger;

    public void onPlayerHealthChange(Player player)
    {
        PlayerUIUpdate?.Invoke(player);
    }
    public void onHexHealthChange(HexEnemy hexEnemy)
    {
        HexUIUpdate?.Invoke(hexEnemy);
    }
    public void HexMaterialChanger(HexBase hexBase)
    {
        HexUIMaterialChanger?.Invoke(hexBase);
    }

}
