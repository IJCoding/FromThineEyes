using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[AddComponentMenu(menuName: "Interactables/Sentient - Undefined")]
[DisallowMultipleComponent]
public class Sentient : MonoBehaviour
{
    [SerializeField]
    private Interactable _Info;

    private void Start()
    {

        _Info = Interactable.CreateInstance<Interactable>();
        _Info.GetStatDict().Clear();
        _Info.GetTraitDict().Clear();

        _Info.GetStatDict().Add("Health", Stat.CreateInstance<Stat>());
        _Info.GetStatDict().Add("Armour", Stat.CreateInstance<Stat>());
        _Info.GetStatDict().Add("Speed", Stat.CreateInstance<Stat>());
        _Info.GetStatDict().Add("Acuity", Stat.CreateInstance<Stat>());

    }
}
