using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public Transform Parent;
    public HexBase HexSpawn(BaseHexObj baseHexObj, Vector2 vector)
    {
        var hexEnemy = Instantiate(baseHexObj.EnemyPrefab, vector, baseHexObj.EnemyPrefab.transform.rotation, Parent);
        hexEnemy.HexInitialization(baseHexObj);
        return hexEnemy;
    }
}
