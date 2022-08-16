using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newTrait", menuName = "Traits")]
public class Trait : ScriptableObject
{
    [Tooltip("Set the effect this trait handles.")]
    [SerializeField]
    private Effect _effect;

    [Tooltip("Set the intensity of the effect.")]
    [SerializeField]
    private Stat _effectLevel;


    private void OnEnable()
    {
        if (_effect == null) { _effect = Effect.CreateInstance<Effect>(); }

        _effectLevel = Stat.CreateInstance<Stat>();
    }

    public Effect GetEffect() { return _effect; }

    public Stat GetLevel() { return this._effectLevel; }

    public int GetCurLevel() { return this._effectLevel.GetCur(); }

    public string GetName() { return this.name; }

}
