using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexEnemy : HexBase
{
    protected int health;
    protected int damage;
    //protected bool isRegen;
    private bool isKilled;
    public int Damage => damage;
    public bool IsKilled
    {
        get => isKilled;
        set { isKilled = value; }
    }

    public override void HexInitialization<T>(T hex)
    {
        base.HexInitialization<T>(hex);
        HexEnemyObj hexEnemyObj = hex as HexEnemyObj;
        health = hexEnemyObj.Health;
        damage = hexEnemyObj.Damage;
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
        IsKilled = true;
    }
}
