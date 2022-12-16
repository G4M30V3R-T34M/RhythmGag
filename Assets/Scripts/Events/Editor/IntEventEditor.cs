using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(IntGameEvent), editorForChildClasses: true)]
public class EventEditor : Editor
{
    int eventIntValue = 0;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        GUI.enabled = Application.isPlaying;

        eventIntValue = EditorGUILayout.DelayedIntField("Event Int Value", eventIntValue);

        IntGameEvent e = target as IntGameEvent;
        if (GUILayout.Button("Raise")) {
            e.Raise(eventIntValue);
        }
    }
}
