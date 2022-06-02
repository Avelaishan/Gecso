using System;
using UnityEngine;

public class HexEnemy : HexBase
{
    #region protected var
    protected int Health;
    protected int Damage;
    bool isKilled;
    #endregion
    #region public var
    public int MaxHealth;
    public int HexDamage => Damage;
    public int HexHealth => Health;
    public bool IsKilled
    {
        get => isKilled;
        set { isKilled = value; }
    }
    #endregion
    
    public event Action<HexEnemy> HexUIUpdate;

    public override void HexInitialization<T>(T hex)
    {
        base.HexInitialization<T>(hex);
        HexEnemyObj hexEnemyObj = hex as HexEnemyObj;
        Health = hexEnemyObj.Health;
        Damage = hexEnemyObj.Damage;
        
    }

    public void GetDamage(int damage)
    {
        Health -= damage;
        HexUIUpdate?.Invoke(this);
        if (Health <= 0)
        {
            Health = 0;
            HexUIUpdate?.Invoke(this);
            HexDeath();
        }
    }

    public void UIUpdateOnStart()
    {
        HexUIUpdate?.Invoke(this);
    }

    private void HexDeath()
    {
        IsKilled = true;
    }
}
