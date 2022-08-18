using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Opinion))]
public class OpinionEditor : Editor
{
    public override void OnInspectorGUI()
    { 
        Opinion _target = target as Opinion;

        List<Interactable> _interKeys = new List<Interactable>(_target.GetDictOpinion().Keys);

        GUIStyle bold = new GUIStyle();
        bold.fontStyle = FontStyle.Bold;
        bold.normal.textColor = Color.white;

        foreach (Interactable inter in _interKeys)
        {
            EditorGUILayout.LabelField(inter.name, bold);

            Editor editor = Editor.CreateEditor(inter);
            editor.OnInspectorGUI();

            EditorGUILayout.Space();
        }
    }
}
