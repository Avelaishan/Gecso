using System;
using UnityEngine;

[RequireComponent (typeof(CharacterStat))]
public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    CharacterStat myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStat>();
    }
    public void Attack(CharacterStat targetStats)
    {
        targetStats.TakeDamage(myStats.damage.GetValue());
    }
}
