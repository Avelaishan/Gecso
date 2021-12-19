using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public Text healthText;
    public Image healthBar;
    public int Heal;
    public int AttackPowerUp;
    public int health;
    public int damage;
    public int CurrentHealth { get; set; }

}
