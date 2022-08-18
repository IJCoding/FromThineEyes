using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

[AddComponentMenu(menuName: "Interactables/Sentient - Undefined")]
[RequireComponent(typeof(SphereCollider))]
[DisallowMultipleComponent]
public class Sentient : MonoBehaviour
{
    [SerializeField]
    private Interactable _Info;

    private SphereCollider _AreaCollider;

    [SerializeField]
    private GameObject test;

    [SerializeField]
    private Opinion _Opinions;
    

    private void Start()
    {
        _AreaCollider = GetComponentInParent<SphereCollider>();

        _Info = Interactable.CreateInstance<Interactable>();
        _Info.GetStatDict().Clear();
        _Info.GetTraitDict().Clear();

        _Info.GetStatDict().Add("Health", Stat.CreateInstance<Stat>());
        _Info.GetStatDict().Add("Armour", Stat.CreateInstance<Stat>());
        _Info.GetStatDict().Add("Speed", Stat.CreateInstance<Stat>());
        _Info.GetStatDict().Add("Acuity", Stat.CreateInstance<Stat>());

        _Info.GetTraitDict().Add("Strong", Trait.CreateInstance<Trait>());
        _Info.GetTraitDict().Add("Fast", Trait.CreateInstance<Trait>());
        _Info.GetTraitDict().Add("Smart", Trait.CreateInstance<Trait>());

        _Info.name = this.name;

        _Opinions = Opinion.CreateInstance<Opinion>();
        _Opinions.GetDictOpinion().Clear();

        _Opinions.name = this.name;

        Invoke("SelfIdentify", 1);
        Invoke("Identify", 1);
    }

    public void SelfIdentify()
    {
        Identify(this.gameObject);
    }

    public void Identify()
    {
        Identify(test);
    }

    public bool Identify(GameObject unknownObject)
    {
        if (unknownObject.GetComponent<Sentient>() != null)
        {
            Dictionary<string, Trait>.KeyCollection keys
                    = unknownObject.GetComponent<Sentient>().GetInfo().GetTraitDict().Keys;

            List<string> keyValues = keys.ToList<string>();

            string output = this.name + "'s view of " + unknownObject.name;

            foreach (string i in keyValues)
            {
                output += i;
            }

            foreach (string val in keyValues)
            {
                _Opinions.AddOpinion(unknownObject.GetComponent<Sentient>().GetInfo(), unknownObject.GetComponent<Sentient>().GetInfo().GetTrait(val));
            }
        }

        return true;

    }

    public Interactable GetInfo()
    {
        return _Info;
    }
}
