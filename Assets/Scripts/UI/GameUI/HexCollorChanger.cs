using UnityEngine;

public class HexCollorChanger : MonoBehaviour
{
    [SerializeField] 
    public MaterialsDataBase materialsData;

    public void HexMaterialChange(HexBase hex)
    {
        if (hex != null)
        {
            switch (hex)
            {
                case HexEnd hexKeyEnemy:
                    if (hexKeyEnemy.Discovored)
                    {
                        var hexmat = materialsData.GetHexMaterial("EndHex");
                        hex.GetComponent<Renderer>().material = hexmat.HexMaterial;
                    }
                    break;
                case HexEnemy hexEnemy:
                    if (hexEnemy.IsKilled)
                    {
                        var hexmat = materialsData.GetHexMaterial("KilledHex");
                        hex.GetComponent<Renderer>().material = hexmat.HexMaterial;

                    }
                    if (hexEnemy.Discovored && !hexEnemy.IsKilled)
                    {
                        var hexmat = materialsData.GetHexMaterial("EnemyHex");
                        hex.GetComponent<Renderer>().material = hexmat.HexMaterial;
                    }
                    break;
                case HexBase hexBase:
                    if (hexBase.Open)
                    {
                        var hexmat = materialsData.GetHexMaterial("DiscovoredHex");
                        hex.GetComponent<Renderer>().material = hexmat.HexMaterial;
                    }
            break;
            }
        }
    }
}
