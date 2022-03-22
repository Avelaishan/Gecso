using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public Transform Parent;

    public HexEnemy HexSpawn(HexBaseData hexBaseData, Vector2 vector)
    {
        var hexEnemy = Instantiate(hexBaseData.EnemyPrefab, vector, hexBaseData.EnemyPrefab.transform.rotation, Parent);
        hexEnemy.HexInitialization(hexBaseData);
        return hexEnemy;
    }
}
