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
    public int Damage => damage;
    #endregion 

    private void Awake()
    {
        //CurrentHealth = health;
    }
    private void Update()
    {
        PlayerUI();
    }
    private void PlayerUI()
    {
        var CurrentHealth = health.ToString();
        var damage = Damage.ToString();
        damageText.text = $"Attack: {damage}";
        healthText.text = $"Health: {CurrentHealth}";
    }
    public void GetDamage(int hexDamage)
    {
        health -= hexDamage;
        Debug.Log(health);
        if (health <= 0)
        {
            health = 0;
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
