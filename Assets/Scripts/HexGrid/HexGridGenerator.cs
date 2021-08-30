using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGridGenerator : MonoBehaviour
{
    public GameObject hexPrefab;
    public Transform holder;
    [SerializeField] int mapWiedth = 10;
    [SerializeField] int mapHeight = 10;

    float titleXOffset = 1.8f;
    float titleYOffset = 1.6f;

    List<GameObject> HexList;

    void Start()
    {
        CreateHexTileMap();
    }

    void CreateHexTileMap()
    {
        float maxXMin = -mapWiedth / 2;
        float maxXMax = mapWiedth / 2;
        float maxYMin = -mapHeight / 2;
        float maxYMax = mapHeight / 2;

        for (float x = maxXMin; x <= maxXMax; x++)
        {
            for (float y = maxYMin; y <= maxYMax; y++)
            {
                GameObject TempGO = Instantiate(hexPrefab);
                Vector3 pos;

                if(y%2 == 0)
                {
                    pos = new Vector3(x * titleXOffset, y * titleYOffset,0 );
                }
                else
                {
                    pos = new Vector3(x * titleXOffset+ titleXOffset/2, y * titleYOffset,0);
                }
                StartCoroutine (SetTileInfo(TempGO, x, y, pos));
            }

        }
    }

    IEnumerator SetTileInfo(GameObject tempGO, float x, float y, Vector3 pos)
    {
        yield return new WaitForSeconds(0.00001f);
        tempGO.transform.parent = holder;
        tempGO.name = x.ToString()+" , "+y.ToString();
        tempGO.transform.position = pos;


    }
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
