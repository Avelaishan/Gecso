using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    #region Serializeble
    [SerializeField] 
    Text healthText;
    [SerializeField] 
    Text attackText;
    [SerializeField] 
    Text BombCounter;
    [SerializeField] 
    Text HealCounter;
    [SerializeField] 
    Image HealthBar;
    [SerializeField] 
    Player player;
    #endregion

    private void Start()
    {
        player.PlayerUIUpdate += PrintPlayerUI;
        player.PlayerBonusUIUpdate += PrintPlayerBonusUI;
        PrintPlayerUI(player);
        PrintPlayerBonusUI(player);
    }
    private void OnDestroy()
    {
        if (player != null)
        {
            player.PlayerUIUpdate -= PrintPlayerUI;
            player.PlayerBonusUIUpdate -= PrintPlayerBonusUI;
        }
    }

    public void PrintPlayerUI(Player player)
    {
        attackText.text = $"Attack: {player.Damage}";
        healthText.text = $"Health: {player.Health}";
        HealtSlider(player.Health, player.MaxHealth);
    }

    public void PrintPlayerBonusUI(Player player)
    {
        BombCounter.text = $"Bomb: {player.AttackPowerUp}";
        HealCounter.text = $"Heal: {player.HealPowerUp}";
    }

    private void HealtSlider(int heath, int maxHealth)
    {
        HealthBar.fillAmount = (float)heath / (float)maxHealth;
    }
}
