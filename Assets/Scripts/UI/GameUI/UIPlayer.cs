using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text attackText;
    [SerializeField]
    private Image HealthBar;

    private void Start()
    {
        UIHandler.current.PlayerUIUpdate += PlayerUI;
    }
    private void PlayerUI(Player player)
    {
        attackText.text = $"Attack: {player.Damage}";
        healthText.text = $"Health: {player.Health}";
        HealtSlider(player.Health, player.MaxHealth);
    }
    private void OnDestroy()
    {
        UIHandler.current.PlayerUIUpdate -= PlayerUI;
    }
    private void HealtSlider(int heath, int maxHealth)
    {
        HealthBar.fillAmount = (float)heath / (float)maxHealth;
    }
}
