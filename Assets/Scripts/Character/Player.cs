using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{
    public Text damageText;
    public Text healthText;
    public Image healthBar;
    public int Heal;
    public int AttackPowerUp;
    public int health;
    public int damage;
    public int CurrentHealth { get; set; }
    private GameObject RaycastedHex;
    public HexDataBase hexData;
    HexEnemy enemy;
    [SerializeField]
    Camera camera;
    private void Start()
    {
        CurrentHealth = health;
        damageText.GetComponent<UnityEngine.UI.Text>().text = "Attack:" + damage ;
        healthText.GetComponent<UnityEngine.UI.Text>().text = "Health:" + CurrentHealth;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseUpAsButton();
        }

    }

    private void OnMouseUpAsButton()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D raycastHit = Physics2D.GetRayIntersection(ray);
        if (raycastHit.collider != null)
        {
            RaycastedHex = raycastHit.collider.gameObject;
            Debug.Log(raycastHit.collider.name);
            SetEnemy(RaycastedHex);
            if(enemy.isDiscovored && enemy.isOpen && !enemy.isKilled)
            {
                Attack();
            }
        }
    }

    void SetEnemy(GameObject gameObject)
    {
        enemy = gameObject.GetComponent<HexEnemy>();
    }
   void Attack()
    {
        CurrentHealth -= enemy.attack;
        enemy.health -= damage;
        /*Debug.Log(CurrentHealth);
        Debug.Log(enemy.health);*/
        healthText.GetComponent<UnityEngine.UI.Text>().text = "Health:" + CurrentHealth;
        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            //PlayerDeath();
            Debug.Log(CurrentHealth);
            healthText.GetComponent<UnityEngine.UI.Text>().text = "Health:" + CurrentHealth;

        }
        if (enemy.health <= 0)
        {
            enemy.health = 0;
            //HexDeath();

            Debug.Log(enemy.health);
        }

    }


    private void PlayerDeath()
    {
        throw new NotImplementedException();
    }
    private void HexDeath()
    {
        throw new NotImplementedException();
    }

}
