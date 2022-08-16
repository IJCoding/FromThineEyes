using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEffect", menuName = "Effects")]
public class Effect : ScriptableObject
{
    [SerializeField]
    private string _name;

    private void OnEnable()
    {
        _name = this.name;
        if (_name.Length == 0) { _name = "Undefined"; }
    }

    public string GetName() { return _name; }
}
