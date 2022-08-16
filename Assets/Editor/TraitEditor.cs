using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Trait))]
public class TraitEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Trait _target = target as Trait;


        EditorGUILayout.LabelField("Effect: " + _target.GetEffect().GetName());

        EditorGUILayout.BeginHorizontal();

        float newCur = EditorGUILayout.Slider("Current level of trait.",
            _target.GetLevel().GetCur(), _target.GetLevel().GetMin(),
            _target.GetLevel().GetMax());
        
        _target.GetLevel().SetCur((int)newCur);

        GUILayout.Label(_target.GetLevel().GetMin().ToString() + "-" +
            _target.GetLevel().GetMax().ToString());

        EditorGUILayout.EndHorizontal();

    }
}

