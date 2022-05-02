using System;
using UnityEngine;

public class HexEnemy : HexBase
{
    protected int health;
    protected int damage;
    private bool isKilled;
    public int MaxHealth;
    public int Damage => damage;
    public int Health => health;
    public event Action<HexEnemy> HexUIUpdate;
    public bool IsKilled
    {
        get => isKilled;
        set { isKilled = value; }
    }
    protected void Start()
    {
        HexUIUpdate?.Invoke(this);
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
        HexUIUpdate?.Invoke(this);
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Hex Death");
            HexUIUpdate?.Invoke(this);
            HexDeath();
        }
        Debug.Log(health);
    }

    private void HexDeath()
    {
        IsKilled = true;
    }
}
