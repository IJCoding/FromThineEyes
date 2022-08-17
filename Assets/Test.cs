using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Opinion Op;

    private void Start()
    {
        Op = Opinion.CreateInstance<Opinion>();
    }
}
