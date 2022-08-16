using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[CustomEditor(typeof(Interactable))]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable _target = target as Interactable;

        //  EditorGUILayout.LabelField("Effect: " + _target.GetEffect().GetName());

        List<string> _statKeys = new List<string>(_target.GetStatDict().Keys);
        
        //Stats        
        foreach (string key in _statKeys)
            {
                EditorGUILayout.BeginHorizontal();
        
                float newCur = EditorGUILayout.Slider(key,
                    _target.GetStat(key).GetCur(), _target.GetStat(key).GetMin(),
                    _target.GetStat(key).GetMax());
        
                _target.GetStat(key).SetCur((int)newCur);
        
                GUILayout.Label(_target.GetStat(key).GetMin().ToString() + "-" +
                    _target.GetStat(key).GetMax().ToString());
        
                EditorGUILayout.EndHorizontal();
            }

    }
}