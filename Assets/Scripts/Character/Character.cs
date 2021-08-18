using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


[Serializable]
public class Character : ISerializable
{
    public string Name;
    [SerializeField]
    private GameObject characterPrefab;
    [SerializeField]
    private int DMG = 30;


    public GameObject CharacterPrefab
    {
        get { return characterPrefab; }
        set { characterPrefab = value; }
    }

    #region Inventory
    protected int healUP = 0;
    protected int armor = 0;
    protected int dmgUP = 0;
    #endregion

    public bool IsDead
    {
        get
        {
            return CurrentHP <= 0;
        }
    }

    [NonSerialized]
    public int CurrentHP;
    public int MaxHP = 250;

    [NonSerialized]
    public bool AttackEnd = false;

    #region Events
    public event Action<int> HPChanged;
    public event Action Died;
    public event Action CharacterAttack;
    public event Action CharacterHealing;
    #endregion

    #region Button
    public Button Heal;
    public Button Shield;
    #endregion

    private CancellationTokenSource healCancelationSource;

    public Character() { }

    protected Character(SerializationInfo info, StreamingContext context)
    {
        foreach (var entry in info)
        {
            switch (entry.Name)
            {
                case "Name":
                    Name = entry.Value as string;
                    break;
                case "DMG":
                    DMG = (int)entry.Value;
                    break;
                case "healBottles":
                    healUP = (int)entry.Value;
                    break;

            }
        }
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("Name", Name);
        info.AddValue("DMG", DMG);
        info.AddValue("healBottles", healUP);
        info.AddValue("armor", armor);
    }

    public async Task Attack(Character target)
    {
        if (IsDead) return;

        CharacterAttack?.Invoke();
        Debug.LogError($"Character attack");
        AttackEnd = false;
        target.GetDamage(DMG);
    }

    public void GetDamage(int incomeDmg)
    {
        var dmg = incomeDmg;
        CurrentHP -= dmg;
        HPChanged?.Invoke(dmg);
        if (CurrentHP <= 0)
        {
            Die();
        }
    }

    public void ClearEvents()
    {
        HPChanged = null;
        CharacterAttack = null;
        Died = null;
    }

    public void AddHealPoition()
    {
        healUP++;
    }

    private void Die()
    {
        Died?.Invoke();
    }

    private void ActiveHeal()
    {
        if (healCancelationSource != null) healCancelationSource.Dispose();
        healCancelationSource = new CancellationTokenSource();
        Heal.onClick.AddListener(Healing);
        
    }

    private void Healing()
    {
        healUP--;
        CurrentHP += 50;
        if (CurrentHP >= MaxHP)
        {
            CurrentHP = MaxHP;
        }
    }
}
