using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusButtonScripts : MonoBehaviour
{
    void HealPlayer(Player player)
    {
        player.HealPlayer();
    }
    void OnePunchPlayer(Player player)
    {
        player.DamageBoostActiv = true;
    }
}
