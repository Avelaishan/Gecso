using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private HexMap HexMap;
    [SerializeField]
    protected Player player;
    protected GameObject raycastedHex;
    protected Action<int,int> Fight;
    [SerializeField]
    private new Camera camera;
    private BonusButtonScripts bonusButtonScripts;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var targetHexEnemy = GetTargetRaycast();
            if (targetHexEnemy != null)
            {
                if(targetHexEnemy.IsDiscovored == false)
                {

                }
                if (targetHexEnemy.IsDiscovored == true & targetHexEnemy.IsOpen == false)
                {
                    HexMap.OpenTargetHex(targetHexEnemy);
                    AddBonus(player);
                }
                else if (targetHexEnemy.IsDiscovored == true & targetHexEnemy.IsOpen == true)
                {
                    GameFight(targetHexEnemy);
                }
            }
        }
    }

    private void DiscoverNearHex(HexEnemy obj)
    {
        HexMap.DiscoverNearHex(obj);
    }

    public HexEnemy GetTargetRaycast()
    {
        RaycastHit2D raycastHit = Physics2D.GetRayIntersection(camera.ScreenPointToRay(Input.mousePosition));
        if (raycastHit.collider != null)
        {
            raycastedHex = raycastHit.collider.gameObject;
            var hexEnemy = raycastedHex.GetComponent<HexEnemy>();
            return hexEnemy;
        }
        return null;
    }

    public void GameFight(HexEnemy hexEnemy)
    {
        if (player.DamageBoostActiv)
        {
            hexEnemy.GetDamage(999);
            player.DamageBoostActiv = false;
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
            }
        }
        //if (!hexEnemy.IsKilled)
        //{
        //    player.GetDamage(hexEnemy.Damage);
        //}
        //if (hexEnemy.IsKilled)
        //{
        //    DiscoverNearHex(hexEnemy);
        //}
    }

    public void AddBonus(Player player)
    {
        if (UnityEngine.Random.Range(0, 100) >= 20)
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
        else
        {

        }
    }
}
