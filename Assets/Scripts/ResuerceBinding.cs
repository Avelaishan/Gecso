using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResuerceBinding : MonoBehaviour
{
    public HexSpawner HexSpawner;
    public Player player;
    public HexDataBase hexData;
    public HexEnemy enemy;

    public void SetEnemyComponent()
    {
        foreach (GameObject gameObjects in HexSpawner.tiles)
        {
           var hexObjName = gameObjects.GetComponent(name);
            string hexStringName = hexObjName.name;

           //Kill yourself for that 
           if (hexStringName == "Enemy")
           {
               
           }
           if (hexStringName == "Start")
           {

           }
           if (hexStringName == "End")
           {

           }
           if (hexStringName == "Move")
           {

           }
           if (hexStringName == "Def")
           {

           }
           if (hexStringName == "Heal")
           {

           }

        }
    }
    void FindNameOfScriptableObject(GameObject gameObject)
    {
        
        //return  hexName;
    }
}
