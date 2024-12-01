using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UdonSharpEditor;

namespace Narazaka.VRChat.UIRelay.Editor
{
    [CustomEditor(typeof(UIRelayToggleToUdonBehaviour))]
    public class UIRelayToggleToUdonBehaviourEditor : UIRelayToUdonBehaviourEditorBase
    {
        void OnEnable()
        {
            UIRelayEditorUtil.SetupEvent(target, (target as Component).GetComponent<Toggle>(), "onValueChanged", nameof(UIRelayToggleToUdonBehaviour.OnValueChanged));
        }

        protected override string typeName => "bool";

        protected override void OnInspectorContent()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("invert"));
        }
    }
}
