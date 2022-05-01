using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text attackText;
    [SerializeField]
    private Image HealthBar;

    public void PrintPlayerUI(Player player)
    {
        attackText.text = $"Attack: {player.Damage}";
        healthText.text = $"Health: {player.Health}";
        HealtSlider(player.Health, player.MaxHealth);
    }
    private void HealtSlider(int heath, int maxHealth)
    {
        HealthBar.fillAmount = (float)heath / (float)maxHealth;
    }
}
