using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] HexMap HexMap;
    [SerializeField] Player player;
    [SerializeField] HexCollorChanger hexCollorChanger;
    [SerializeField] Camera playerCamera;
    GameObject raycastedHex;
    public event Action<HexBase> ChangeHexColor;
    public static int PlayerScore;

    private void Start()
    {
        ChangeHexColor += hexCollorChanger.HexMaterialChange;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            OnClick();
        }
    }

    private void OnDestroy()
    {
        ChangeHexColor -= hexCollorChanger.HexMaterialChange;
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
            hexEnemy.GetDamage(hexEnemy.HexHealth);
            player.DamageBoostActiv = false;
            player.AttackUpPlayer();
        }
        if (!player.DamageBoostActiv)
        {
          hexEnemy.GetDamage(player.Damage);
            if (!hexEnemy.IsKilled)
            {
                player.GetDamage(hexEnemy.HexDamage);
            }
            if (hexEnemy.IsKilled)
            {
                //UnBlockNearHex(hexEnemy);
                //DiscoverNearHex(hexEnemy);
                ChangeHexColor?.Invoke(hexEnemy);
                if (hexEnemy is HexEnd)
                {
                    var PlayerScore = ++ hexEnemy.Score;
                    WinGame(hexEnemy as HexEnd);
                }
            }
        }
    }

    public void WinGame(HexEnd hexKey)
    {
        if(hexKey.HexType == HexType.End && hexKey.IsKilled)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    /* BonusId 1=heal 2=attack
    /public void AddBonus(Player player)
    {
        if (UnityEngine.Random.Range(0, 100) >= 80)
        {
            if(UnityEngine.Random.Range(0, 100) >= 20)
            {
                player.PlayerRedeemBonus(1);
            }
            else
            {
                player.PlayerRedeemBonus(2);
            }
        }
    }*/

    private void OnClick()
    {
        var targetHexEnemy = GetTargetRaycast();
        if (targetHexEnemy != null && targetHexEnemy.Discovored)
        {
            //InteractWithHex(targetHexEnemy);
        }
    }

    /*private void InteractWithHex(HexBase hexBase)
    {
        if (hexBase.Open && !hexBase.Blocked)
        {
            if (hexBase.HexType == HexType.Enemy)
            {
                GameFight(hexBase as HexEnemy);
            }
            else if (hexBase.HexType == HexType.End)
            {
                GameFight(hexBase as HexEnd);
            }
        }
        else if (!hexBase.Open && !hexBase.Blocked)
        {
            if (hexBase.HexType == HexType.Enemy)
            {
                HexMap.OpenTargetHex(hexBase);
                var hexEnemy = hexBase as HexEnemy;
                hexEnemy.UIUpdateOnStart();
                BlockNearHex(hexEnemy);
            }
            if (hexBase.HexType == HexType.Start)
            {
                DiscoverNearHex(hexBase);
                HexMap.OpenTargetHex(hexBase);
            }
            if (hexBase.HexType == HexType.End)
            {
                HexMap.OpenTargetHex(hexBase);
                var hexEnd = hexBase as HexEnd;
                hexEnd.UIUpdateOnStart();
                DiscoverNearHex(hexBase);
                ChangeHexColor?.Invoke(hexBase);
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
    */
}
