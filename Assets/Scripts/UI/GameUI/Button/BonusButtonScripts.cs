using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusButtonScripts : MonoBehaviour
{
    void HealPlayer(Player player)
    {
        if(player.Heal >= 1)
        {
            player.HealPlayer();
        }
        else
        {
            Debug.Log("No Heal");
        }
    }
    void OnePunchPlayer(Player player)
    {
        if(player.AttackPowerUp >= 1)
        {
            player.DamageBoostActiv = true;
        }
        else
        {
            Debug.Log("No Damage Busters");
        }
    }
}
