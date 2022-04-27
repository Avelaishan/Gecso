using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private HexMap HexMap;
    [SerializeField]
    protected Player player;
    protected GameObject raycastedHex;
    protected Action<int,int> Fight;
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private UIHandler uIHandler;

    private void Update()
    {
        uIHandler.onPlayerHealthChange(player);
        if (Input.GetMouseButtonUp(0))
        {
            var targetHexEnemy = GetTargetRaycast();
            if (targetHexEnemy != null && targetHexEnemy.IsDiscovored)
            {
                if (targetHexEnemy.IsOpen)
                {
                    switch (targetHexEnemy)
                    {
                        case HexKeyEnemy hexKeyEnemy :
                            GameFight(hexKeyEnemy);
                            uIHandler.onHexHealthChange(hexKeyEnemy);
                            uIHandler.onPlayerHealthChange(player);
                            uIHandler.HexMaterialChanger(targetHexEnemy);
                            break;
                        case HexEnemy hexEnemy:
                            GameFight(hexEnemy);
                            uIHandler.onHexHealthChange(hexEnemy);
                            uIHandler.onPlayerHealthChange(player);
                            uIHandler.HexMaterialChanger(targetHexEnemy);
                            break;
                        case HexBase hex:
                            DiscoverNearHex(hex);
                            uIHandler.HexMaterialChanger(targetHexEnemy);
                            break;
                    }
                }
                else
                {
                    HexMap.OpenTargetHex(targetHexEnemy);
                    uIHandler.HexMaterialChanger(targetHexEnemy);
                    AddBonus(player);
                }
            }
        }
    }
    private void DiscoverNearHex(HexBase obj)
    {
        HexMap.DiscoverNearHex(obj);
    }
    public HexBase GetTargetRaycast()
    {
        RaycastHit2D raycastHit = Physics2D.GetRayIntersection(playerCamera.ScreenPointToRay(Input.mousePosition));
        if (raycastHit.collider != null)
        {
            raycastedHex = raycastHit.collider.gameObject;
            var hexEnemy = raycastedHex.GetComponent<HexBase>();
            return hexEnemy;
        }
        else
        {
            return null;
        }
    }
    public void GameFight(HexEnemy hexEnemy)
    {
        if (player.DamageBoostActiv)
        {
            hexEnemy.GetDamage(hexEnemy.Health);
            player.DamageBoostActiv = false;
            player.AttackPowerUp--;
        }
        if (!player.DamageBoostActiv)
        {
          hexEnemy.GetDamage(player.Damage);
            if (!hexEnemy.IsKilled)
            {
                player.GetDamage(hexEnemy.Damage);
            }
            if (hexEnemy.IsKilled)
            {
                DiscoverNearHex(hexEnemy);
                if(hexEnemy is HexKeyEnemy)
                {
                    WinGame(hexEnemy as HexKeyEnemy);
                }
            }
        }
    }
    public void WinGame(HexKeyEnemy hexKey)
    {
        if(hexKey.IsEnd && hexKey.IsKilled)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void AddBonus(Player player)
    {
        if (UnityEngine.Random.Range(0, 100) >= 80)
        {
            if(UnityEngine.Random.Range(0, 100) >= 20)
            {
                player.Heal++;
            }
            else
            {
                player.AttackPowerUp++;
            }
        }
    }
}
