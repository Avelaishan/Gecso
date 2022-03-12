using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexEnemy : MonoBehaviour
{
    #region stats
    private int health;
    private int damage;
    private bool isOpen;
    private bool isDiscovored;
    private bool isRegen;
    private bool isStart;
    private bool isEnd;
    private bool isKilled;
    #endregion
    public int Damage => damage;
    public bool IsKilled => isKilled;
    public bool IsDiscovored
    {
        get => isDiscovored;
        set { isDiscovored = value; }
    }
    public bool IsOpen
    {
        get => isOpen;
        set { isOpen = value; }
    }
    #region color
    [SerializeField]
    private Color startColor;
    [SerializeField]
    private Color standartColor;
    [SerializeField]
    private Color DiscovoredColor;
    [SerializeField]
    private Color EnemyColor;
    [SerializeField]
    private Color endColor;
    [SerializeField]
    private Color killedColor;
    #endregion


    public void HexInitialization(HexData hexData)
    {
        health = hexData.Health;
        damage = hexData.Damage;
        isRegen = hexData.IsRegen;
        hexData.EnemyModel.GetComponent<Renderer>().sharedMaterial.color = standartColor;
        if (hexData.IsStart)
        {
            isStart = true;
            isOpen = true;
            isDiscovored = true;
            hexData.EnemyModel.GetComponent<Renderer>().sharedMaterial.color = startColor;
        }
        if (hexData.IsEnd)
        {
            isEnd = true;
        }

    }
    public void GetDamage(int damage)
    {
        health -= damage;
        if (health > 0)
        {
             Debug.Log(health);
        }
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Hex Death");
            HexDeath();
        }
        Debug.Log(health);
    }

    private void HexDeath()
    {
        isKilled = true;
    }

    public void ChangeCollor(HexEnemy hexEnemy)
    {
        if (hexEnemy.isDiscovored)
        {
            hexEnemy.GetComponent<Renderer>().sharedMaterial.color = DiscovoredColor;
        }
        if (hexEnemy.isOpen && hexEnemy.damage > 0)
        {
            hexEnemy.GetComponent<Renderer>().sharedMaterial.color = EnemyColor;

        }
        else if (hexEnemy.isEnd)
        {
            hexEnemy.GetComponent<Renderer>().sharedMaterial.color = endColor;
        }
        else if (hexEnemy.IsKilled)
        {
            hexEnemy.GetComponent<Renderer>().sharedMaterial.color = killedColor;
        }
    }
}
