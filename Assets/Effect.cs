using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEffect", menuName = "Effects")]
public class Effect : ScriptableObject
{
    public string GetName()
    {
        return this.name;
    }

}
