using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region ui
    [SerializeField]
    private Text damageText;
    [SerializeField]
    private Text healthText;
    private Image healthBar;
    #endregion
    #region int stats
    public Int32 Score;
    [SerializeField]
    public int Heal;
    [SerializeField]
    public int AttackPowerUp;
    [SerializeField]
    private int health;
    [SerializeField]
    private int damage;
    public bool DamageBoostActiv;
    [SerializeField]
    private int CurrentHealth;
    public int Damage => damage;
    #endregion 

    private void Awake()
    {
        CurrentHealth = health;
    }

    public void GetDamage(int hexDamage)
    {
        CurrentHealth -= hexDamage;
        health = CurrentHealth;
        Debug.Log(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            PlayerDeath();
            Debug.Log("PlayerDeath");
        }
    }

    private void PlayerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void HealPlayer()
    {
        Heal--;
        health += 30;
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
