using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Dictionary<string, Stat>  _Stats = new Dictionary<string, Stat>();
    private Dictionary<string, Trait> _Trait = new Dictionary<string, Trait>();

    private void Start()
    {
        _Stats.Add("Health", Stat.CreateInstance<Stat>());
        _Stats.Add("Armour", Stat.CreateInstance<Stat>());

        _Trait.Add("Strong", Trait.CreateInstance<Trait>());
        _Trait.Add("Smart", Trait.CreateInstance<Trait>());
    }

    public Dictionary<string, Stat> GetStatDict() {  return _Stats; }

    public Dictionary<string, Trait> GetTraitDict() { return _Trait; }

    public Stat GetStat(string key) { return _Stats[key]; }
    public void AlterStat(string key, int changeAmount) { _Stats[key].AlterCur(changeAmount); }
    public Trait GetTrait(string key) { return _Trait[key]; }
    public void AlterTraitLevel(string key, int changeAmount) { _Trait[key].GetLevel().AlterCur(changeAmount); }

}
