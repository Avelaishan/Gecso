using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{

    public Text healthText;
    public Image healthBar;
    public int Heal;
    public int AttackPowerUp;
    public int health;
    public int damage;
    public int CurrentHealth { get; set; }
    [Se]
    Camera camera;

    private void Update()
    {
        OnMouseUpAsButton();
    }
    public void OnMouseUpAsButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 50f, Color.red);
                Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
            }
        }

    }
}
