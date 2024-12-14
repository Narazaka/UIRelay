using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UdonSharpEditor;

namespace Narazaka.VRChat.UIRelay.Editor
{
    public abstract class UIRelayToGameObjectEditorBase : UIRelayEditorBase
    {
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
            EditorGUILayout.PropertyField(serializedObject.FindProperty("receivers"), new GUIContent("Receiver Game Objects"), true);
        }

        protected virtual void OnInspectorContent() { }
    }
}
