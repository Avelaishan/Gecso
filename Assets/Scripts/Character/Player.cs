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
    [SerializeField]
    private int Heal;
    [SerializeField]
    private int AttackPowerUp;
    [SerializeField]
    private int health;
    [SerializeField]
    private int damage;
    [SerializeField]
    public int CurrentHealth;
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
}
