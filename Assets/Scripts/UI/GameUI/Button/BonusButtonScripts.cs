using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusButtonScripts : MonoBehaviour
{
    private void HealPlayer(Player player)
    {
        if(player.HealPowerUp >= 1)
        {
            player.HealPlayer();
        }
        else
        {
            Debug.Log("No Heal");
        }
    }
    private void OnePunchPlayer(Player player)
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
