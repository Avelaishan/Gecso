using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Player : CharacterStat
{
    public Text healthText;
    public Image healthBar;
    int Heal;
    int AttackPowerUp;

}
