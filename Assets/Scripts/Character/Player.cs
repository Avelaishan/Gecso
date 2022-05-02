using System;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region var
    public Int32 Score;
    [SerializeField]
    public int Heal;
    [SerializeField]
    public int AttackPowerUp;
    [SerializeField]
    private int health;
    [SerializeField]
    private int damage;
    public event Action<Player> PlayerUIUpdate;

    public int MaxHealth;
    public int Health => health;
    public bool DamageBoostActiv;
    public int Damage => damage;
    #endregion 

    private void Start()
    {
        PlayerUIUpdate?.Invoke(this);
    }

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
    private void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void HealPlayer()
    {
        Heal--;
        health += 30;
        PlayerUIUpdate?.Invoke(this);
    }
    public void AttackUpPlayer()
    {
        AttackPowerUp--;
    }
    public void ChangeScore(int hexScore)
    {
        Score += hexScore;
    }
}
