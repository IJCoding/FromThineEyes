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

        List<string> _statKeys = new List<string>(_target.GetStatDict().Keys);
        List<string> _traitKeys = new List<string>(_target.GetTraitDict().Keys);

        GUIStyle bold = new GUIStyle();
        bold.fontStyle = FontStyle.Bold;
        bold.normal.textColor = Color.white;

        if (_statKeys.Count > 0)
        {
            EditorGUILayout.LabelField("Stats", bold);
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

            EditorGUILayout.Space();
        }

        if (_traitKeys.Count > 0)
        {
            EditorGUILayout.LabelField("Traits", bold);
            //Trait
            foreach (string key in _traitKeys)
            {
                EditorGUILayout.BeginHorizontal();

                float newCur = EditorGUILayout.Slider(key,
                    _target.GetTrait(key).GetLevel().GetCur(), _target.GetTrait(key).GetLevel().GetMin(),
                    _target.GetTrait(key).GetLevel().GetMax());

                _target.GetTrait(key).GetLevel().SetCur((int)newCur);

                GUILayout.Label(_target.GetTrait(key).GetLevel().GetMin().ToString() + "-" +
                    _target.GetTrait(key).GetLevel().GetMax().ToString());

                EditorGUILayout.EndHorizontal();
            }
        }
    }
}