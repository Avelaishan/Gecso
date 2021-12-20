using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResuerceBinding : MonoBehaviour
{
    public HexSpawner HexSpawner;
    public Player player;
    public HexDataBase hexData;
    public HexEnemy enemy;

    public void SetEnemyComponent(List<GameObject> objects)
    {
        foreach (GameObject gameObjects in HexSpawner.tiles)
        {
            var hexObjName = gameObjects.name;
            enemy = gameObjects.GetComponent<HexEnemy>();
            var hexFound = hexData.GetHexStat(hexObjName);
            enemy.health = hexFound.health;
            enemy.attack = hexFound.attack;
            enemy.isOpen = hexFound.isOpen;
            enemy.isDiscovored = hexFound.isDiscovored;
            enemy.isRegen = hexFound.isRegen;
        }
    }
}
