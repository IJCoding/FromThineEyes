using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

[AddComponentMenu(menuName: "Interactables/Sentient - Undefined")]
[RequireComponent(typeof(SphereCollider), typeof(NavMeshAgent))]
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

    [SerializeField]
    private GameObject _Target = null;

    [SerializeField]
    private int _SentientBerth = 3;

    private NavMeshAgent _NavMeshAgent = null;

    private void Awake()
    {
        _AreaCollider = GetComponentInParent<SphereCollider>();
        _NavMeshAgent = GetComponentInParent<NavMeshAgent>();
    }
    private void Start()
    {

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

    }

    private void Update()
    {
        if(_Target != null) Move(_Target);
    }

    public void OnDrawGizmos()
    {
        if (_AreaCollider == null) _AreaCollider = GetComponentInParent<SphereCollider>();
        Gizmos.DrawWireSphere(GetComponentInParent<Transform>().position, _AreaCollider.radius);
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

    private void OnTriggerEnter(Collider other)
    {
        Identify(other.gameObject);
    }

    private void Move(Transform target)
    {
        _NavMeshAgent.destination = target.position;
    }

    private float DistanceToTarget()
    {
        return Vector3.Distance(this.transform.position, _Target.transform.position);
    }

    private void Move(GameObject gObject)
    {
        if(gObject.GetComponent<Sentient>()!= null)
        {
             Move(gObject.transform);
            _NavMeshAgent.isStopped = DistanceToTarget() <= _SentientBerth;
        }
        
    }
}
