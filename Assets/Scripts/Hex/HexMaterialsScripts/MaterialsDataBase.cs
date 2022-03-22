using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Materials", menuName = "MaterialsDataBase")]
public class MaterialsDataBase : ScriptableObject
{
    [SerializeField]
    private List<Materials> allHexMaterials;
    public List<Materials> AllHexMaterials => allHexMaterials;
    public Materials GetHexMaterial (string MaterialName)
    {
        Materials hexMaterial = AllHexMaterials.Find(x => x.name == MaterialName);
        return hexMaterial;
    }

}
