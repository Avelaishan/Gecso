using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGridGenerator : MonoBehaviour
{
    public GameObject hexPrefab;
    public Transform holder;
    [SerializeField] int mapWiedth = 6;
    [SerializeField] int mapHeight = 3;

    float titleXOffset = 1.8f;
    float titleYOffset = 1.6f;

    public List<GameObject> tiles = new List<GameObject>();

    void Start()
    {
        CreateHexTileMap();
        RandomNumberGenerator();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Vector3 hexPosition = hit.transform.gameObject.transform.position;
                for(int i = 0; i<tiles.Count; i++)
                {
                    if (tiles[i].transform.position == hexPosition)
                    {
                        Debug.Log(tiles[i].name);
                    }
                }
                if (hit.collider.gameObject == gameObject)
                {
                    if (hit.collider.tag == "UnOpenHex")
                        hit.collider.tag = "OpenHex";
                    else if (hit.collider.tag == "HidenHex")
                        hit.collider.tag = "OpenHex";
                    else if (hit.collider.tag == "finish") ;
                    else if (hit.collider.tag == "UpHex") ;

                }
            }
        }
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
                tiles.Add(TempGO);
            }
        }
        Debug.Log(tiles.Count);
    }

    IEnumerator SetTileInfo(GameObject tempGO, float x, float y, Vector3 pos)
    {
        yield return new WaitForSeconds(0.1f);
        tempGO.transform.parent = holder;
        tempGO.name = x.ToString()+" , "+y.ToString();
        tempGO.transform.position = pos;


    }

    public int RandomNumberGenerator()
    {
        int listLenght = tiles.Count;
        var result = UnityEngine.Random.Range(0, listLenght);
        return result;

    }

    /*void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }*/
}
