using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newInteractable", menuName = "Interactables/Undefined")]
public class Interactable : ScriptableObject
{
    protected Dictionary<string, Stat>  _Stats = new Dictionary<string, Stat>();
    protected Dictionary<string, Trait> _Trait = new Dictionary<string, Trait>();

    public Dictionary<string, Stat> GetStatDict() {  return _Stats; }

    public Dictionary<string, Trait> GetTraitDict() { return _Trait; }

    public Stat GetStat(string key) { return _Stats[key]; }
    public void AlterStat(string key, int changeAmount) { _Stats[key].AlterCur(changeAmount); }
    public Trait GetTrait(string key) { return _Trait[key]; }
    public void AlterTraitLevel(string key, int changeAmount) { _Trait[key].GetLevel().AlterCur(changeAmount); }

    private void OnEnable()
    {
        _Stats.Add("Stat0", Stat.CreateInstance<Stat>());
        _Stats.Add("Stat1", Stat.CreateInstance<Stat>());
        _Stats.Add("Stat2", Stat.CreateInstance<Stat>());

        _Trait.Add("Trait0", Trait.CreateInstance<Trait>());
        _Trait.Add("Trait1", Trait.CreateInstance<Trait>());
        _Trait.Add("Trait2", Trait.CreateInstance<Trait>());
    }

}