using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public int currentHealth { get;set; }
    public int health;
    public Stat damage;


    private void Awake()
    {
        currentHealth = health;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(transform.name + "taken" + damage + "damage.");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        Debug.Log(transform.name + "died");
    }

}
