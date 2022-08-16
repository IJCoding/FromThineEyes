using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Stat))]
public class StatEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Stat _target = target as Stat;
        base.OnInspectorGUI();
        if(GUILayout.Button("Output Current"))
        {
            Debug.Log(_target.GetCur());
        }
    }
}

