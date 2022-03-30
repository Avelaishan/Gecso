using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public Transform Parent;


    public HexEnemy HexSpawn(BaseHexObj baseHexObj, Vector2 vector)
    {
        var hexEnemy = Instantiate(baseHexObj.EnemyPrefab, vector, baseHexObj.EnemyPrefab.transform.rotation, Parent);
        hexEnemy.HexInitialization(baseHexObj);
        return hexEnemy;
    }
    public HexEnemy HexSpawn(HexEnemyObj hexEnemyObj, Vector2 vector)
    {
        var hexEnemy = Instantiate(hexEnemyObj.EnemyPrefab, vector, hexEnemyObj.EnemyPrefab.transform.rotation, Parent);
        hexEnemy.HexInitialization(hexEnemyObj);
        return hexEnemy;
    }
    public HexEnemy HexSpawn(HexKeyPointObj hexKeyPointObj, Vector2 vector)
    {
        var hexEnemy = Instantiate(hexKeyPointObj.EnemyPrefab, vector, hexKeyPointObj.EnemyPrefab.transform.rotation, Parent);
        hexEnemy.HexInitialization(hexKeyPointObj);
        return hexEnemy;
    }
    /*public HexEnemy HexSpawn(BaseHexObj hexBaseData, Vector2 vector)
    {
        var hexEnemy = Instantiate(hexBaseData.EnemyPrefab, vector, hexBaseData.EnemyPrefab.transform.rotation, Parent);
        hexEnemy.HexInitialization(hexBaseData);
        return hexEnemy;
    }*/
}
