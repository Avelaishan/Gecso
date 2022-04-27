using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHex : MonoBehaviour
{
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text attackText;
    [SerializeField]
    private Image HealthBar;

    private void Start()
    {
        UIHandler.current.HexUIUpdate += HexUI;
    }

    private void HexUI(HexEnemy hex)
    {
        attackText.text = $"Attack: {hex.Damage}";
        healthText.text = $"Health: {hex.Health}";
        if(hex.MaxHealth != 0 && hex.Health != 0)
        {
            HealtSlider(hex.Health, hex.MaxHealth);
        }
    }
    private void OnDestroy()
    {
        UIHandler.current.HexUIUpdate -= HexUI;
    }
    private void HealtSlider(int heath, int maxHealth) 
    {
        HealthBar.fillAmount = (float)heath / (float)maxHealth;
    }

}

