using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public Trait _trait;

    private void Start()
    {
        _trait = Trait.CreateInstance<Trait>();
    }
}
