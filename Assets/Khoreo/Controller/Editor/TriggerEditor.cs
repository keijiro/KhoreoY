using UnityEditor;

namespace Khoreo
{
    [CustomEditor(typeof(Trigger)), CanEditMultipleObjects]
    sealed class TriggerEditor : Editor
    {
        SerializedProperty _action;
        SerializedProperty _event;

        void OnEnable()
        {
            _action = serializedObject.FindProperty("_action");
            _event  = serializedObject.FindProperty("_event");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(_action);
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(_event);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
