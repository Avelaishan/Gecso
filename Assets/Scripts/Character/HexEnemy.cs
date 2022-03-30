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
    private bool isClosed;
    private string name;
    private bool isDiscovored;
    private bool isRegen;
    private bool isStart;
    private bool isEnd;
    private bool isKilled;
    #endregion
    public int Damage => damage;
    public bool IsKilled
    {
        get => isKilled;
        set { isKilled = value; }
    }
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
    private MaterialsDataBase materialsData;


    public void HexInitialization(BaseHexObj baseHexObj)
    {
        name = baseHexObj.Name;
    }
    public void HexInitialization(HexEnemyObj hexEnemyObj)
    {
        health = hexEnemyObj.Health;
        damage = hexEnemyObj.Damage;
        name = hexEnemyObj.Name;
    }
    public void HexInitialization(HexKeyPointObj hexKeyPointObj)
    {
        isDiscovored = hexKeyPointObj.IsDiscovored;
        health = hexKeyPointObj.Health;
        damage = hexKeyPointObj.Damage;
        name = hexKeyPointObj.Name;
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

    /*public void ChangeCollor(HexEnemy hexEnemy)
    {
        if (hexEnemy.isStart)
        {
            var hexmat = materialsData.GetHexMaterial("StartHex");
            hexEnemy.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
        else if (hexEnemy.isDiscovored)
        {
            var hexmat = materialsData.GetHexMaterial("StandartHex");
            hexEnemy.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
        else if(hexEnemy.isOpen && hexEnemy.damage > 0)
        {
            var hexmat = materialsData.GetHexMaterial("DiscovoredHex");
            hexEnemy.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
        else if (hexEnemy.isEnd)
        {
            var hexmat = materialsData.GetHexMaterial("EndHex");
            hexEnemy.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
        else if (hexEnemy.IsKilled)
        {
            var hexmat = materialsData.GetHexMaterial("KilledHex");
            hexEnemy.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
        else if (hexEnemy.isStart)
        {
            var hexmat = materialsData.GetHexMaterial("KilledHex");
            hexEnemy.GetComponent<Renderer>().material = hexmat.HexMaterial;
        }
    }*/
}
