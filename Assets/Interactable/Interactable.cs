using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Dictionary<string, Stat>  _Stats = new Dictionary<string, Stat>();
     
    private void Start()
    {
        _Stats.Add("Health", Stat.CreateInstance<Stat>());
        _Stats.Add("Armour", Stat.CreateInstance<Stat>());
    }

    public Dictionary<string, Stat> GetStatDict() {  return _Stats; }
   

    public Stat GetStat(string key) { return _Stats[key]; }
    public void AlterStat(string key, int changeAmount) { _Stats[key].AlterCur(changeAmount); }

}
