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
    private Player player;
    private GameObject raycastedHex;
    private Action<int,int> Fight;
    [SerializeField]
    private HexCollorChanger hexCollorChanger;
    private event Action<HexBase> ChangeHexColor;
    [SerializeField]
    private Camera playerCamera;

    private void Start()
    {
        ChangeHexColor += hexCollorChanger.HexMaterialChange;
    }
    private void OnDestroy()
    {
        ChangeHexColor -= hexCollorChanger.HexMaterialChange;
    }

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
                HexMap.OpenTargetHex(hexBase);
            }
            else
            {
                HexMap.OpenTargetHex(hexBase);
                DiscoverNearHex(hexBase);
                ChangeHexColor?.Invoke(hexBase);
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
                ChangeHexColor?.Invoke(hexEnemy);
                if (hexEnemy is HexEnd)
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
