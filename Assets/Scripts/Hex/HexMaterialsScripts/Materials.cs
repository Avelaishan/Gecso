using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Materials", menuName = "Materials")]

public class Materials : ScriptableObject
{
    [SerializeField] 
    private Material hexMaterial;
    public Material HexMaterial => hexMaterial;

}
