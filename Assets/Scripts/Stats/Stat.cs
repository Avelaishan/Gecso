using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat 
{
    public int baseValue;

    public int GetValue()
    {
        return baseValue;
    }
}
