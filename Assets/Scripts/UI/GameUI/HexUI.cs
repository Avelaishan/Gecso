using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexUI : MonoBehaviour
{
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text attackText;


    public void PrintHexUI(HexEnemy hex)
    {
        attackText.text = $"Attack: {hex.Damage}";
        healthText.text = $"Health: {hex.Health}";
    }
}

