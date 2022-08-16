using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Interactable))]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable _target = target as Interactable;

        //  EditorGUILayout.LabelField("Effect: " + _target.GetEffect().GetName());

        //Health
        if (_target.GetHealth() != null)
        {
            EditorGUILayout.BeginHorizontal();

            float newHealthCur = EditorGUILayout.Slider("Health.",
                _target.GetHealth().GetCur(), _target.GetHealth().GetMin(),
                _target.GetHealth().GetMax());

            _target.GetHealth().SetCur((int)newHealthCur);

            GUILayout.Label(_target.GetHealth().GetMin().ToString() + "-" +
                _target.GetHealth().GetMax().ToString());

            EditorGUILayout.EndHorizontal();
        }

        //Armour
        if (_target.GetArmour() != null)
        {
            EditorGUILayout.BeginHorizontal();

            float newArmourCur = EditorGUILayout.Slider("Armour.",
                _target.GetArmour().GetCur(), _target.GetArmour().GetMin(),
                _target.GetArmour().GetMax());

            _target.GetArmour().SetCur((int)newArmourCur);

            GUILayout.Label(_target.GetHealth().GetMin().ToString() + "-" +
                _target.GetArmour().GetMax().ToString());

            EditorGUILayout.EndHorizontal();
        }

        //Speed
        if (_target.GetSpeed() != null)
        {
            EditorGUILayout.BeginHorizontal();

            float newSpeedCur = EditorGUILayout.Slider("Speed.",
                _target.GetSpeed().GetCur(), _target.GetSpeed().GetMin(),
                _target.GetSpeed().GetMax());

            _target.GetSpeed().SetCur((int)newSpeedCur);

            GUILayout.Label(_target.GetSpeed().GetMin().ToString() + "-" +
                _target.GetSpeed().GetMax().ToString());

            EditorGUILayout.EndHorizontal();
        }

        //Acuity
        if (_target.GetAcuity() != null)
        {
            EditorGUILayout.BeginHorizontal();

            float newAcuityCur = EditorGUILayout.Slider("Acuity.",
                _target.GetAcuity().GetCur(), _target.GetHealth().GetMin(),
                _target.GetAcuity().GetMax());

            _target.GetAcuity().SetCur((int)newAcuityCur);

            GUILayout.Label(_target.GetAcuity().GetMin().ToString() + "-" +
                _target.GetAcuity().GetMax().ToString());

            EditorGUILayout.EndHorizontal();
        }
    }
}

