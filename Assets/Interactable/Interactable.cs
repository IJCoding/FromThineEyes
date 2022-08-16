using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Stat _Health, _Armour, _Speed, _Acuity;

    private void Start()
    {
        _Health = Stat.CreateInstance<Stat>();
        _Armour = Stat.CreateInstance<Stat>();
        _Speed  = Stat.CreateInstance<Stat>();
        _Acuity = Stat.CreateInstance<Stat>();
    }

    public Stat GetHealth() { return _Health; }
    public Stat GetArmour() { return _Armour; }
    public Stat GetSpeed()  { return _Speed;  }
    public Stat GetAcuity() { return _Acuity; }

}
