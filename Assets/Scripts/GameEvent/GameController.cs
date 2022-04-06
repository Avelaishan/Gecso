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
    //private BonusButtonScripts bonusButtonScripts;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var targetHexEnemy = GetTargetRaycast();
            if (targetHexEnemy != null)
            {
                if (targetHexEnemy.IsDiscovored == true & targetHexEnemy.IsOpen == false)
                {
                    HexMap.OpenTargetHex(targetHexEnemy);
                    AddBonus(player);
                }
                /*if (targetHexEnemy is HexBase hexBase && targetHexEnemy.IsDiscovored == true & targetHexEnemy.IsOpen == true)
                {
                    DiscoverNearHex(hexBase);
                }*/
                else if (targetHexEnemy is HexEnemy enemy && targetHexEnemy.IsDiscovored == true & targetHexEnemy.IsOpen == true)
                {
                    GameFight(enemy);
                }
                else if (targetHexEnemy is HexKeyEnemy keyEnemy && targetHexEnemy.IsDiscovored == true & targetHexEnemy.IsOpen == true)
                {
                    GameFight(keyEnemy);
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
            hexEnemy.GetDamage(999);
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
        if (UnityEngine.Random.Range(0, 100) >= 50)
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
