using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UdonSharpEditor;

namespace Narazaka.VRChat.UIRelay.Editor
{
    public abstract class UIRelayToUdonBehaviourEditorBase : UIRelayEditorBase
    {
        protected abstract string typeName { get; }

        public override void OnInspectorGUI()
        {
            if (UdonSharpGUI.DrawDefaultUdonSharpBehaviourHeader(target)) return;

            serializedObject.UpdateIfRequiredOrScript();

            OnInspectorBaseContent();
            OnInspectorContent();

            serializedObject.ApplyModifiedProperties();
        }

        protected void OnInspectorBaseContent()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("receivers"), new GUIContent("Receiver Udon Behaviours"), true);
            var variableName = serializedObject.FindProperty("variableName");
            if (variableName != null)
            {
                EditorGUILayout.PropertyField(variableName);
                EditorGUILayout.HelpBox(new GUIContent($"optional [{typeName}]"), false);
            }
            var callbackEventName = serializedObject.FindProperty("callbackEventName");
            if (callbackEventName != null)
            {
                EditorGUILayout.PropertyField(callbackEventName);
                EditorGUILayout.HelpBox(new GUIContent("optional"), false);
            }
        }

        protected virtual void OnInspectorContent() { }
    }
}
