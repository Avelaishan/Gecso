using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform Parent;
    [SerializeField]

    public HexEnemy HexSpawn(HexData hexData, Vector2 vector)
    {
        var hexEnemy = Instantiate(hexData.EnemyPrefab, vector, hexData.EnemyPrefab.transform.rotation, Parent);
        hexEnemy.HexInitialization(hexData);
        return hexEnemy;
    }
}
