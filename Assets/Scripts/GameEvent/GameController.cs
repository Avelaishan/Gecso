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
        if (Input.GetMouseButtonUp(0))
        {
            OnClick();
        }
    }

    private void OnClick()
    {
        var targetHexEnemy = GetTargetRaycast();
        if (targetHexEnemy != null && targetHexEnemy.IsDiscovored)
        {
            InteractWithHex(targetHexEnemy);
            uIHandler.HexMaterialChanger(targetHexEnemy);
        }
    }

    private void InteractWithHex(HexBase hexBase)
    {
        if (hexBase.IsOpen && !hexBase.IsBlocked)
        {
            switch (hexBase)
            {
                case HexEnd hexKeyEnemy:
                    GameFight(hexKeyEnemy);
                    break;
                case HexEnemy hexEnemy:
                    GameFight(hexEnemy);
                    break;
                case HexBase hex:
                    DiscoverNearHex(hex);
                    break;
            }
        }
        else if (!hexBase.IsOpen && !hexBase.IsBlocked)
        {
            if (hexBase is HexEnemy && !(hexBase is HexEnd))
            {
                HexMap.OpenTargetHex(hexBase);
                BlockNearHex(hexBase as HexEnemy);
            }
            if (hexBase is HexStart)
            {
                DiscoverNearHex(hexBase);
            }
            else
            {
                HexMap.OpenTargetHex(hexBase);
            }
            AddBonus(player);
        }
    }

    private void DiscoverNearHex(HexBase obj)
    {
        HexMap.DiscoverNearHex(obj);
    }

    private void BlockNearHex(HexEnemy hexEnemy)
    {
        HexMap.BlockNearHex(hexEnemy);
    }

    private void UnBlockNearHex(HexEnemy hexEnemy)
    {
        HexMap.UnBlockNearHex(hexEnemy);
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
                UnBlockNearHex(hexEnemy);
                DiscoverNearHex(hexEnemy);
                if(hexEnemy is HexEnd)
                {
                    var Score = ++ hexEnemy.Score;
                    WinGame(hexEnemy as HexEnd);
                }
            }
        }
    }

    public void WinGame(HexEnd hexKey)
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
