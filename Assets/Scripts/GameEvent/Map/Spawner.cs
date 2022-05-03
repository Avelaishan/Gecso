using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public Transform Parent;

    public HexBase HexSpawn(HexBaseObj baseHexObj, Vector2 vector)
    {
        var hexEnemy = Instantiate(baseHexObj.EnemyPrefab, vector, baseHexObj.EnemyPrefab.transform.rotation, Parent);
        hexEnemy.HexInitialization(baseHexObj);
        return hexEnemy;
    }
}
