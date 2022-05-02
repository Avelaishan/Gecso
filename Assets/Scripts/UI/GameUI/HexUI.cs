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
    private HexEnemy hexEnemy;

    protected void Start()
    {
        hexEnemy.HexUIUpdate += PrintHexUI;
    }
    private void OnDestroy()
    {
        if (hexEnemy != null)
        {
            hexEnemy.HexUIUpdate -= PrintHexUI;
        }
    }

    public void PrintHexUI(HexEnemy hex)
    {
        attackText.text = $"Attack: {hex.Damage}";
        healthText.text = $"Health: {hex.Health}";
    }
}

