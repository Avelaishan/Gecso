using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region private var
    public Int32 Score;
    [SerializeField]
    private int healPowerUp;
    [SerializeField]
    private int attackPowerUp;
    [SerializeField]
    private int health;
    [SerializeField]
    private int damage;
    #endregion
    #region public var
    public int HealPowerUp => healPowerUp;
    public int AttackPowerUp => attackPowerUp;
    public int MaxHealth;
    public int Health => health;
    public bool DamageBoostActiv;
    public int Damage => damage;
    #endregion
    #region events
    public event Action<Player> PlayerUIUpdate;
    public event Action<Player> PlayerBonusUIUpdate;
    #endregion

    public void GetDamage(int hexDamage)
    {
        health -= hexDamage;
        PlayerUIUpdate?.Invoke(this);
        Debug.Log(health);
        if (health <= 0)
        {
            PlayerDeath();
            Debug.Log("PlayerDeath");
        }
    }

    public void HealPlayer()
    {
        healPowerUp--;
        health += 30;
        PlayerBonusUIUpdate?.Invoke(this);
    }

    public void AttackUpPlayer()
    {
        attackPowerUp--;
        PlayerBonusUIUpdate?.Invoke(this);
    }

    public void ChangeScore(int hexScore)
    {
        Score += hexScore;
    }

    public void PlayerRedeemBonus(int bonusId)
    {
        if (bonusId == 1)
        {
            healPowerUp ++;
            PlayerBonusUIUpdate?.Invoke(this);
        }
        if (bonusId == 2)
        {
            attackPowerUp++;
            PlayerBonusUIUpdate?.Invoke(this);
        }
    }

    private void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
